using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// WindowControl��System.Windows.Forms.CheckListBox�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsCheckedListBox : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsCheckedListBox(FormsControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsCheckedListBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂�
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <param name="value">�`�F�b�N���</param>
        public void EmulateCheckState(int index,CheckState value)
        {
            this["SetItemCheckState"](index, value);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <param name="value">�`�F�b�N���</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateCheckState(int index ,CheckState value, Async async)
        {
            this["SetItemCheckState", async](index, value);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ��擾���܂�
        /// </summary>
        /// <returns>�`�F�b�N���</returns>
        public CheckState GetCheckState(int index)
        {
            return (CheckState)(this["GetCheckState"](index).Core);
        }

        /// <summary>
        /// �ꗗ�̃A�C�e�������擾���܂�
        /// </summary>
        public int ItemCount
        {
            get 
            {
                return (int)(this["Items"]()["Count"]().Core);
            }
        }

        /// <summary>
        /// ���ݑI������Ă���A�C�e���̃C���f�b�N�X���擾���܂�
        /// </summary>
        public int SelectedItemIndex
        {
            get
            {
                return (int)(this["SelectedIndex"]().Core);
            }
        }

        /// <summary>
        /// ���݃`�F�b�N����Ă���A�C�e���̃C���f�b�N�X��z��Ŏ擾���܂�
        /// </summary>
        public int[] CheckedIndices
        {
            get
            {
                return (int[])(App[GetType(), "CheckedIndicsInTarget"](AppVar).Core);
            }
        }

        /// <summary>
        /// ���݃`�F�b�N����Ă���A�C�e���̃C���f�b�N�X��z��Ŏ擾���܂�(����)
        /// </summary>
        /// <param name="checkedListBox">�Ώۂ̃`�F�b�N���X�g�{�b�N�X</param>
        /// <returns></returns>
        private static int[] CheckedIndicsInTarget(CheckedListBox checkedListBox)
        {
            List<int> checkedlist = new List<int>();
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    checkedlist.Add(i);
                }
            }
            return checkedlist.ToArray();
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂�
        /// </summary>
        public void EmulateChangeSelectedIndex(int Index)
        {
            this["SelectedIndex"](Index);
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂�
        /// �񓯊��Ɏ��s���܂�
        /// </summary>
        /// <param name="Index">�C���f�b�N�X</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateChangeSelectedIndex(int Index, Async async)
        {
            this["SelectedIndex", async](Index);
        }

        /// <summary>
        /// �A�C�e�����w�肳�ꂽ�e�L�X�g�Ō������܂�
        /// </summary>
        /// <param name="ItemText">�e�m�[�h�̃e�L�X�g</param>
        /// <returns>�������ꂽ�m�[�h�̃A�C�e���n���h���B����������null���Ԃ�܂�</returns>
        public int FindListIndex(string ItemText)
        {
            return (int)(this["FindString"](ItemText).Core);
        }
    }
}
