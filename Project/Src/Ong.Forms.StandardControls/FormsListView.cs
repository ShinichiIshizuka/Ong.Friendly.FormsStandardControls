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
            get { return (int[])(App[GetType(), "GetSelectedIndexesTarget"](AppVar).Core); } 
        }
        
        /// <summary>
        /// �I�����ꂽ�C���f�b�N�X�̈ꗗ���擾���܂��i�����j�B
        /// </summary>
        /// <param name="listview">���X�g�r���[</param>
        /// <returns>�I�����ꂽ�C���f�b�N�X�ꗗ�B</returns>
        private static int[] GetSelectedIndexesTarget(ListView listview)
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
        // GetListViewItem FormsListViewItems��Ԃ�
  
        // EmulateChangeSelectedState�����
        /*
        /// <summary>
        /// �s��I�����܂��B
        /// </summary>
        /// <param name="itemIndex">�s�ԍ��B</param>
        public void EmulateItemSelect(int itemIndex)
        {
            App[GetType(), "ItemSelectInTarget"](AppVar, itemIndex);
        }

        /// <summary>
        /// ���X�g�A�C�e���i�s�j��I�����܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="itemIndex">�m�[�h�B</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g�B</param>
        public void EmulateItemSelect(int itemIndex, Async async)
        {
            App[GetType(), "ItemSelectInTarget", async](AppVar, itemIndex);
        }

        /// <summary>
        /// ���X�g�A�C�e���I���i�����j�B
        /// </summary>
        /// <param name="listview">���X�g�r���[�B</param>
        /// <param name="itemIndex">�C���f�b�N�X�B</param>
        private static void ItemSelectInTarget(ListView listview, int itemIndex)
        {
            listview.Items[itemIndex].Selected = true;
        }
        */
        //Delete

        /// <summary>
        /// ���X�g�A�C�e�����w�肳�ꂽ�e�L�X�g�Ō������܂��B
        /// </summary>
        /// <param name="itemText">�e�L�X�g</param>
        /// <returns>�������ꂽ�A�C�e���̃A�C�e���n���h���B����������null���Ԃ�܂��B</returns>
        public FormsListViewItem FindItem(string itemText)
        {
            AppVar returnItem = this["FindItemWithText"](itemText, true, 0);
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