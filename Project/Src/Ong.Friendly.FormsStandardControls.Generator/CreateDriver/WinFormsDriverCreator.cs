using Codeer.TestAssistant.GeneratorToolKit;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls.Generator.CreateDriver
{
#if ENG
    /// <summary>
    /// Generate WinForms driver.
    /// </summary>
#else
    /// <summary>
    /// WinFormsのドライバを生成します。
    /// </summary>
#endif
    public class WinFormsDriverCreator
    {
        internal const string TodoComment = "// TODO It is not the best way to identify. Please change to a better method.";
        const string Indent = "    ";

        readonly CodeDomProvider _dom;
        readonly DriverElementNameGeneratorAdaptor _customNameGenerator;
        readonly DriverTypeNameManager _driverTypeNameManager;

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dom">CodeDomProvider.</param>
#else
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="dom">CodeDomProvider.</param>
#endif
        public WinFormsDriverCreator(CodeDomProvider dom)
        {
            _dom = dom;
            _customNameGenerator = new DriverElementNameGeneratorAdaptor(dom);
            _driverTypeNameManager = new DriverTypeNameManager(DriverCreatorAdapter.SelectedNamespace, DriverCreatorAdapter.TypeFullNameAndWindowDriver, DriverCreatorAdapter.TypeFullNameAndUserControlDriver);
        }

#if ENG
        /// <summary>
        /// Route control.
        /// </summary>
        /// <param name="root">CodeDomProvider.</param>
#else
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="root">ルートのコントロール。</param>
#endif
        public void CreateDriver(Control root)
        {
            //FormとUserControlを全取得
            var recursiveCheck = new List<Control>();
            var targets = new Dictionary<Type, Control>();
            var getFromControlTreeOnly = new List<Type>();
            GetAllFormAndUserControl(true, false, root, targets, getFromControlTreeOnly, recursiveCheck);

            //ドライバ情報を取得
            var driverInfos = new Dictionary<Type, DriverInfo<Control>>();
            foreach (var e in targets)
            {
                var fileName = $"{_driverTypeNameManager.MakeDriverType(e.Value)}.cs";
                var info = CreateDriverInfo(e.Value, fileName);
                driverInfos[e.Key] = info;
            }

            //コード生成
            foreach (var e in driverInfos)
            {
                var driverName = _driverTypeNameManager.MakeDriverType(e.Value.Target, out var nameSpace);
                if (string.IsNullOrEmpty(nameSpace)) nameSpace = DriverCreatorAdapter.SelectedNamespace;
                DriverCreatorAdapter.AddCode($"{driverName}.cs", GenerateCode(root, e.Value.Target, nameSpace, driverName, e.Value.Usings, e.Value.Members, getFromControlTreeOnly), e.Value.Target);
            }
        }

        /// <summary>
        /// Route control.
        /// </summary>
        /// <param name="root">CodeDomProvider.</param>
        public void CreateControlDriver(Control root)
        {
            var driverName = root.GetType().Name + "Driver";
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
            DriverCreatorAdapter.AddCode($"{driverName}.cs", driverCode.Replace("{typefullname}", root.GetType().FullName).Replace("{driverName}", driverName), root);

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
            DriverCreatorAdapter.AddCode($"{generatorName}.cs", generatorCode.Replace("{generatorName}", generatorName).Replace("{driverName}", driverName), root);
        }

        void GetAllFormAndUserControl(bool isRoot, bool isControlTreeOnly, Control control, IDictionary<Type, Control> targets, IList<Type> getFromControlTreeOnly, IList<Control> recursiveCheck)
        {
            if (control == null) return;

            //ルート以外はすでに割り当てがあれば再生成しないようにする
            var addToTarget = true;
            if (!isRoot)
            {
                if (!string.IsNullOrEmpty(DriverCreatorUtils.GetDriverTypeFullName(control, DriverCreatorAdapter.TypeFullNameAndControlDriver)) ||
                    !string.IsNullOrEmpty(DriverCreatorUtils.GetDriverTypeFullName(control, DriverCreatorAdapter.TypeFullNameAndWindowDriver)) ||
                    !string.IsNullOrEmpty(DriverCreatorUtils.GetDriverTypeFullName(control, DriverCreatorAdapter.TypeFullNameAndUserControlDriver)))
                {
                    addToTarget = false;
                }
            }

            //再帰チェック
            if (CollectionUtility.HasReference(recursiveCheck, control)) return;
            recursiveCheck.Add(control);

            if ((control is Form) || (control is UserControl))
            {
                if (addToTarget)
                {
                    targets[control.GetType()] = control;
                    if (isControlTreeOnly)
                    {
                        getFromControlTreeOnly.Add(control.GetType());
                    }
                }

                //Form, UserControlの時はメンバも見る
                foreach (var field in GetFields(control))
                {
                    GetAllFormAndUserControl(false, false, field.Control, targets, getFromControlTreeOnly, recursiveCheck);
                }
            }

            foreach (Control ctrl in control.Controls)
            {
                GetAllFormAndUserControl(false, true, ctrl, targets, getFromControlTreeOnly, recursiveCheck);
            }

            //MDI対応
            foreach (var form in (control as Form)?.MdiChildren ?? new Form[0])
            {
                GetAllFormAndUserControl(false, true, form, targets, getFromControlTreeOnly, recursiveCheck);
            }
        }

        class ControlAndDefine
        {
            public Control Control { get; }
            public string Define { get; }

            public ControlAndDefine(Control control, string define)
            {
                Control = control;
                Define = define;
            }
        }

        DriverInfo<Control> CreateDriverInfo(Control targetControl, string fileName)
        {
            var driverInfo = new DriverInfo<Control>(targetControl);

            var mappedControls = new List<Control>();
            var names = new List<string>();
            var ancesters = WindowUtilityInTarget.GetAncesters(targetControl);

            var controlAndDefines = new List<ControlAndDefine>();

            //フィールドから検索
            foreach (var field in GetFields(targetControl))
            {
                //たまにフィールドに親を持っているのがいるのではじく
                if (CollectionUtility.HasReference(ancesters, field.Control)) continue;

                //不正なフィールド名のものは取得できない
                if (!_dom.IsValidIdentifier(field.Name)) continue;

                //すでにマップされているかチェック
                if (CollectionUtility.HasReference(mappedControls, field.Control)) continue;

                //コントロールドライバ
                var driver = DriverCreatorUtils.GetDriverTypeFullName(field.Control, DriverCreatorAdapter.TypeFullNameAndControlDriver);
                if (!string.IsNullOrEmpty(driver))
                {
                    mappedControls.Add(field.Control);
                    var typeName = DriverCreatorUtils.GetTypeName(driver);
                    var nameSpace = DriverCreatorUtils.GetTypeNamespace(driver);
                    var name = _customNameGenerator.MakeDriverPropName(field.Control, field.Name, names);
                    var key = $"Core.Dynamic().{field.Name}";
                    controlAndDefines.Add(new ControlAndDefine(field.Control, $"public {typeName} {name} => {key};"));
                    DriverCreatorAdapter.AddCodeLineSelectInfo(fileName, key, field.Control);
                    if (!driverInfo.Usings.Contains(nameSpace)) driverInfo.Usings.Add(nameSpace);
                }
                //ユーザーコントロールドライバ
                else if (field.Control is UserControl)
                {
                    mappedControls.Add(field.Control);
                    var name = _customNameGenerator.MakeDriverPropName(field.Control, field.Name, names);
                    names.Add(name);
                    var typeName = _driverTypeNameManager.MakeDriverType(field.Control, out var nameSpace);
                    if (!string.IsNullOrEmpty(nameSpace) && (nameSpace != DriverCreatorAdapter.SelectedNamespace) && !driverInfo.Usings.Contains(nameSpace)) driverInfo.Usings.Add(nameSpace);
                    var key = $"Core.Dynamic().{field.Name}";
                    controlAndDefines.Add(new ControlAndDefine(field.Control, $"public {typeName} {name} => {key};"));
                    DriverCreatorAdapter.AddCodeLineSelectInfo(fileName, key, field.Control);
                }
            }

            //フィールド上に現れないオブジェクトを検索
            CreateDriverInfoFindFromControlTree(-1, targetControl, targetControl, driverInfo, controlAndDefines, mappedControls, names, new int[0], fileName);

            //Sortのロジックがイマイチわかっていない。念のため
            try
            {
                // タブオーダー順のコントロールリスト取得
                var controlList = GetTabOrderChildControls(targetControl);

                // フィールドをタブオーダーでソート
                controlAndDefines.Sort((l, r) => controlList.IndexOf(l.Control) - controlList.IndexOf(r.Control));
            }
            catch { }

            foreach (var e in controlAndDefines)
            {
                driverInfo.Members.Add(e.Define);
            }

            return driverInfo;
        }

        void CreateDriverInfoFindFromControlTree(
            int mdiChildrenIndex,
            Control root,
            Control target,
            DriverInfo<Control> driverInfo,
            IList<ControlAndDefine> controlAndDefines,
            IList<Control> mappedControls,
            IList<string> names,
            int[] controlTreeIndecies,
            string fileName)
        {
            var next = new List<int>(controlTreeIndecies) { 0 };
            for (int i = 0; i < target.Controls.Count; i++)
            {
                next[next.Count - 1] = i;
                var ctrl = target.Controls[i];

                //すでにマップされているかチェック
                if (CollectionUtility.HasReference(mappedControls, ctrl)) continue;

                //コントロールドライバ検索
                var driver = DriverCreatorUtils.GetDriverTypeFullName(ctrl, DriverCreatorAdapter.TypeFullNameAndControlDriver);
                if (!string.IsNullOrEmpty(driver))
                {
                    var name = _customNameGenerator.MakeDriverPropName(ctrl, string.Empty, names);
                    var typeName = DriverCreatorUtils.GetTypeName(driver);
                    var nameSpace = DriverCreatorUtils.GetTypeNamespace(driver);
                    var getter = MakeCodeGetFromControls(mdiChildrenIndex, root, ctrl.GetType(), next, out var nogood);

                    DriverCreatorAdapter.AddCodeLineSelectInfo(fileName, getter, ctrl);

                    var code = $"public {typeName} {name} => new {typeName}({getter});";
                    if (nogood)
                    {
                        code += $" {TodoComment}";
                    }
                    controlAndDefines.Add(new ControlAndDefine(ctrl, code));
                    mappedControls.Add(ctrl);
                    if (!driverInfo.Usings.Contains(nameSpace)) driverInfo.Usings.Add(nameSpace);
                }
                else if (!(ctrl is UserControl))
                {
                    //さらに下の階層を検索
                    CreateDriverInfoFindFromControlTree(mdiChildrenIndex, root, ctrl, driverInfo, controlAndDefines, mappedControls, names, next.ToArray(), fileName);
                }
            }
        }

        static List<Control> GetTabOrderChildControls(Control targetControl)
        {
            var allControls = new List<Control>();
            var currentControl = targetControl;
            while (true)
            {
                var nextControl = targetControl.GetNextControl(currentControl, true);
                if (nextControl == null) return allControls;

                //念のため一周しても終わり
                if (allControls.Contains(nextControl)) return allControls;

                //タブストップのないコントロールはスルー
                if (nextControl.TabStop)
                {
                    allControls.Add(nextControl);
                }

                currentControl = nextControl;
            }
        }

        static string MakeCodeGetFromControls(int mdiChildrenIndex, Control root, Type type, List<int> next, out bool nogood)
        {
            nogood = false;
            var decendants = new List<Control>();
            WindowUtilityInTarget.GetDecendants(root, decendants);
            int cnt = 0;
            foreach (var e in decendants)
            {
                if (type.IsAssignableFrom(e.GetType())) cnt++;
            }
            if (cnt == 1)
            {
                return $"Core.IdentifyFromTypeFullName(\"{type.FullName}\")";
            }

            nogood = true;
            var code = "Core.Dynamic()";
            if (mdiChildrenIndex != -1)
            {
                code += $".MdiChildren[{mdiChildrenIndex}]";
            }
            foreach (var i in next)
            {
                code += $".Controls[{i}]";
            }
            return code;
        }

        internal string GenerateCode(Control root, Control targetControl, string nameSpace, string driverClassName, List<string> usings, List<string> members, List<Type> getFromControlTreeOnly)
        {
            var code = new List<string>
            {
                "using Codeer.Friendly;",
                "using Codeer.Friendly.Dynamic;",
                "using Codeer.Friendly.Windows;",
                "using Codeer.Friendly.Windows.Grasp;",
                "using Codeer.TestAssistant.GeneratorToolKit;"
            };
            foreach (var e in usings)
            {
                code.Add($"using {e};");
            }
            int nextUsingIndex = code.Count;

            var existMany = false;
            if (getFromControlTreeOnly.Contains(targetControl.GetType()))
            {
                int checkCount = 0;
                existMany = WindowUtilityInTarget.ExistMany(root, targetControl.GetType(), ref checkCount);
                if (existMany)
                {
                    code.Add("using System.Linq;");
                }
            }

            var attr = (targetControl is Form) ? "WindowDriver" : "UserControlDriver";

            code.Add(string.Empty);
            code.Add($"namespace {nameSpace}");
            code.Add("{");
            code.Add($"{Indent}[{attr}(TypeFullName = \"{targetControl.GetType().FullName}\")]");
            code.Add($"{Indent}public class {driverClassName}");
            code.Add($"{Indent}{{");
            code.Add($"{Indent}{Indent}public WindowControl Core {{ get; }}");
            foreach (var e in members)
            {
                code.Add($"{Indent}{Indent}{e}");
            }
            code.Add(string.Empty);
            code.Add($"{Indent}{Indent}public {driverClassName}(WindowControl core)");
            code.Add($"{Indent}{Indent}{{");
            code.Add($"{Indent}{Indent}{Indent}Core = core;");
            code.Add($"{Indent}{Indent}}}");

            code.Add(string.Empty);
            code.Add($"{Indent}{Indent}public {driverClassName}(AppVar core)");
            code.Add($"{Indent}{Indent}{{");
            code.Add($"{Indent}{Indent}{Indent}Core = new WindowControl(core);");
            code.Add($"{Indent}{Indent}}}");
            code.Add($"{Indent}}}");

            if (getFromControlTreeOnly.Contains(targetControl.GetType()))
            {
                code.Add(string.Empty);
                code.Add($"{Indent}public static class {driverClassName}_Extensions");
                code.Add($"{Indent}{{");
                var funcName = GetFuncName(driverClassName);
                var rootDriver = _driverTypeNameManager.MakeDriverType(root, out var rootNameSpace);
                if (!string.IsNullOrEmpty(rootNameSpace) && !usings.Contains(rootNameSpace) && (rootNameSpace != nameSpace))
                {
                    code.Insert(nextUsingIndex, $"using {rootNameSpace};");
                }
                if (existMany)
                {
                    code.Add($"{Indent}{Indent}{TodoComment}");
                    code.Add($"{Indent}{Indent}[UserControlDriverIdentify(CustomMethod = \"TryGet\")]");
                    code.Add($"{Indent}{Indent}public static {driverClassName} {funcName}(this {rootDriver} window, int index)");
                    code.Add($"{Indent}{Indent}{Indent}=> new {driverClassName}(new WindowControl(window.Core.GetFromTypeFullName(\"{targetControl.GetType().FullName}\")[index]));");
                    code.Add(string.Empty);
                    code.Add($"{Indent}{Indent}public static void TryGet(this {rootDriver} window, out int[] indices)");
                    code.Add($"{Indent}{Indent}{Indent}=> indices = Enumerable.Range(0, window.Core.GetFromTypeFullName(\"{targetControl.GetType().FullName}\").Length).ToArray();");
                }
                else
                {
                    code.Add($"{Indent}{Indent}[UserControlDriverIdentify]");
                    code.Add($"{Indent}{Indent}public static {driverClassName} {funcName}(this {rootDriver} window)");
                    code.Add($"{Indent}{Indent}{Indent}=> new {driverClassName}(new WindowControl(window.Core.IdentifyFromTypeFullName(\"{targetControl.GetType().FullName}\")));");
                }
                code.Add($"{Indent}}}");
            }
            else if (targetControl is Form)
            {
                code.Add(string.Empty);
                code.Add($"{Indent}public static class {driverClassName}_Extensions");
                code.Add($"{Indent}{{");
                code.Add($"{Indent}{Indent}[WindowDriverIdentify(TypeFullName = \"{targetControl.GetType().FullName}\")]");
                code.Add($"{Indent}{Indent}public static {driverClassName} {GetFuncName(driverClassName)}(this WindowsAppFriend app)");
                code.Add($"{Indent}{Indent}{Indent}=> new {driverClassName}(app.WaitForIdentifyFromTypeFullName(\"{targetControl.GetType().FullName}\"));");
                code.Add($"{Indent}}}");
            }
            code.Add("}");
            return string.Join(Environment.NewLine, code.ToArray());
        }

        static string GetFuncName(string driverClassName)
        {
            return $"Attach_{driverClassName.Substring(0, driverClassName.Length - DriverCreatorUtils.Suffix.Length)}";
        }

        static ControlAndFieldName<Control>[] GetFields(object obj)
            => DriverCreatorUtils.GetFields<Control>(obj, typeof(Form), typeof(UserControl), typeof(Control));
    }
}
