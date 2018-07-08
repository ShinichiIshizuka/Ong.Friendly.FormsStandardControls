using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetWindowTextLength(IntPtr hWnd);

        internal static string GetWindowText(IntPtr handle)
        {
            int len = NativeMethods.GetWindowTextLength(handle);
            StringBuilder builder = new StringBuilder((len + 1) * 8);
            NativeMethods.GetWindowText(handle, builder, len * 8);
            return builder.ToString();
        }
    }
}
