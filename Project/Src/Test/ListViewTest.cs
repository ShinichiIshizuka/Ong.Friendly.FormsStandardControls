using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;

namespace Test
{
    /// <summary>
    /// ListView�e�X�g
    /// </summary>
    [TestFixture]
    public class ListViewTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// ������
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            //�e�X�g�p�̉�ʋN��
            app = new WindowsAppFriend(Process.Start(Settings.TestApplicationPath), "2.0");
            testDlg = WindowControl.FromZTop(app);
        }

        /// <summary>
        /// �I��
        /// </summary>
        [TestFixtureTearDown]
        public void TearDown()
        {
            //�I������
            if (app != null)
            {
                app.Dispose();
                Process process = Process.GetProcessById(app.ProcessId);
                process.CloseMainWindow();
                app = null;
            }
        }

        /// <summary>
        /// �s���Ɨ񐔂��擾���܂�
        /// </summary>
        [Test]
        public void ListViewRowColumnCount()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual(4, listView1.ItemCount);
            Assert.AreEqual(3, listView1.SubItemCount);
        }

        /// <summary>
        /// ���X�g�A�C�e�����e�L�X�g�Ō������đI�����܂�
        /// </summary>
        [Test]
        public void ListViewFindListItemAndSelect()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            FormsListViewItem item = listView1.FindItem("�����S");
            Assert.NotNull(item);
            listView1.EmulateItemSelect(item.ItemIndex, new Async());
            Assert.AreEqual(3, listView1.SelectItem.ItemIndex);
        }

        /// <summary>
        /// �s��I�����I�����ꂽ���X�g�A�C�e���̃e�L�X�g���擾���܂�
        /// </summary>
        [Test]
        public void ListViewSelectAndTextGet()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            listView1.EmulateItemSelect(1, new Async());
            Assert.AreEqual("�s�[�}��", listView1.SelectItem.Text);
        }

        /// <summary>
        /// �A�C�e�����`�F�b�N���܂�
        /// �T�u�A�C�e�����܂߂ă`�F�b�N���܂�
        /// </summary>
        [Test]
        public void ListViewItemCheck()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            FormsListViewItem item1 = listView1.FindItem("�����S");
            item1.EmulateCheck(true);
            Assert.IsTrue(item1.Checked);
            FormsListViewItem item2 = listView1.FindItem("���");
            Assert.AreEqual("�g�}�g", item2.Text);
        }

        /// <summary>
        /// View�̃X�^�C�����擾���܂�
        /// </summary>
        [Test]
        public void ListViewStyle()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            View viewStyle = listView1.GetView;
            Assert.AreEqual(View.Details, viewStyle);
        }

        /// <summary>
        /// �T�u�A�C�e�����擾���܂�
        /// </summary>
        [Test]
        public void ListViewGetSubItem()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            FormsListViewItem item1 = listView1.FindItem("�����S");
            FormsListViewSubItem subitem1 = item1.GetSubItem(1);
            Assert.AreEqual("�ʕ�", subitem1.Text);
        }
    }
}
