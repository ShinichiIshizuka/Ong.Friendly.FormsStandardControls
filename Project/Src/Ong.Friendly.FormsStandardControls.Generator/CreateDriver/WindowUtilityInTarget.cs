using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls.Generator.CreateDriver
{
    internal static class WindowUtilityInTarget
    {
        public static Control[] GetAncesters(Control targetControl)
        {
            var ancesters = new List<Control> { targetControl };
            var parent = targetControl.Parent;
            while (parent != null)
            {
                ancesters.Add(parent);
                parent = parent.Parent;
            }
            return ancesters.ToArray();
        }

        public static void GetDecendants(Control ctrl, IList<Control> decendants)
        {
            decendants.Add(ctrl);
            foreach (Control c in ctrl.Controls)
            {
                GetDecendants(c, decendants);
            }
        }

        public static bool ExistMany(Control root, Type type, ref int count)
        {
            if (root.GetType() == type) count++;
            if (1 < count) return true;
            foreach (Control c in root.Controls)
            {
                if (ExistMany(c, type, ref count)) return true;
            }
            return false;
        }
    }
}
