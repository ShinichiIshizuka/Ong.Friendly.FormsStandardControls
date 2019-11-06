using Codeer.TestAssistant.GeneratorToolKit;
using System.Collections.Generic;

namespace Ong.Friendly.FormsStandardControls.Generator.CreateDriver
{
    internal class DriverTypeNameManager
    {
        string _selectedNamespace;
        Dictionary<string, WindowDriverInfo> _typeFullNameAndWindowDriver;
        Dictionary<string, UserControlDriverInfo> _typeFullNameAndUserControDriver;

        internal DriverTypeNameManager(string selectedNamespace, Dictionary<string, WindowDriverInfo> typeFullNameAndWindowDriver, Dictionary<string, UserControlDriverInfo> typeFullNameAndUserControDriver)
        {
            _selectedNamespace = selectedNamespace;
            _typeFullNameAndWindowDriver = new Dictionary<string, WindowDriverInfo>(typeFullNameAndWindowDriver);
            _typeFullNameAndUserControDriver = new Dictionary<string, UserControlDriverInfo>(typeFullNameAndUserControDriver);
        }

        internal string MakeDriverType(object control)
            => MakeDriverType(control, out _);

        internal string MakeDriverType(object control, out string nameSpace)
        {
            nameSpace = string.Empty;
            if (_typeFullNameAndWindowDriver.TryGetValue(control.GetType().FullName, out var windowDriverInfo))
            {
                nameSpace = DriverCreatorUtils.GetTypeNamespace(windowDriverInfo.DriverTypeFullName);
                return DriverCreatorUtils.GetTypeName(windowDriverInfo.DriverTypeFullName);
            }
            else if (_typeFullNameAndUserControDriver.TryGetValue(control.GetType().FullName, out var userControlDriverInfo))
            {
                nameSpace = DriverCreatorUtils.GetTypeNamespace(userControlDriverInfo.DriverTypeFullName);
                return DriverCreatorUtils.GetTypeName(userControlDriverInfo.DriverTypeFullName);
            }
            var name = control.GetType().Name + DriverCreatorUtils.Suffix;
            var fullName = _selectedNamespace + "." + name;

            var nameList = new List<string>();
            foreach (var e in _typeFullNameAndWindowDriver)
            {
                nameList.Add(e.Value.DriverTypeFullName);
            }
            foreach (var e in _typeFullNameAndUserControDriver)
            {
                nameList.Add(e.Value.DriverTypeFullName);
            }

            int index = 1;
            while (nameList.Contains(fullName))
            {
                name = control.GetType().Name + DriverCreatorUtils.Suffix + index++;
                fullName = _selectedNamespace + "." + name;
            }

            _typeFullNameAndWindowDriver[control.GetType().FullName] = new WindowDriverInfo { DriverTypeFullName = fullName };
            return name;
        }
    }
}
