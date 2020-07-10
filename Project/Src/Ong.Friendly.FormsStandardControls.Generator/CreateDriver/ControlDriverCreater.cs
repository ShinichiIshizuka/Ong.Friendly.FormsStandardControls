using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator.CreateDriver
{
    static class ControlDriverCreater
    {
        internal static void Create(Control control)
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
    }
}
