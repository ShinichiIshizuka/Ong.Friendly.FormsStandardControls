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
        public int Priority { get; }

        public bool CanDesign(object obj) => obj is Control;

        public string CreateDriverClassName(object coreObj)
        {
            var driverTypeNameManager = new DriverTypeNameManager(DriverCreatorAdapter.SelectedNamespace, DriverCreatorAdapter.TypeFullNameAndWindowDriver, DriverCreatorAdapter.TypeFullNameAndUserControlDriver);
            return driverTypeNameManager.MakeDriverType(coreObj, out var _);
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
            var driverTypeNameManager = new DriverTypeNameManager(DriverCreatorAdapter.SelectedNamespace, DriverCreatorAdapter.TypeFullNameAndWindowDriver, DriverCreatorAdapter.TypeFullNameAndUserControlDriver);
            var root = FindRoot((Control)targetControl, driverTypeNameManager);
            GetMembers(info, out var usings, out var members);
            var fileName = $"{info.ClassName}.cs";

            var getFromControlTreeOnly = new List<Type>();
            if (info.CreateAttachCode)
            {
                getFromControlTreeOnly.Add(targetControl.GetType());
            }

            using (var dom = CodeDomProvider.CreateProvider("CSharp"))
            {
                var creator = new WinFormsDriverCreator(dom);
                var code = creator.GenerateCode(root, (Control)targetControl, DriverCreatorAdapter.SelectedNamespace, info.ClassName, usings, members, getFromControlTreeOnly);

                DriverCreatorAdapter.AddCode(fileName, code, targetControl);
            }

            //選択のための情報を設定
            foreach (var e in info.Properties)
            {
                DriverCreatorAdapter.AddCodeLineSelectInfo(fileName, e.Identify, e.Element);
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
                    Identify = $"Core.IdentifyFromTypeFullName(\"{targetType.FullName}\").Dynamic()",
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
                var todo = (e.IsPerfect.HasValue && !e.IsPerfect.Value) ? WinFormsDriverCreator.TodoComment : string.Empty;

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
