using System;
using System.IO;

namespace Test
{
    public static class Settings
    {
        /// <summary>
        /// テストアップリケーションパス
        /// </summary>
        public static String TestApplicationPath
        {
            get { return Path.GetFullPath(@"../../../FormsStandardControls.exe"); }
        }
    }
}
