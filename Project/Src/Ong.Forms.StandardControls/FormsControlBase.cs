using System;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// FormsControlBase
    /// </summary>
    public class FormsControlBase : WindowControl
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł��B</param>
        public FormsControlBase(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsControlBase(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }
        
        /// <summary>
        /// �e�L�X�g���擾���܂��B
        /// </summary>
        /// <returns>�e�L�X�g�B</returns>
        public string Text
        {
            get { return (string)this["Text"]().Core; }
        }

        /// <summary>
        /// �\��/��\����؂�ւ��܂��B
        /// </summary>
        public bool Visible
        {
            get { return (bool)this["Visible"]().Core; }
        }

        /// <summary>
        /// ����/�񊈐���؂�ւ��܂��B
        /// </summary>
        public bool Enabled
        {
            get { return (bool)this["Enabled"]().Core; }
        }
    }
}
