using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator.CreateDriver
{
    internal class AnalyzeMenu : IWindowAnalysisMenuAction
    {
        public Dictionary<string, MenuAction> GetAction(object target, WindowAnalysisTreeInfo info)
        {
            var dic = new Dictionary<string, MenuAction>();
            if (target is Control)
            {
                dic["Pickup Children(&P)"] = () => ControlPicker.PickupChildren((Control)target);
                dic["Create Control Driver(&D)"] = () => DriverDesigner.CreateControlDriver((Control)target);
                dic["Show Base Class(&B)"] = () =>
                {
                    AnalyzeWindow.Output.Show();
                    var type = target.GetType();
                    AnalyzeWindow.Output.WriteLine(string.Empty);
                    while (type != null)
                    {
                        AnalyzeWindow.Output.WriteLine(type.FullName);
                        type = type.BaseType;
                    }
                };
            }
            return dic;
        }
    }
}
