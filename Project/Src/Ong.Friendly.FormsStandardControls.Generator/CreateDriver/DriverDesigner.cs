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

            var infos = GetIdentifyingCandidatesByField(rootCtrl, elementCtrl);
            if (infos != null) return infos;

            infos = GetIdentifyingCandidatesByType(rootCtrl, elementCtrl);
            if (infos != null) return infos;

            using (var dom = CodeDomProvider.CreateProvider("CSharp"))
            {
                infos = GetIdentifyingCandidatesByControlTree(dom, rootCtrl, elementCtrl);
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

            var funcName = GetFuncName(info.ClassName);

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
                                code.Add($"{Indent}{Indent}public static {info.ClassName} {GetFuncName(info.ClassName)}(this WindowsAppFriend app)");
                                code.Add($"{Indent}{Indent}{Indent}=> app.WaitForIdentifyFromTypeFullName(\"{targetControl.GetType().FullName}\").Dynamic();");
                            }
                            else
                            {
                                code.Add($"{Indent}{Indent}[WindowDriverIdentify(WindowText = \"{targetControl.Text}\")]");
                                code.Add($"{Indent}{Indent}public static {info.ClassName} {GetFuncName(info.ClassName)}(this WindowsAppFriend app)");
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

        static string GetFuncName(string driverClassName)
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

        static DriverIdentifyInfo[] GetIdentifyingCandidatesByField(Control rootCtrl, Control elementCtrl)
        {
            var current = elementCtrl.Parent;
            var ancestor = new List<Control>();
            while (current != null)
            {
                ancestor.Add(current);
                if (ReferenceEquals(current, rootCtrl)) break;
                current = current.Parent;
            }

            var target = elementCtrl;
            var accessPaths = new List<string>();
            foreach (var e in ancestor)
            {
                //直接のフィールドに持っているか？
                var path = GetAccessPath(e, target);
                if (!string.IsNullOrEmpty(path))
                {
                    accessPaths.Insert(0, path);
                    target = e;
                }
            }

            if (target != rootCtrl) return null;

            var accessPath = string.Join(".", accessPaths.ToArray());
            var sp = accessPath.Split('.');
            return new[]
            {
                new DriverIdentifyInfo
                {
                    IsPerfect = true,
                    Identify = "Core.Dynamic()." + accessPath,
                    DefaultName = sp[sp.Length - 1]
                }
            };
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

        static DriverIdentifyInfo[] GetIdentifyingCandidatesByType(Control rootCtrl, Control elementCtrl)
        {
            var targetType = elementCtrl.GetType();

            var types = new List<string>();
            GetAllTypeFullNames(rootCtrl, types);
            int matchCount = 0;
            foreach (var e in types)
            {
                if (targetType.FullName == e) matchCount++;
            }
            if (matchCount != 1) return null;

            return new[]
            {
                new DriverIdentifyInfo
                {
                    IsPerfect = true,
                    Identify = $"Core.GetFromTypeFullName(\"{targetType.FullName}\").SingleOrDefault()?.Dynamic()",
                    DefaultName = targetType.Name
                }
            };
        }

        static DriverIdentifyInfo[] GetIdentifyingCandidatesByControlTree(CodeDomProvider dom, Control rootCtrl, Control elementCtrl)
        {
            var names = new List<string>();
            var customNameGenerator = new DriverElementNameGeneratorAdaptor(dom);

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

            if (!ReferenceEquals(current, rootCtrl)) return null;

            var accessPath = string.Join(".", identify.ToArray());
            var name = customNameGenerator.MakeDriverPropName(elementCtrl, string.Empty, names);
            return new[]
            {
                new DriverIdentifyInfo
                {
                    IsPerfect = false,
                    Identify = "Core.Dynamic()." + accessPath,
                    DefaultName = name
                }
            };
        }

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
