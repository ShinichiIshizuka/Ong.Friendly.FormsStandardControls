using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Collections.Generic;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��System.Windows.Forms.ListView�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
    public class FormsListView : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł��B</param>
        public FormsListView(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsListView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �񐔂��擾���܂��B
        /// </summary>
        public int ColumnCount
        {
            get { return (int)(this["Columns"]()["Count"]().Core); }
        }

        /// <summary>
        /// �A�C�e�������擾���܂��B
        /// </summary>
        public int ItemCount
        {
            get { return (int)(this["Items"]()["Count"]().Core); }
        }

        /// <summary>
        /// �I�����ꂽ�C���f�b�N�X�̈ꗗ���擾���܂��B
        /// </summary>
        public int[] SelectIndexes
        {
            get { return (int[])(App[GetType(), "GetSelectedIndexesInTarget"](AppVar).Core); } 
        }
        
        /// <summary>
        /// �I�����ꂽ�C���f�b�N�X�̈ꗗ���擾���܂��i�����j�B
        /// </summary>
        /// <param name="listview">���X�g�r���[</param>
        /// <returns>�I�����ꂽ�C���f�b�N�X�ꗗ�B</returns>
        private static int[] GetSelectedIndexesInTarget(ListView listview)
        {
            List<int> list = new List<int>();
            for (int itemIndex = 0; itemIndex < listview.Items.Count; itemIndex++)
            {
                if (listview.Items[itemIndex].Selected == true)
                {
                    list.Add(itemIndex);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// �w�肵���C���f�b�N�X�̃A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <returns>�w�肵���C���f�b�N�X�̃A�C�e���B</returns>
        public FormsListViewItem GetListViewItem(int index)
        {
            return new FormsListViewItem(App, this["Items"]()["[]"](index));
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e���̑I����Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="isSelect">�I����Ԃɂ���ꍇ��true��ݒ肵�܂��B</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g</param>
        public void EmulateChangeSelectedState(int index, bool isSelect, Async async)
        {
            App[GetType(), "ChangeSelectedIndexesInTarget", async](AppVar, index, isSelect);
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e���̑I����Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="isSelect">�I����Ԃɂ���ꍇ��true��ݒ肵�܂��B</param>
        public void EmulateChangeSelectedState(int index, bool isSelect)
        {
            App[GetType(), "ChangeSelectedStateTarget"](AppVar, index, isSelect);
        }

        /// <summary>
        /// ���X�g�r���[�A�C�e���I���i�����j�B
        /// </summary>
        /// <param name="listview">���X�g�r���[�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="isSelect">�I����Ԃɂ���ꍇ��true��ݒ肵�܂��B</param>
        private static void ChangeSelectedIndexesInTarget(ListView listview, int index, bool isSelect)
        {
            listview.Items[index].Selected = isSelect;
        }

        /// <summary>
        /// �w�肵���e�L�X�g�l�Ŏn�܂�ŏ��̃A�C�e�����������܂��B
        /// </summary>
        /// <param name="itemText">�e�L�X�g�B</param>
        /// <param name="includeSubItemsInSearch">�����ɃT�u���ڂ��܂߂�ꍇ�� true�B����ȊO�̏ꍇ�� false�B</param>
        /// <param name="startIndex">�������J�n����ʒu�̍��ڂ̃C���f�b�N�X�B</param>
        /// <returns>�w�肵���e�L�X�g�l�Ŏn�܂�ŏ��̃A�C�e��</returns>
        public FormsListViewItem FindItemWithText(string itemText, bool includeSubItemsInSearch, int startIndex)
        {
            AppVar returnItem = this["FindItemWithText"](itemText, includeSubItemsInSearch, startIndex);
            if (returnItem != null)
            {
                return new FormsListViewItem(App, returnItem);
            }
            return null;
        }

        /// <summary>
        /// View���[�h���擾���܂��B
        /// </summary>
        public View ViewMode
        {
            get { return (View)(this["View"]().Core); } 
        }
    }
}