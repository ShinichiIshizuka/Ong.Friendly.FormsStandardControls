using System.Windows.Forms;
using System.Collections.Generic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.ListView.
    /// </summary>
#else
    /// <summary>
    /// Type��System.Windows.Forms.ListView�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
#endif
    public class FormsListView : FormsControlBase
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
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���B</param>
#endif
        public FormsListView(WindowControl src)
            : base(src) { }

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
        public FormsListView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Returns the control's View Mode.
        /// </summary>
#else
        /// <summary>
        /// View���[�h���擾���܂��B
        /// </summary>
#endif
        public View ViewMode
        {
            get { return (View)(this["View"]().Core); }
        }

#if ENG
        /// <summary>
        /// Returns the number of columns.
        /// </summary>
#else
        /// <summary>
        /// �񐔂��擾���܂��B
        /// </summary>
#endif
        public int ColumnCount
        {
            get { return (int)(this["Columns"]()["Count"]().Core); }
        }

#if ENG
        /// <summary>
        /// Returns the number of items.
        /// </summary>
#else
        /// <summary>
        /// �A�C�e�������擾���܂��B
        /// </summary>
#endif
        public int ItemCount
        {
            get { return (int)(this["Items"]()["Count"]().Core); }
        }

#if ENG
        /// <summary>
        /// Returns a list of the selected index.
        /// </summary>
#else
        /// <summary>
        /// �I�����ꂽ�C���f�b�N�X�̈ꗗ���擾���܂��B
        /// </summary>
#endif
        public int[] SelectIndexes
        {
            get { return (int[])(App[GetType(), "GetSelectedIndexesInTarget"](AppVar).Core); } 
        }

#if ENG
        /// <summary>
        /// Retrieves the item at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Item at the specified index.</returns>
#else
        /// <summary>
        /// �w�肵���C���f�b�N�X�̃A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <returns>�w�肵���C���f�b�N�X�̃A�C�e���B</returns>
#endif
        public FormsListViewItem GetListViewItem(int index)
        {
            return new FormsListViewItem(App, this["Items"]()["[]"](index));
        }

#if ENG
        /// <summary>
        /// Finds the first item whose text begins with the specified value.
        /// </summary>
        /// <param name="itemText">Text to search for.</param>
        /// <param name="includeSubItemsInSearch">True to include sub-items in the search. Otherwise, false.</param>
        /// <param name="startIndex">The index of the item at which to start the search.</param>
        /// <returns>The first found item whose text begins with the specified text value.</returns>
#else
        /// <summary>
        /// �w�肵���e�L�X�g�l�Ŏn�܂�ŏ��̃A�C�e�����������܂��B
        /// </summary>
        /// <param name="itemText">�e�L�X�g�B</param>
        /// <param name="includeSubItemsInSearch">�����ɃT�u���ڂ��܂߂�ꍇ�� true�B����ȊO�̏ꍇ�� false�B</param>
        /// <param name="startIndex">�������J�n����ʒu�̍��ڂ̃C���f�b�N�X�B</param>
        /// <returns>�w�肵���e�L�X�g�l�Ŏn�܂�ŏ��̃A�C�e��</returns>
#endif
        public FormsListViewItem FindItemWithText(string itemText, bool includeSubItemsInSearch, int startIndex)
        {
            AppVar returnItem = this["FindItemWithText"](itemText, includeSubItemsInSearch, startIndex);
            if ((bool)App[GetType(), "ReferenceEquals"](returnItem, null).Core)
            {
                return null;
            }
            return new FormsListViewItem(App, returnItem);
        }

#if ENG
        /// <summary>
        /// Sets the selection state of the item with the specified index.
        /// </summary>
        /// <param name="index">Index of the item to change.</param>
        /// <param name="isSelect">The selection state (true to select).</param>
#else
        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e���̑I����Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="isSelect">�I����Ԃɂ���ꍇ��true��ݒ肵�܂��B</param>
#endif
        public void EmulateChangeSelectedState(int index, bool isSelect)
        {
            App[GetType(), "EmulateChangeSelectedStateInTarget"](AppVar, index, isSelect);
        }

#if ENG
        /// <summary>
        /// Sets the selection state of the item with the specified index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Index of the item to change.</param>
        /// <param name="isSelect">The selection state (true to select).</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e���̑I����Ԃ�ύX���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="isSelect">�I����Ԃɂ���ꍇ��true��ݒ肵�܂��B</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g�B</param>
#endif
        public void EmulateChangeSelectedState(int index, bool isSelect, Async async)
        {
            App[GetType(), "EmulateChangeSelectedStateInTarget", async](AppVar, index, isSelect);
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
        /// ���X�g�r���[�A�C�e����I�����܂��i�����j�B
        /// </summary>
        /// <param name="listview">���X�g�r���[�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="isSelect">�I����Ԃɂ���ꍇ��true��ݒ肵�܂��B</param>
        private static void EmulateChangeSelectedStateInTarget(ListView listview, int index, bool isSelect)
        {
            listview.Focus();
            listview.Items[index].Selected = isSelect;
        }
    }
}