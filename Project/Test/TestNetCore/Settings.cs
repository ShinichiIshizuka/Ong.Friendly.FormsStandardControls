using System;
using System.IO;

namespace TestNetCore
{
    public static class Settings
    {
        /// <summary>
        /// �e�X�g�A�b�v���P�[�V�����p�X
        /// </summary>
        public static string TestApplicationPath
        {
            get { return Path.GetFullPath(@"../../../../WinFormsApp/bin/Debug/net8.0-windows/WinFormsApp.exe"); }
        }
    }
}
