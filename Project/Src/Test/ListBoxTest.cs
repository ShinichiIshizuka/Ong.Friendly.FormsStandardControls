using NUnit.Framework;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using Codeer.Friendly;
using System.Windows.Forms;
using System;
using Codeer.Friendly.Windows.NativeStandardControls;

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

        /// <summary>
        /// EmulateChangeSelectedState�e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeSelectedState()
        {
            FormsListBox listbox2 = new FormsListBox(app, testDlg["listBox2"]());
            listbox2.EmulateChangeSelectedState(4, true);
            int[] selected1 = listbox2.SelectedIndexes;
            Assert.AreEqual(1, selected1[0]);

            // �񓯊�
            app[GetType(), "ChangeSelectedIndexEvent"](listbox2.AppVar);
            listbox2.EmulateChangeSelectedState(2, true, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            int[] selected2 = listbox2.SelectedIndexes;
            Assert.AreEqual(1, selected2[0]);
        }

        /// <summary>
        /// EmulateChangeSelectedIndex�e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeSelectedIndex()
        {
            FormsListBox listbox2 = new FormsListBox(app, testDlg["listBox2"]());
            listbox2.EmulateChangeSelectedIndex(1);
            listbox2.EmulateChangeSelectedIndex(2);
            int[] selected1 = listbox2.SelectedIndexes;
            Assert.AreEqual(1, selected1[0]);
            Assert.AreEqual(2, selected1[1]);

            // �񓯊�
            app[GetType(), "ChangeSelectedIndexEvent"](listbox2.AppVar);
            listbox2.EmulateChangeSelectedIndex(3, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            int[] selected2 = listbox2.SelectedIndexes;
            Assert.AreEqual(1, selected2[0]);
            Assert.AreEqual(2, selected2[1]);
            Assert.AreEqual(3, selected2[2]);
        }

        /// <summary>
        /// �I��ύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="listbox">�{�^��</param>
        static void ChangeSelectedIndexEvent(ListBox listbox)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                listbox.BeginInvoke((MethodInvoker)delegate
                {
                    listbox.SelectedIndexChanged -= handler;
                });
            };
            listbox.SelectedIndexChanged += handler;
        }
    }
}
