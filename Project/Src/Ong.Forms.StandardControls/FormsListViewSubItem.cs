using System;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.Friendly.Windows;
using System.Windows.Forms;
using System.Reflection;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ���X�g�r���[�T�u�A�C�e���ł��B
    /// </summary>
    public class FormsListViewSubItem:AppVarWrapper
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsListViewSubItem(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
        }
    
        /// <summary>
        /// �e�L�X�g���擾���܂��B
        /// </summary>
        /// <returns>�e�L�X�g�B</returns>
        public String Text
        {
            get { return (String)this["Text"]().Core; }
        }
    }
}
