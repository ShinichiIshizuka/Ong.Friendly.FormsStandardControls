using Codeer.Friendly;
using Codeer.Friendly.Windows;

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
        public FormsListViewSubItem(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

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
