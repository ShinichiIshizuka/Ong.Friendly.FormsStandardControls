using Codeer.Friendly;
using Codeer.Friendly.Windows;
using System;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Represents a sub-item in a list view.
    /// </summary>
#else
    /// <summary>
    /// ���X�g�r���[�T�u�A�C�e���ł��B
    /// </summary>
#endif
    public class FormsListViewSubItem : AppVarWrapper
    {
#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsListViewSubItem(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// ���ݔ񐄏��ł��B
        /// FormsListViewSubItem(AppVar windowObject)���g�p���Ă��������B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
#endif
        [Obsolete("Please use FormsListViewSubItem(AppVar windowObject).", false)]
        public FormsListViewSubItem(WindowsAppFriend app, AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
#endif
        public FormsListViewSubItem(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the sub-item's text.
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
    }
}
