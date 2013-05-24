using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��System.Windows.Forms.ListBox�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
    public class FormsListBox : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł��B</param>
        public FormsListBox(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsListBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �ꗗ�̃A�C�e�������擾���܂��B
        /// </summary>
        public int ItemCount
        {
            get { return (int)(this["Items"]()["Count"]().Core); }
        }

        /// <summary>
        /// ���ݑI������Ă���A�C�e���̃C���f�b�N�X���擾���܂��B
        /// </summary>
        public int SelectedIndex
        {
            get { return (int)(this["SelectedIndex"]().Core); }
        }
        
        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂��B
        /// </summary>
        public void EmulateChangeSelectedIndex(int Index)
        {
            this["SelectedIndex"](Index);
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂��B
        /// �񓯊��Ɏ��s���܂��B
        /// </summary>
        /// <param name="Index">�C���f�b�N�X�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateChangeSelectedIndex(int Index, Async async)
        {
            this["SelectedIndex", async](Index);
        }

        /// <summary>
        /// �A�C�e�����w�肳�ꂽ�e�L�X�g�Ō������܂��B
        /// </summary>
        /// <param name="ItemText">�e�m�[�h�̃e�L�X�g</param>
        /// <returns>�������ꂽ�m�[�h�̃A�C�e���n���h���B����������null���Ԃ�܂��B</returns>
        public int FindListIndex(string ItemText)
        {
            return (int)(this["FindString"](ItemText).Core);
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="isSelect">�I����Ԃɂ���ꍇ��true��ݒ肵�܂��B</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g</param>
        public void EmulateChangeSelectedState(int index, bool isSelect, Async async)
        {
            App[GetType(), "ChangeSelectedIndexesTarget", async](AppVar, index, isSelect);
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="isSelect">�I����Ԃɂ���ꍇ��true��ݒ肵�܂��B</param>
        public void EmulateChangeSelectedState(int index, bool isSelect)
        {
            App[GetType(), "ChangeSelectedStateTarget"](AppVar, index, isSelect);
        }

        /// <summary>
        /// ���X�g�A�C�e���I���i�����j�B
        /// </summary>
        /// <param name="listbox">ListBox�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="state">�I����Ԃɂ���ꍇ��true��ݒ肵�܂��B</param>
        private static void ChangeSelectedStateTarget(ListBox listbox, int index, bool isSelect)
        {
            listbox.SetSelected(index, isSelect);
        }

        /// <summary>
        /// �I����Ԃ̃��X�g���ڈꗗ���擾���܂��B
        /// </summary>
        public int[] SelectedIndexes
        {
            get { return (int[])(App[GetType(), "GetSelectedIndexesTarget"](AppVar).Core); }
        }

        /// <summary>
        /// ���X�g�A�C�e���I���i�����j�B
        /// </summary>
        /// <param name="listbox">���X�g�{�b�N�X</param>
        private static int[] GetSelectedIndexesTarget(ListBox listbox)
        {
            List<int> list = new List<int>();
            ListBox.SelectedIndexCollection collection = listbox.SelectedIndices;
            for (int itemIndex = 0; itemIndex < collection.Count; itemIndex++)
            {
                list.Add(collection[itemIndex]);
            }
            return list.ToArray();
        }

        /// <summary>
        /// �I�����[�h���擾���܂��B
        /// </summary>
        public SelectionMode SelectionMode
        {
            get { return (SelectionMode)(this["SelectionMode"]().Core); }
        }

    }
}
