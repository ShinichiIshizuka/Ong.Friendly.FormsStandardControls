using System;
using System.IO;

namespace FormsTest
{
    public static class Settings
    {
        /// <summary>
        /// �e�X�g�A�b�v���P�[�V�����p�X
        /// </summary>
        public static string TestApplicationPath
        {
            get { return Path.GetFullPath(@"../../../FormsStandardControls.exe"); }
        }
    }
}
