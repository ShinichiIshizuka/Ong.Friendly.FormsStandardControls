using NUnit.Framework;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using Codeer.Friendly;
using System.Windows.Forms;

namespace Test
{
    /// <summary>
    /// ListBox�e�X�g
    /// </summary>
    [TestFixture]
    public class ListBoxTest
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
        /// ItemCount�e�X�g
        /// </summary>
        [Test]
        public void TestItemCount()
        {
            FormsListBox listbox1 = new FormsListBox(app, testDlg["listBox1"]());
            int itemCount = listbox1.ItemCount;
            Assert.AreEqual(5, itemCount);
        }

        /// <summary>
        /// FindListIndex�e�X�g
        /// </summary>
        [Test]
        public void TestFindListIndex()
        {
            FormsListBox listbox1 = new FormsListBox(app, testDlg["listBox1"]());
            int findIndex = listbox1.FindListIndex("Item-4");
            listbox1.EmulateChangeSelectedIndex(findIndex);
            Assert.AreEqual(3, listbox1.SelectedIndex);
        }

        /// <summary>
        /// SelectedIndext�e�X�g
        /// </summary>
        [Test]
        public void TestSelectIndexes()
        {
            FormsListBox listbox2 = new FormsListBox(app, testDlg["listBox2"]());
            int[] select = new int[]{5};
            listbox2.EmulateChangeSelectedIndex(5,new Async());
            int selected = listbox2.SelectedIndex;
            Assert.AreEqual(1, selected);
        }

        /// <summary>
        /// SelectionMode�e�X�g
        /// </summary>
        [Test]
        public void TestSelectionMode()
        {
            FormsListBox listbox1 = new FormsListBox(app, testDlg["listBox1"]());
            FormsListBox listbox2 = new FormsListBox(app, testDlg["listBox2"]());
            Assert.AreEqual(SelectionMode.One, listbox1.SelectionMode);
            Assert.AreEqual(SelectionMode.MultiSimple, listbox2.SelectionMode);
        }

        //@@@EmulateChangeSelectedState

        /// <summary>
        /// EmulateChangeSelectedIndex�e�X�g
        /// @@@Async
        /// </summary>
        [Test]
        public void TestEmulateChangeSelectedIndex()
        {
            FormsListBox listbox2 = new FormsListBox(app, testDlg["listBox2"]());
            int[] select = new int[] { 1, 2, 4 };
            listbox2.EmulateChangeSelectedIndex(1, new Async());
            listbox2.EmulateChangeSelectedIndex(2, new Async());
            listbox2.EmulateChangeSelectedIndex(4, new Async());
            int[] selected = listbox2.SelectedIndexes;
            Assert.AreEqual(1, selected[0]);
            Assert.AreEqual(2, selected[1]);
            Assert.AreEqual(4, selected[2]);
        }
    }
}
