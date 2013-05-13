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
    /// WindowControl��System.Windows.Forms.ListView�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsListView : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsListView(FormsControlBase src)
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
        /// �񐔂��擾���܂��B
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return (int)(this["Columns"]()["Count"]().Core);
            }
        }

        /// <summary>
        /// �s�����擾���܂��B
        /// </summary>
        public int RowCount
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
                return new FormsListViewItem(returnItem);
            }
        }

        /// <summary>
        /// �I�����X�g�A�C�e���i�����j
        /// </summary>
        /// <param name="listview">���X�g�r���[</param>
        /// <returns>�I�����ꂽ���X�g�A�C�e��</returns>
        private static ListViewItem SelectItemInTarget(ListView listview)
        {
            for (int row = 0; row < listview.Items.Count; row++)
            {
                if (listview.Items[row].Selected == true)
                {
                    return listview.Items[row];
                }
            }
            return null;
        }

        /// <summary>
        /// �s��I�����܂�
        /// </summary>
        /// <param name="row">�s�ԍ�</param>
        public void EmulateRowSelect(int row)
        {
            App[GetType(), "RowSelectInTarget"](AppVar, row);
        }

        /// <summary>
        /// ���X�g�A�C�e���i�s�j��I�����܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="row">�m�[�h</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g</param>
        public void EmulateRowSelect(int row, Async async)
        {
            App[GetType(), "RowSelectInTarget", async](AppVar, row);
        }

        /// <summary>
        /// ���X�g�A�C�e���I���i�����j
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="row"></param>
        private static void RowSelectInTarget(ListView listview, int row)
        {
            listview.Items[row].Selected = true;
        }

        /// <summary>
        /// ���X�g�A�C�e�����w�肳�ꂽ�e�L�X�g�Ō������܂�
        /// </summary>
        /// <param name="itemText">�e�L�X�g</param>
        /// <returns>�������ꂽ�A�C�e���̃A�C�e���n���h���B����������null���Ԃ�܂�</returns>
        public FormsListViewItem FindItem(string itemText)
        {
            AppVar returnItem = this["FindItemWithText"](itemText);
            if (returnItem != null)
            {
                return new FormsListViewItem(returnItem);
            }
            return null;
        }
    }
}