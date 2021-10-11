using Codeer.TestAssistant.GeneratorToolKit;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls.Generator.CreateDriver
{
    /// <summary>
    /// Driver Designer.
    /// </summary>
    public class DriverDesigner : IDriverDesigner
    {
        const string Indent = "    ";
        const string TodoComment = "// TODO It is not the best way to identify. Please change to a better method.";
        const string WindowsAppFriendTypeFullName = "Codeer.Friendly.Windows.WindowsAppFriend";
        const string AttachByTypeFullName = "Type Full Name";
        const string AttachByWindowText = "Window Text";
        const string AttachVariableWindowText = "Variable Window Text";
        const string AttachCustom = "Custom";

        /// <summary>
        /// priority.
        /// </summary>
        public int Priority { get; }

        /// <summary>
        /// can you design a driver for a given object?
        /// </summary>
        /// <param name="obj">obj.</param>
        /// <returns>Can you design a driver for a given object?</returns>
        public bool CanDesign(object obj) => obj is Control;

        static bool CanBeParent(object obj) => obj is Form || obj is UserControl;

        /// <summary>
        /// create driver class name.
        /// </summary>
        /// <param name="coreObj">root.</param>
        /// <returns>driver class name.</returns>
        public string CreateDriverClassName(object coreObj)
        {
            var driverTypeNameManager = new DriverTypeNameManager(DriverCreatorAdapter.SelectedNamespace, DriverCreatorAdapter.TypeFullNameAndWindowDriver, DriverCreatorAdapter.TypeFullNameAndUserControlDriver);
            return driverTypeNameManager.MakeDriverType(coreObj, out var _);
        }


        /// <summary>
        /// candidates of attach extension class.
        /// </summary>
        /// <param name="obj">obj.</param>
        /// <returns>candidates of attach extension class.</returns>
        public string[] GetAttachExtensionClassCandidates(object obj)
        {
            var candidates = new List<string>();
            var parent = ((Control)obj).Parent;
            while (parent != null)
            {
                var driver = DriverCreatorUtils.GetDriverTypeFullName(parent, new Dictionary<string, ControlDriverInfo>(),
                                                                    DriverCreatorAdapter.TypeFullNameAndUserControlDriver,
                                                                    DriverCreatorAdapter.TypeFullNameAndWindowDriver, out var _);
                if (!string.IsNullOrEmpty(driver))
                {
                    candidates.Add(driver);
                }
                parent = parent.Parent;
            }
            candidates.Add(WindowsAppFriendTypeFullName);
            return candidates.ToArray();
        }

        /// <summary>
        /// candidates of attach method.
        /// </summary>
        /// <param name="obj">obj.</param>
        /// <returns>candidates of attach method.</returns>
        public string[] GetAttachMethodCandidates(object obj)
        {
            var candidates = new List<string>();
            candidates.Add(AttachByTypeFullName);
            candidates.Add(AttachByWindowText);
            candidates.Add(AttachVariableWindowText);
            candidates.Add(AttachCustom);
            return candidates.ToArray();
        }

        /// <summary>
        /// candidate code to identify element.
        /// </summary>
        /// <param name="root">root.</param>
        /// <param name="element">elemnet.</param>
        /// <returns>candidate code to identify element.</returns>
        public DriverIdentifyInfo[] GetIdentifyingCandidates(object root, object element)
        {
            var rootCtrl = (Control)root;
            var elementCtrl = (Control)element;

            if (rootCtrl == null || elementCtrl == null) return new DriverIdentifyInfo[0];

            using (var dom = CodeDomProvider.CreateProvider("CSharp"))
            {
                var infos = GetIdentifyingCandidatesCore(dom, rootCtrl, elementCtrl);
                if (infos != null) return infos;
            }

            return new DriverIdentifyInfo[0];
        }

        /// <summary>
        /// generate code.
        /// </summary>
        /// <param name="targetControl">root.</param>
        /// <param name="info">information.</param>
        public void GenerateCode(object targetControl, DriverDesignInfo info)
        {
            var code = GenerateCodeCore((Control)targetControl, info);
            var fileName = $"{info.ClassName}.cs";
            DriverCreatorAdapter.AddCode(fileName, code, targetControl);

            //行選択でのツリーとの連動用
            foreach (var e in info.Properties)
            {
                DriverCreatorAdapter.AddCodeLineSelectInfo(fileName, e.Identify, e.Element);
            }
        }

        internal static void CreateControlDriver(Control control)
        {
            var list = new List<Type>();
            var type = control.GetType();
            while (type != null)
            {
                list.Add(type);
                type = type.BaseType;
                if (type == null || type == typeof(Control) || type == typeof(UserControl) || type == typeof(Form))
                {   
                    break;
                }
            }

            var driverName = (list.Count == 1) ? list[0].Name + "Driver" : string.Empty;
            var targetType = control.GetType();
            string[] targetEventName = null;
            EventInfo[] eventInfoList = null;
            try
            {
                eventInfoList = targetType.GetEvents(
                    BindingFlags.FlattenHierarchy |
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.Static);
            }
            catch { }

            // DriverGeneratorに関する設定
            using (var dlg = new TypeSelectForm())
            {
                var settingType = (1 < list.Count) ? TypeSelectForm.SettingType.Type : TypeSelectForm.SettingType.None;
                settingType |= (eventInfoList != null && 0 < eventInfoList.Length) ? TypeSelectForm.SettingType.Event : 0;
                dlg.SetSettingType(settingType);

                if ((settingType & TypeSelectForm.SettingType.Type) != 0)
                {
                    dlg.SetTypeList(list.ToArray());
                }
                if ((settingType & TypeSelectForm.SettingType.Event) != 0)
                {
                    foreach (var eventInfo in eventInfoList)
                    {
                        dlg.AddEventName(eventInfo.Name);
                    }
                }
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                if ((settingType & TypeSelectForm.SettingType.Type) != 0)
                {
                    driverName = dlg.SelectedType.Name + "Driver";
                    targetType = dlg.SelectedType;
                }
                if ((settingType & TypeSelectForm.SettingType.Event) != 0)
                {
                    targetEventName = dlg.GetSelectedEventName();
                }
            }

            var propertyCode = string.Empty;
            var methodCode = string.Empty;
            // Driverに関する設定
            using (var dlg = new PropertyMethodSelectForm(control))
            {
                var result = dlg.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    propertyCode = dlg.GetOutputTextProperty();
                    methodCode = dlg.GetOutputTextMethod();
                }
            }

            var generatorName = driverName + "Generator";

            var driverCode = @"using Codeer.Friendly;";
            if (targetEventName != null)
            {
                driverCode += @"
using Codeer.Friendly.Dynamic;";
            }
            driverCode += @"
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;
using System;
using System.Windows.Forms;

namespace [*namespace]
{
    [ControlDriver(TypeFullName = ""{typefullname}"", Priority = 2)]
    public class {driverName} : FormsControlBase
    {";
            driverCode += (0 < propertyCode.Length) ? Environment.NewLine : "";
            driverCode += propertyCode;
            driverCode += @"
        public {driverName}(AppVar appVar)
            : base(appVar) { }";
            driverCode += (0 < methodCode.Length) ? Environment.NewLine : "";
            driverCode += methodCode;
            driverCode += @"
    }
}
";
            DriverCreatorAdapter.AddCode($"{driverName}.cs", driverCode.Replace("{typefullname}", targetType.FullName).Replace("{driverName}", driverName), control);

            var generatorCode = @"using System;
using System.Windows.Forms;";
            if (targetEventName != null)
            {
                generatorCode += @"
using System.Collections.Generic;";
            }
            generatorCode += @"
using Codeer.TestAssistant.GeneratorToolKit;

namespace [*namespace]
{
    [CaptureCodeGenerator(""[*namespace.{driverName}]"")]
    public class {generatorName} : CaptureCodeGeneratorBase
    {";
            if (targetEventName != null)
            {
                generatorCode += @"
        List<Action> _removes = new List<Action>();";
            }
            generatorCode += @"
        Control _control;

        protected override void Attach()
        {
            _control = (Control)ControlObject;";

            if (targetEventName != null)
            {
                foreach (var name in targetEventName)
                {
                    generatorCode += @"
            _removes.Add(EventAdapter.Add(ControlObject, ""{eventName}"", {eventName}));";
                    generatorCode = generatorCode.Replace("{eventName}", name);
                }
            }
            generatorCode += @"
        }

        protected override void Detach()
        {";
            if (targetEventName != null)
            {
                generatorCode += @"
            _removes.ForEach(e => e());";
            }
            generatorCode += @"
        }";
            if (targetEventName != null)
            {
                foreach (var name in targetEventName)
                {
                    generatorCode += @"

        void {eventName}(object sender, dynamic e)
        {
        }";
                    generatorCode = generatorCode.Replace("{eventName}", name);
                }
            }
            generatorCode += @"
    }
}
";
            DriverCreatorAdapter.AddCode($"{generatorName}.cs", generatorCode.Replace("{generatorName}", generatorName).Replace("{driverName}", driverName), control);
        }

        string GenerateCodeCore(Control targetControl, DriverDesignInfo info)
        {
            //クラス定義部分
            var classDefine = GenerateClassDefine(targetControl, info, out var memberUsings);

            //拡張メソッド部分
            var extentionsDefine = GenerateExtensions(targetControl, info, out var extensionUsings);

            //using
            var usings = new List<string>();
            DistinctAddRange(new[]
                    {
                        "Codeer.TestAssistant.GeneratorToolKit",
                        "Codeer.Friendly.Windows.Grasp",
                        "Codeer.Friendly.Windows",
                        "Codeer.Friendly.Dynamic",
                        "Codeer.Friendly",
                        "System.Linq"
                    }, usings);
            DistinctAddRange(memberUsings, usings);
            DistinctAddRange(extensionUsings, usings);
            usings.Remove(DriverCreatorAdapter.SelectedNamespace);
            usings.Sort();

            //コード作成
            var code = new List<string>();
            foreach (var e in usings)
            {
                code.Add($"using {e};");
            }
            code.Add(string.Empty);
            code.Add($"namespace {DriverCreatorAdapter.SelectedNamespace}");
            code.Add("{");
            code.AddRange(classDefine);
            code.AddRange(extentionsDefine);
            code.Add("}");
            return string.Join(Environment.NewLine, code.ToArray());
        }

        static List<string> GenerateClassDefine(object targetControl, DriverDesignInfo info, out List<string> usings)
        {
            GetMembers(info, out usings, out var members);

            var code = new List<string>();
            var coreType = "WindowControl";

            var controlDriverTypeFullname = DriverCreatorUtils.GetControlDriverTypeFullName(targetControl, DriverCreatorAdapter.TypeFullNameAndControlDriver);
            if (!string.IsNullOrEmpty(controlDriverTypeFullname))
            {
                coreType = DriverCreatorUtils.GetTypeName(controlDriverTypeFullname);
                usings.Add(DriverCreatorUtils.GetTypeNamespace(controlDriverTypeFullname));
            }

            var attr = (targetControl is Form form && form.TopLevel) ? "WindowDriver" : "UserControlDriver";
            code.Add($"{Indent}[{attr}(TypeFullName = \"{targetControl.GetType().FullName}\")]");
            code.Add($"{Indent}public class {info.ClassName}");
            code.Add($"{Indent}{{");
            code.Add($"{Indent}{Indent}public {coreType} Core {{ get; }}");
            foreach (var e in members)
            {
                code.Add($"{Indent}{Indent}{e}");
            }

            if (string.IsNullOrEmpty(controlDriverTypeFullname))
            {
                code.Add(string.Empty);
                code.Add($"{Indent}{Indent}public {info.ClassName}(WindowControl core)");
                code.Add($"{Indent}{Indent}{{");
                code.Add($"{Indent}{Indent}{Indent}Core = core;");
                code.Add($"{Indent}{Indent}}}");

                code.Add(string.Empty);
                code.Add($"{Indent}{Indent}public {info.ClassName}(AppVar core)");
                code.Add($"{Indent}{Indent}{{");
                code.Add($"{Indent}{Indent}{Indent}Core = new WindowControl(core);");
                code.Add($"{Indent}{Indent}}}");
                code.Add($"{Indent}}}");
            }
            else
            {
                code.Add(string.Empty);
                code.Add($"{Indent}{Indent}public {info.ClassName}(WindowControl core) : this(core.AppVar) {{}}");
                code.Add(string.Empty);
                code.Add($"{Indent}{Indent}public {info.ClassName}(AppVar core)");
                code.Add($"{Indent}{Indent}{{");
                code.Add($"{Indent}{Indent}{Indent}Core = new {coreType}(core);");
                code.Add($"{Indent}{Indent}}}");
                code.Add($"{Indent}}}");
            }
            return code;
        }

        static List<string> GenerateExtensions(Control targetControl, DriverDesignInfo info, out List<string> usings)
        {
            var code = new List<string>();
            usings = new List<string>();

            if (!info.CreateAttachCode) return code;

            code.Add(string.Empty);
            code.Add($"{Indent}public static class {info.ClassName}Extensions");
            code.Add($"{Indent}{{");

            var funcName = GetAttachFuncName(info.ClassName);

            //WindowsAppFriendにアタッチする場合
            if (info.AttachExtensionClass == WindowsAppFriendTypeFullName)
            {
                if (targetControl is Form form && form.TopLevel)
                {
                    if (info.AttachMethod == AttachCustom)
                    {
                        code.Add($"{Indent}{Indent}[WindowDriverIdentify(CustomMethod = \"TryGet\")]");
                        code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app, T identifier)");
                        code.Add($"{Indent}{Indent}{{");
                        code.Add($"{Indent}{Indent}{Indent}//TODO");
                        code.Add($"{Indent}{Indent}}}");
                        code.Add(string.Empty);
                        code.Add($"{Indent}{Indent}public static bool TryGet(WindowControl window, out T identifier)");
                        code.Add($"{Indent}{Indent}{{");
                        code.Add($"{Indent}{Indent}{Indent}//TODO");
                        code.Add($"{Indent}{Indent}}}");
                    }
                    else if (info.AttachMethod == AttachVariableWindowText)
                    {
                        code.Add($"{Indent}{Indent}[WindowDriverIdentify(CustomMethod = \"TryGet\")]");
                        code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app, string text)");
                        code.Add($"{Indent}{Indent}{Indent}=> app.WaitForIdentifyFromWindowText(\"{targetControl.Text}\").Dynamic();");
                        code.Add(string.Empty);
                        code.Add($"{Indent}{Indent}public static bool TryGet(WindowControl window, out string text)");
                        code.Add($"{Indent}{Indent}{{");
                        code.Add($"{Indent}{Indent}{Indent}text = window.GetWindowText();");
                        code.Add($"{Indent}{Indent}{Indent}return window.TypeFullName == \"{targetControl.GetType().FullName}\";");
                        code.Add($"{Indent}{Indent}}}");
                    }
                    else
                    {
                        if (info.AttachMethod == AttachByTypeFullName)
                        {
                            code.Add($"{Indent}{Indent}[WindowDriverIdentify(TypeFullName = \"{targetControl.GetType().FullName}\")]");
                            code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app)");
                            code.Add($"{Indent}{Indent}{Indent}=> app.WaitForIdentifyFromTypeFullName(\"{targetControl.GetType().FullName}\").Dynamic();");
                        }
                        else
                        {
                            code.Add($"{Indent}{Indent}[WindowDriverIdentify(WindowText = \"{targetControl.Text}\")]");
                            code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app)");
                            code.Add($"{Indent}{Indent}{Indent}=> app.WaitForIdentifyFromWindowText(\"{targetControl.Text}\").Dynamic();");
                        }
                    }
                }
                //UserControl
                else
                {
                    if (info.AttachMethod == AttachCustom)
                    {
                        code.Add($"{Indent}{Indent}[UserControlDriverIdentify(CustomMethod = \"TryGet\")]");
                        code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app, T identifier)");
                        code.Add($"{Indent}{Indent}{{");
                        code.Add($"{Indent}{Indent}{Indent}//TODO");
                        code.Add($"{Indent}{Indent}}}");
                        code.Add(string.Empty);
                        code.Add($"{Indent}{Indent}public static T[] TryGet(this WindowsAppFriend app)");
                        code.Add($"{Indent}{Indent}{{");
                        code.Add($"{Indent}{Indent}{Indent}//TODO");
                        code.Add($"{Indent}{Indent}}}");
                    }
                    else if (info.AttachMethod == AttachVariableWindowText)
                    {
                        code.Add($"{Indent}{Indent}[UserControlDriverIdentify(CustomMethod = \"TryGet\")]");
                        code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app, string text)");
                        code.Add($"{Indent}{Indent}{Indent}=> app.GetTopLevelWindows().SelectMany(e => e.GetFromWindowText(text)).FirstOrDefault()?.Dynamic();");
                        code.Add(string.Empty);
                        code.Add($"{Indent}{Indent}public static string[] TryGet(this WindowsAppFriend app)");
                        code.Add($"{Indent}{Indent}{Indent}=> app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName(\"{targetControl.GetType().FullName}\")).Select(e => (string)e.Dynamic().Text).ToArray();");
                    }
                    else
                    {
                        if (info.AttachMethod == AttachByTypeFullName)
                        {
                            code.Add($"{Indent}{Indent}[UserControlDriverIdentify]");
                            code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app)");
                            code.Add($"{Indent}{Indent}{Indent}=> app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName(\"{targetControl.GetType().FullName}\")).FirstOrDefault()?.Dynamic();");
                        }
                        else
                        {
                            code.Add($"{Indent}{Indent}[UserControlDriverIdentify]");
                            code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app)");
                            code.Add($"{Indent}{Indent}{Indent}=> app.GetTopLevelWindows().SelectMany(e => e.GetFromWindowText(\"{targetControl.Text}\")).FirstOrDefault()?.Dynamic();");
                        }
                    }
                }
            }
            //ドライバへのアタッチ
            else
            {
                SeparateNameSpaceAndTypeName(info.AttachExtensionClass, out var ns, out var parentDriver);
                if (!string.IsNullOrEmpty(ns))
                {
                    usings.Add(ns);
                }

                if (info.AttachMethod == AttachCustom)
                {
                    code.Add($"{Indent}{Indent}[UserControlDriverIdentify(CustomMethod = \"TryGet\")]");
                    code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this {parentDriver} parent, T identifier)");
                    code.Add($"{Indent}{Indent}{{");
                    code.Add($"{Indent}{Indent}{Indent}//TODO");
                    code.Add($"{Indent}{Indent}}}");
                    code.Add(string.Empty);
                    code.Add($"{Indent}{Indent}public static T[] TryGet(this {parentDriver} parent)");
                    code.Add($"{Indent}{Indent}{{");
                    code.Add($"{Indent}{Indent}{Indent}//TODO");
                    code.Add($"{Indent}{Indent}}}");
                }
                else if (info.AttachMethod == AttachVariableWindowText)
                {
                    code.Add($"{Indent}{Indent}[UserControlDriverIdentify(CustomMethod = \"TryGet\")]");
                    code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this {parentDriver} parent, string text)");
                    code.Add($"{Indent}{Indent}{Indent}=> parent.Core.IdentifyFromWindowText(\"{targetControl.Text}\").Dynamic();");
                    code.Add(string.Empty);
                    code.Add($"{Indent}{Indent}public static string[] TryGet(this {parentDriver} parent)");
                    code.Add($"{Indent}{Indent}{Indent}=> parent.Core.GetFromTypeFullName(\"{targetControl.GetType().FullName}\").Select(e => (string)e.Dynamic().Text).ToArray();");
                }
                else
                {
                    if (info.AttachMethod == AttachByTypeFullName)
                    {
                        code.Add($"{Indent}{Indent}[UserControlDriverIdentify]");
                        code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this {parentDriver} parent)");
                        code.Add($"{Indent}{Indent}{Indent}=> parent.Core.GetFromTypeFullName(\"{targetControl.GetType().FullName}\").FirstOrDefault()?.Dynamic();");
                    }
                    else
                    {
                        code.Add($"{Indent}{Indent}[UserControlDriverIdentify]");
                        code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this {parentDriver} parent)");
                        code.Add($"{Indent}{Indent}{Indent}=> parent.Core.GetFromWindowText(\"{targetControl.Text}\").FirstOrDefault()?.Dynamic();");
                    }
                }
            }
            code.Add($"{Indent}}}");

            return code;
        }

         static void SeparateNameSpaceAndTypeName(string attachExtensionClass, out string ns, out string parentDriver)
        {
            ns = string.Empty;
            parentDriver = attachExtensionClass;

            var sp = attachExtensionClass.Split('.');
            if (sp.Length < 2) return;

            parentDriver = sp[sp.Length - 1];
            var nsArray = new string[sp.Length - 1];
            Array.Copy(sp, nsArray, nsArray.Length);
            ns = string.Join(".", nsArray);
        }

        static string GetAttachFuncName(string driverClassName)
        {
            var index = driverClassName.IndexOf(DriverCreatorUtils.Suffix);
            if (0 < index && index == driverClassName.Length - DriverCreatorUtils.Suffix.Length)
            {
                return $"Attach{driverClassName.Substring(0, driverClassName.Length - DriverCreatorUtils.Suffix.Length)}";
            }
            return "Attach" + driverClassName;
        }

        static void DistinctAddRange(IEnumerable<string> src, List<string> dst)
        {
            foreach (var e in src)
            {
                if (!dst.Contains(e)) dst.Add(e);
            }
        }

        DriverIdentifyInfo[] GetIdentifyingCandidatesCore(CodeDomProvider dom, Control rootCtrl, Control elementCtrl)
        {
            if (rootCtrl == elementCtrl) return new DriverIdentifyInfo[0];

            var current = elementCtrl.Parent;
            var ancestor = new List<Control>();
            while (current != null)
            {
                if (CanBeParent(current))
                {
                    ancestor.Add(current);
                }
                if (ReferenceEquals(current, rootCtrl)) break;
                current = current.Parent;
            }
            if (ancestor.Count == 0)
            {
                ancestor.Add(rootCtrl);
            }

            //Fieldでたどることができる範囲を取得
            var target = elementCtrl;
            var isPerfect = true;
            var usings = new List<string>();
            var accessPaths = new List<string>();
            var isWindowControl = new List<bool>();
            var fieldName = string.Empty;
            for (int i = 0; i < ancestor.Count; i++)
            {
                var currentPrarent = ancestor[i];
                //直接のフィールドに持っているか？
                var path = GetAccessPath(currentPrarent, target);
                if (!string.IsNullOrEmpty(path))
                {
                    //最初がフィールドで特定できた場合はその名前を使う
                    if (target == elementCtrl)
                    {
                        var sp = path.Split('.');
                        fieldName = sp.Length == 0 ? string.Empty : sp[sp.Length - 1];
                    }
                    accessPaths.Insert(0, path);
                    isWindowControl.Insert(0, false);
                    target = currentPrarent;
                    continue;
                }

                //Typeで特定できる場合
                if (CanIdentifyByType(currentPrarent, target))
                {
                    //さらに上の階層から特定可能かみる
                    for (int j = i + 1; j < ancestor.Count; j++)
                    {
                        if (CanIdentifyByType(ancestor[j], target))
                        {
                            i++;
                            currentPrarent = ancestor[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                    accessPaths.Insert(0, $"IdentifyFromTypeFullName(\"{target.GetType().FullName}\")");
                    isWindowControl.Insert(0, true);
                    target = currentPrarent;
                    continue;
                }

                var controlPath = GetControlTreePath(currentPrarent, target);
                if (string.IsNullOrEmpty(controlPath)) return null;

                accessPaths.Insert(0, controlPath);
                isWindowControl.Insert(0, false);
                target = currentPrarent;
            }

            if (target != rootCtrl) return null;

            var names = new List<string>();
            var customNameGenerator = new DriverElementNameGeneratorAdaptor(dom);
            var name = customNameGenerator.MakeDriverPropName(elementCtrl, fieldName, names);

            var windowControlNew = string.Empty;
            bool modeDynamic = false;
            for (int i = 0; i < isWindowControl.Count; i++)
            {
                if (isWindowControl[i])
                {
                    if (modeDynamic)
                    {
                        if (0 < i)
                        {
                            windowControlNew = "new WindowControl(" + windowControlNew;
                            accessPaths[i - 1] = accessPaths[i - 1] + ")";
                        }
                    }
                    modeDynamic = false;
                }
                else
                {
                    if (!modeDynamic)
                    {
                        accessPaths[i] = "Dynamic()." + accessPaths[i];
                    }
                    modeDynamic = true;
                }
            }
            var accessPath = string.Join(".", accessPaths.ToArray());
            if (!modeDynamic)
            {
                accessPath += ".Dynamic()";
            }

            return new[]
            {
                new DriverIdentifyInfo
                {
                    IsPerfect = isPerfect,
                    Identify = windowControlNew + "Core." + accessPath,
                    DefaultName = name,
                    ExtensionUsingNamespaces = usings.ToArray(),
                    DriverTypeCandidates = GetDriverTypeCandidates(elementCtrl)
                }
            };
        }

        static bool CanIdentifyByType(Control rootCtrl, Control target)
        {
            var targetType = target.GetType();

            var types = new List<string>();
            GetAllTypeFullNames(rootCtrl, types);
            int matchCount = 0;
            foreach (var e in types)
            {
                if (targetType.FullName == e) matchCount++;
            }
            return matchCount == 1;
        }

        static string GetControlTreePath(Control rootCtrl, Control elementCtrl)
        {
            var current = elementCtrl;
            var identify = new List<string>();
            while (true)
            {
                if (current.Parent == null) break;

                var checkCount = identify.Count;
                for (var i = 0; i < current.Parent.Controls.Count; i++)
                {
                    if (ReferenceEquals(current, current.Parent.Controls[i]))
                    {
                        identify.Insert(0, $"Controls[{i}]");
                        break;
                    }
                }

                //未発見
                if (checkCount == identify.Count) break;

                current = current.Parent;
                if (ReferenceEquals(current, rootCtrl)) break;
            }

            if (!ReferenceEquals(current, rootCtrl)) return string.Empty;

            return string.Join(".", identify.ToArray());
        }

        static void GetAllTypeFullNames(Control ctrl, List<string> types)
        {
            types.Add(ctrl.GetType().FullName);
            foreach (Control e in ctrl.Controls)
            {
                if (e == null) continue;
                GetAllTypeFullNames(e, types);
            }
        }

        static string[] GetDriverTypeCandidates(Control elementCtrl)
            => DriverCreatorUtils.GetDriverTypeFullNames(elementCtrl, DriverCreatorAdapter.MultiTypeFullNameAndControlDriver, DriverCreatorAdapter.MultiTypeFullNameAndUserControlDriver, DriverCreatorAdapter.MultiTypeFullNameAndWindowDriver);

        static string GetAccessPath(Control parent, Control target)
        {
            foreach (var e in parent.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (ReferenceEquals(e.GetValue(parent), target)) return e.Name;
            }
            return string.Empty;
        }

        static void GetMembers(DriverDesignInfo info, out List<string> usings, out List<string> members)
        {
            usings = new List<string>();
            members = new List<string>();
            var fileName = $"{info.ClassName}.cs";
            foreach (var e in info.Properties)
            {
                var typeName = DriverCreatorUtils.GetTypeName(e.TypeFullName);
                var nameSpace = DriverCreatorUtils.GetTypeNamespace(e.TypeFullName);
                var todo = (e.IsPerfect.HasValue && !e.IsPerfect.Value) ? TodoComment : string.Empty;

                members.Add($"public {typeName} {e.Name} => {e.Identify}; {todo}");

                if (!usings.Contains(nameSpace)) usings.Add(nameSpace);
            }
        }

        static Control FindRoot(Control targetControl, DriverTypeNameManager driverTypeNameManager)
        {
            var ctrl = targetControl.Parent;
            if (ctrl == null) return targetControl;

            while (true)
            {
                if (DriverCreatorAdapter.TypeFullNameAndUserControlDriver.ContainsKey(ctrl.GetType().FullName)) return ctrl;
                if (DriverCreatorAdapter.TypeFullNameAndWindowDriver.ContainsKey(ctrl.GetType().FullName)) return ctrl;

                if (ctrl.Parent == null) return ctrl;
                ctrl = ctrl.Parent;
            }
        }
    }
}
