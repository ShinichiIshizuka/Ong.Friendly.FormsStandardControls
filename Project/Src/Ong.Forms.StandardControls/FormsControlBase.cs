using System;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// This is the base class for classes that operate on basic controls in System.Windows.Forms.
    /// </summary>
#else
    /// <summary>
    /// FormsControlBase
    /// </summary>
#endif
    public class FormsControlBase : WindowControl
    {
#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="src">WindowControl object for the underlying control.</param>
#else
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł��B</param>
#endif
        public FormsControlBase(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
#endif
        public FormsControlBase(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

#if ENG
        /// <summary>
        /// Returns the control's text.
        /// </summary>
#else
        /// <summary>
        /// �e�L�X�g���擾���܂��B
        /// </summary>
#endif
        public string Text
        {
            get { return (string)this["Text"]().Core; }
        }

#if ENG
        /// <summary>
        /// Returns true if the item is set to visible.
        /// </summary>
#else
        /// <summary>
        /// �\��/��\�����擾���܂��B
        /// </summary>
#endif
        public bool Visible
        {
            get { return (bool)this["Visible"]().Core; }
        }

#if ENG
        /// <summary>
        /// Returns true if the control is enabled.
        /// </summary>
#else
        /// <summary>
        /// ����/�񊈐����擾���܂��B
        /// </summary>
#endif
        public bool Enabled
        {
            get { return (bool)this["Enabled"]().Core; }
        }
    }
}
