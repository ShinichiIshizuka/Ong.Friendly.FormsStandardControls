﻿using System.Reflection;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator.CreateDriver
{
    static class ControlPicker
    {
        internal static void PickupChildren(Control ctrl)
        {
            foreach (Control e in ctrl.Controls)
            {
                var driver = DriverCreatorUtils.GetDriverTypeFullName(e, DriverCreatorAdapter.TypeFullNameAndControlDriver, DriverCreatorAdapter.TypeFullNameAndUserControlDriver, DriverCreatorAdapter.TypeFullNameAndWindowDriver, out var searchDescendantUserControls);
                if (!string.IsNullOrEmpty(driver))
                {
                    DriverCreatorAdapter.AddDriverElements(e);
                }
                if (searchDescendantUserControls && !(e is UserControl) && !(e is Form))
                {
                    PickupChildren(e);
                }
            }

            //ContextMenu
            foreach (var e in ctrl.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (typeof(ToolStrip).IsAssignableFrom(e.FieldType))
                {
                    DriverCreatorAdapter.AddDriverElements(e.GetValue(ctrl));
                }
            }
        }
    }
}
