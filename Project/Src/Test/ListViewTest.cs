using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using Codeer.Friendly.Windows.NativeStandardControls;

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
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
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
        /// ItemCount�̃e�X�g
        /// </summary>
        [Test]
        public void TestItemCount()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual(4, listView1.ItemCount);
        }

        /// <summary>
        /// ColumnCount�̃e�X�g
        /// </summary>
        [Test]
        public void TestColumnCount()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual(3, listView.ColumnCount);
        }

        /// <summary>
        /// ViewMode�̃e�X�g
        /// </summary>
        [Test]
        public void TestViewMode()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            View viewStyle = listView1.ViewMode;
            Assert.AreEqual(View.Details, viewStyle);
        }

        /// <summary>
        /// SelectIndexes�̃e�X�g
        /// </summary>
        [Test]
        public void TestSelectIndexes()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());

            //������
            for (int i = 0; i < listView.ItemCount; i++)
            {
                listView.EmulateChangeSelectedState(i, false);
            }

            listView.EmulateChangeSelectedState(0, true);
            listView.EmulateChangeSelectedState(2, true);
            Assert.AreEqual(new int[]{0, 2}, listView.SelectIndexes);
        }

        /// <summary>
        /// GetListViewItem�̃e�X�g
        /// </summary>
        [Test]
        public void TestGetListViewItem()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual("�s�[�}��", listView.GetListViewItem(1).Text);
        }

        /// <summary>
        /// FindItemWithText�̃e�X�g
        /// </summary>
        [Test]
        public void TestFindItemWithText()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual("�s�[�}��", listView.FindItemWithText("�s�[�}��", true, 0).Text);
            Assert.IsNull(listView.FindItemWithText("�s�[�}��", true, 2));
        }

        /// <summary>
        /// EmulateChangeSelectedState�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeSelectedState()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());

            //������
            for (int i = 0; i < listView.ItemCount; i++)
            {
                listView.EmulateChangeSelectedState(i, false);
            }

            listView.EmulateChangeSelectedState(0, true);
            Assert.AreEqual(new int[] { 0 }, listView.SelectIndexes);

            //�񓯊�
            app[GetType(), "SelectEvent"](listView.AppVar);
            listView.EmulateChangeSelectedState(2, true, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(new int[] { 0, 2 }, listView.SelectIndexes);
        }

        /// <summary>
        /// �I��ύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="listView">���X�g�r���[</param>
        static void SelectEvent(ListView listView)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                listView.BeginInvoke((MethodInvoker)delegate
                {
                    listView.SelectedIndexChanged -= handler;
                });
            };
            listView.SelectedIndexChanged += handler;
        }

        /// <summary>
        /// ListViewItem��Text�̃e�X�g
        /// </summary>
        [Test]
        public void TestItemText()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual("�s�[�}��", listView.GetListViewItem(1).Text);
        }

        /// <summary>
        /// ListViewItem��ItemIndex�̃e�X�g
        /// </summary>
        [Test]
        public void TestItemIndex()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual(1, listView.GetListViewItem(1).ItemIndex);
        }

        /// <summary>
        /// GetSubItem��SubItem��Text�̃e�X�g
        /// </summary>
        [Test]
        public void TestGetSubItemAndSubItemText()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual("���", listView.GetListViewItem(1).GetSubItem(1).Text);
        }

        /// <summary>
        /// ListViewItem��EmulateCheck��Checked�̃e�X�g
        /// </summary>
        [Test]
        public void TestItemEmulateCheckAndChecked()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            FormsListViewItem item = listView.GetListViewItem(1);
            item.EmulateCheck(true);
            Assert.AreEqual(true, item.Checked);

            //�񓯊�
            app[GetType(), "CheckedEvent"](listView.AppVar);
            item.EmulateCheck(false, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(false, item.Checked);
        }

        /// <summary>
        /// �`�F�b�N�ύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="listView">���X�g�r���[</param>
        static void CheckedEvent(ListView listView)
        {
            ItemCheckedEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                listView.BeginInvoke((MethodInvoker)delegate
                {
                    listView.ItemChecked -= handler;
                });
            };
            listView.ItemChecked += handler;
        }

        /// <summary>
        /// EmulateEditLabel�̃e�X�g
        /// </summary>
        [Test]
        public void TestItemEmulateEditLabel()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            FormsListViewItem item = listView.GetListViewItem(1);
            string bk = item.Text;
            item.EmulateEditLabel("abc");
            Assert.AreEqual("abc", item.Text);

            //�񓯊�
            app[GetType(), "LabelEditEvent"](listView.AppVar);
            item.EmulateEditLabel(bk, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(bk, item.Text);
        }

        /// <summary>
        /// ���x���ύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="listView">���X�g�r���[</param>
        static void LabelEditEvent(ListView listView)
        {
            LabelEditEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                listView.BeginInvoke((MethodInvoker)delegate
                {
                    listView.AfterLabelEdit -= handler;
                });
            };
            listView.AfterLabelEdit += handler;
        }
    }
}
