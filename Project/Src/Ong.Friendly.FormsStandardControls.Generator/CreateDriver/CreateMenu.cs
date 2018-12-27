using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator.CreateDriver
{
    internal class CreateMenu : IWindowAnalysisMenuAction
    {
        public Dictionary<string, MethodInvoker> GetAction(object target, WindowAnalysisTreeInfo info)
        {
            var dic = new Dictionary<string, MethodInvoker>();
            if (target is Control ctrl)
            {
                dic["Create Driver(&C)"] = () =>
                {
                    using (var dom = CodeDomProvider.CreateProvider("CSharp"))
                    {
                        new WinFormsDriverCreator(dom).CreateDriver(ctrl);
                    }
                };
            }
            return dic;
        }
    }
}
