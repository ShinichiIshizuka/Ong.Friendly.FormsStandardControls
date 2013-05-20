using System;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.Friendly.Windows;
using System.Windows.Forms;
using System.Reflection;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ���X�g�A�C�e��
    /// </summary>
    public class FormsListViewItem:AppVarWrapper
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsListViewItem(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
        }
    
        /// <summary>
        /// �e�L�X�g���擾���܂�
        /// </summary>
        /// <returns>�e�L�X�g</returns>
        public String Text
        {
            get { return (String)this["Text"]().Core; }
        }

        /// <summary>
        /// �s���擾���܂�
        /// </summary>
        /// <returns>�s�ԍ�</returns>
        public int RowIndex
        {
            get { return (int)this["Index"]().Core; }
        }

        public bool Checked
        {
            get { return (bool)this["Checked"]().Core; }
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂�
        /// </summary>
        /// <param name="value">�`�F�b�N���</param>
        public void EmulateCheck(bool value)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, value);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="value">�`�F�b�N���</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateCheck(bool value, Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar, value);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂�
        /// </summary>
        /// <param name="listviewitem">���X�g�r���[�A�C�e��</param>
        /// <param name="value">�`�F�b�N���</param>
        static void EmulateCheckInTarget(ListViewItem listviewitem, bool value)
        {
            listviewitem.Checked = value;
        }
    }
}
