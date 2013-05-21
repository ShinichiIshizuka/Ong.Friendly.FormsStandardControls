using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��System.Windows.Forms.ListView�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsListView : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsListView(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsListView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �A�C�e���{�T�u�A�C�e�������擾���܂��B
        /// </summary>
        public int SubItemCount
        {
            get
            {
                return (int)(this["Columns"]()["Count"]().Core);
            }
        }

        /// <summary>
        /// �A�C�e�������擾���܂��B
        /// </summary>
        public int ItemCount
        {
            get
            {
                return (int)(this["Items"]()["Count"]().Core);
            }
        }

        /// <summary>
        /// �I�����Ă���ŏ��̃��X�g�A�C�e�����擾���܂�
        /// </summary>
        public FormsListViewItem SelectItem
        {
            get
            {
                AppVar returnItem = (App[GetType(), "SelectItemInTarget"](AppVar));
                return new FormsListViewItem(App, returnItem);
            }
        }

        /// <summary>
        /// �I�����X�g�A�C�e���i�����j
        /// </summary>
        /// <param name="listview">���X�g�r���[</param>
        /// <returns>�I�����ꂽ���X�g�A�C�e��</returns>
        private static ListViewItem SelectItemInTarget(ListView listview)
        {
            for (int itemIndex = 0; itemIndex < listview.Items.Count; itemIndex++)
            {
                if (listview.Items[itemIndex].Selected == true)
                {
                    return listview.Items[itemIndex];
                }
            }
            return null;
        }

        /// <summary>
        /// �s��I�����܂�
        /// </summary>
        /// <param name="itemIndex">�s�ԍ�</param>
        public void EmulateItemSelect(int itemIndex)
        {
            App[GetType(), "ItemSelectInTarget"](AppVar, itemIndex);
        }

        /// <summary>
        /// ���X�g�A�C�e���i�s�j��I�����܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="itemIndex">�m�[�h</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g</param>
        public void EmulateItemSelect(int itemIndex, Async async)
        {
            App[GetType(), "ItemSelectInTarget", async](AppVar, itemIndex);
        }

        /// <summary>
        /// ���X�g�A�C�e���I���i�����j
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="itemIndex"></param>
        private static void ItemSelectInTarget(ListView listview, int itemIndex)
        {
            listview.Items[itemIndex].Selected = true;
        }

        /// <summary>
        /// ���X�g�A�C�e�����w�肳�ꂽ�e�L�X�g�Ō������܂�
        /// </summary>
        /// <param name="itemText">�e�L�X�g</param>
        /// <returns>�������ꂽ�A�C�e���̃A�C�e���n���h���B����������null���Ԃ�܂�</returns>
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
        /// View�X�^�C�����擾���܂�
        /// </summary>
        public View GetView
        {
            get { return (View)(this["View"]().Core); } 
        }
    }
}