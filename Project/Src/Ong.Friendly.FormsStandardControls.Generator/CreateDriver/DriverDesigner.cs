using Codeer.TestAssistant.GeneratorToolKit;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls.Generator.CreateDriver
{
    public class DriverDesigner : IDriverDesigner
    {
        const string Indent = "    ";
        const string TodoComment = "// TODO It is not the best way to identify. Please change to a better method.";
        const string WindowsAppFriendTypeFullName = "Codeer.Friendly.Windows.WindowsAppFriend";
        const string AttachByTypeFullName = "Type Full Name";
        const string AttachByWindowText = "Window Text";
        const string AttachVariableWindowText = "VariableWindowText";
        const string AttachCustom = "Custom";

        public int Priority { get; }

        public bool CanDesign(object obj) => obj is Control;

        static bool CanBeParent(object obj) => obj is Form || obj is UserControl;

        public string CreateDriverClassName(object coreObj)
        {
            var driverTypeNameManager = new DriverTypeNameManager(DriverCreatorAdapter.SelectedNamespace, DriverCreatorAdapter.TypeFullNameAndWindowDriver, DriverCreatorAdapter.TypeFullNameAndUserControlDriver);
            return driverTypeNameManager.MakeDriverType(coreObj, out var _);
        }

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

        public string[] GetAttachMethodCandidates(object obj)
        {
            var candidates = new List<string>();
            candidates.Add(AttachByTypeFullName);
            candidates.Add(AttachByWindowText);
            candidates.Add(AttachVariableWindowText);
            candidates.Add(AttachCustom);
            return candidates.ToArray();
        }

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
            var driverName = control.GetType().Name + "Driver";
            var generatorName = driverName + "Generator";

            var driverCode = @"using Codeer.Friendly;
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
    {
        public {driverName}(AppVar appVar)
            : base(appVar) { }
    }
}
";
            DriverCreatorAdapter.AddCode($"{driverName}.cs", driverCode.Replace("{typefullname}", control.GetType().FullName).Replace("{driverName}", driverName), control);

            var generatorCode = @"using System;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace [*namespace]
{
    [CaptureCodeGenerator(""[*namespace.{driverName}]"")]
    public class {generatorName} : CaptureCodeGeneratorBase
    {
        Control _control;

        protected override void Attach()
        {
            _control = (Control)ControlObject;
        }

        protected override void Detach()
        {
        }
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

            var attr = (targetControl is Form) ? "WindowDriver" : "UserControlDriver";
            code.Add($"{Indent}[{attr}(TypeFullName = \"{targetControl.GetType().FullName}\")]");
            code.Add($"{Indent}public class {info.ClassName}");
            code.Add($"{Indent}{{");
            code.Add($"{Indent}{Indent}public WindowControl Core {{ get; }}");
            foreach (var e in members)
            {
                code.Add($"{Indent}{Indent}{e}");
            }
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
                if (targetControl is Form)
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
                        if (info.ManyExists)
                        {
                            if (info.AttachMethod == AttachByTypeFullName)
                            {
                                code.Add($"{Indent}{Indent}[WindowDriverIdentify(CustomMethod = \"TryGet\")]");
                                code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app, int index)");
                                code.Add($"{Indent}{Indent}{Indent}=> app.GetFromTypeFullName(\"{targetControl.GetType().FullName}\")[index].Dynamic();");
                                code.Add(string.Empty);
                                code.Add($"{Indent}{Indent}public static bool TryGet(WindowControl window, out int index)");
                                code.Add($"{Indent}{Indent}{{");
                                code.Add($"{Indent}{Indent}{Indent}index = window.App.GetFromTypeFullName(\"{targetControl.GetType().FullName}\").Select(e => e.Handle).ToList().IndexOf(window.Handle);");
                                code.Add($"{Indent}{Indent}{Indent}return index != -1;");
                                code.Add($"{Indent}{Indent}}}");
                            }
                            else
                            {
                                code.Add($"{Indent}{Indent}[WindowDriverIdentify(CustomMethod = \"TryGet\")]");
                                code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app, int index)");
                                code.Add($"{Indent}{Indent}{Indent}=> app.GetFromWindowText(\"{targetControl.Text}\")[index].Dynamic();");
                                code.Add(string.Empty);
                                code.Add($"{Indent}{Indent}public static bool TryGet(WindowControl window, out int index)");
                                code.Add($"{Indent}{Indent}{{");
                                code.Add($"{Indent}{Indent}{Indent}index = window.App.GetFromWindowText(\"{targetControl.Text}\").Select(e => e.Handle).ToList().IndexOf(window.Handle);");
                                code.Add($"{Indent}{Indent}{Indent}return index != -1;");
                                code.Add($"{Indent}{Indent}}}");
                            }
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
                        code.Add($"{Indent}{Indent}public static void TryGet(this WindowsAppFriend app, out T[] identifiers)");
                        code.Add($"{Indent}{Indent}{{");
                        code.Add($"{Indent}{Indent}{Indent}//TODO");
                        code.Add($"{Indent}{Indent}}}");
                    }
                    else if (info.AttachMethod == AttachVariableWindowText)
                    {
                        code.Add($"{Indent}{Indent}[UserControlDriverIdentify(CustomMethod = \"TryGet\")]");
                        code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app, string text)");
                        code.Add($"{Indent}{Indent}{Indent}=> app.GetTopLevelWindows().SelectMany(e => e.GetFromWindowText(text)).SingleOrDefault()?.Dynamic();");
                        code.Add(string.Empty);
                        code.Add($"{Indent}{Indent}public static void TryGet(this WindowsAppFriend app, out string[] texts)");
                        code.Add($"{Indent}{Indent}{Indent}=> texts = app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName(\"{targetControl.GetType().FullName}\")).Select(e => (string)e.Dynamic().Text).ToArray();");
                    }
                    else
                    {
                        if (info.ManyExists)
                        {
                            if (info.AttachMethod == AttachByTypeFullName)
                            {
                                code.Add($"{Indent}{Indent}[UserControlDriverIdentify(CustomMethod = \"TryGet\")]");
                                code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app, int index)");
                                code.Add($"{Indent}{Indent}{Indent}=> app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName(\"{targetControl.GetType().FullName}\")).ToArray()[index].Dynamic();");
                                code.Add(string.Empty);
                                code.Add($"{Indent}{Indent}public static void TryGet(this WindowsAppFriend app, out int[] indices)");
                                code.Add($"{Indent}{Indent}{Indent}=> indices = Enumerable.Range(0, app.GetTopLevelWindows().Sum(e => e.GetFromTypeFullName(\"{targetControl.GetType().FullName}\").Length)).ToArray();");
                            }
                            else
                            {
                                code.Add($"{Indent}{Indent}[UserControlDriverIdentify(CustomMethod = \"TryGet\")]");
                                code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app, int index)");
                                code.Add($"{Indent}{Indent}{Indent}=> app.GetTopLevelWindows().SelectMany(e => e.GetFromWindowText(\"{targetControl.Text}\")).ToArray()[index].Dynamic();");
                                code.Add(string.Empty);
                                code.Add($"{Indent}{Indent}public static void TryGet(this WindowsAppFriend app, out int[] indices)");
                                code.Add($"{Indent}{Indent}{Indent}=> indices = Enumerable.Range(0, app.GetTopLevelWindows().Sum(e => e.GetFromWindowText(\"{targetControl.Text}\").Length)).ToArray();");
                            }
                        }
                        else
                        {
                            if (info.AttachMethod == AttachByTypeFullName)
                            {
                                code.Add($"{Indent}{Indent}[UserControlDriverIdentify]");
                                code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app)");
                                code.Add($"{Indent}{Indent}{Indent}=> app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName(\"{targetControl.GetType().FullName}\")).SingleOrDefault()?.Dynamic();");
                            }
                            else
                            {
                                code.Add($"{Indent}{Indent}[UserControlDriverIdentify]");
                                code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this WindowsAppFriend app)");
                                code.Add($"{Indent}{Indent}{Indent}=> app.GetTopLevelWindows().SelectMany(e => e.GetFromWindowText(\"{targetControl.Text}\")).SingleOrDefault()?.Dynamic();");
                            }
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
                    code.Add($"{Indent}{Indent}public static void TryGet(this {parentDriver} parent, out T identifier)");
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
                    code.Add($"{Indent}{Indent}public static void TryGet(this {parentDriver} parent, out string[] texts)");
                    code.Add($"{Indent}{Indent}{Indent}=> texts = parent.Core.GetFromTypeFullName(\"{targetControl.GetType().FullName}\").Select(e => (string)e.Dynamic().Text).ToArray();");
                }
                else
                {
                    if (info.ManyExists)
                    {
                        if (info.AttachMethod == AttachByTypeFullName)
                        {
                            code.Add($"{Indent}{Indent}[UserControlDriverIdentify(CustomMethod = \"TryGet\")]");
                            code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this {parentDriver} parent, int index)");
                            code.Add($"{Indent}{Indent}{Indent}=> parent.Core.GetFromTypeFullName(\"{targetControl.GetType().FullName}\")[index].Dynamic();");
                            code.Add(string.Empty);
                            code.Add($"{Indent}{Indent}public static void TryGet(this {parentDriver} parent, out int[] indices)");
                            code.Add($"{Indent}{Indent}{Indent}=> indices = Enumerable.Range(0, parent.Core.GetFromTypeFullName(\"{targetControl.GetType().FullName}\").Length).ToArray();");
                        }
                        else
                        {
                            code.Add($"{Indent}{Indent}[UserControlDriverIdentify(CustomMethod = \"TryGet\")]");
                            code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this {parentDriver} parent, int index)");
                            code.Add($"{Indent}{Indent}{Indent}=> parent.Core.GetFromWindowText(\"{targetControl.Text}\")[index].Dynamic();");
                            code.Add(string.Empty);
                            code.Add($"{Indent}{Indent}public static void TryGet(this {parentDriver} parent, out int[] indices)");
                            code.Add($"{Indent}{Indent}{Indent}=> indices = Enumerable.Range(0, parent.Core.GetFromWindowText(\"{targetControl.Text}\").Length).ToArray();");
                        }
                    }
                    else
                    {
                        if (info.AttachMethod == AttachByTypeFullName)
                        {
                            code.Add($"{Indent}{Indent}[UserControlDriverIdentify]");
                            code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this {parentDriver} parent)");
                            code.Add($"{Indent}{Indent}{Indent}=> parent.Core.GetFromTypeFullName(\"{targetControl.GetType().FullName}\").SingleOrDefault()?.Dynamic();");
                        }
                        else
                        {
                            code.Add($"{Indent}{Indent}[UserControlDriverIdentify]");
                            code.Add($"{Indent}{Indent}public static {info.ClassName} {funcName}(this {parentDriver} parent)");
                            code.Add($"{Indent}{Indent}{Indent}=> parent.Core.GetFromWindowText(\"{targetControl.Text}\").SingleOrDefault()?.Dynamic();");
                        }
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
            if (0 < index && index == driverClassName.Length - DriverCreatorUtils.Suffix.Length) return "Attach" + driverClassName;

            return $"Attach{driverClassName.Substring(0, driverClassName.Length - DriverCreatorUtils.Suffix.Length)}";
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
            string name = string.Empty;
            var usings = new List<string>();
            var accessPaths = new List<string>();
            var isWindowControl = new List<bool>();
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
                        name = sp.Length == 0 ? string.Empty : sp[sp.Length - 1];
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

            if (string.IsNullOrEmpty(name))
            {
                var names = new List<string>();
                var customNameGenerator = new DriverElementNameGeneratorAdaptor(dom);
                name = customNameGenerator.MakeDriverPropName(elementCtrl, string.Empty, names);
            }

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

                if (DriverCreatorUtils.CanConvert(e.TypeFullName))
                {
                    members.Add($"public {typeName} {e.Name} => {e.Identify}; {todo}");
                }
                else
                {
                    members.Add($"public {typeName} {e.Name} => new {typeName}({e.Identify}); {todo}");
                }
                
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
