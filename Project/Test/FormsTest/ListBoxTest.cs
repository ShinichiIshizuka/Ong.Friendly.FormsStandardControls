using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using Codeer.Friendly;
using System.Windows.Forms;
using System;
using Codeer.Friendly.Windows.NativeStandardControls;

namespace FormsTest
{
    /// <summary>
    /// ListBox�e�X�g
    /// </summary>
    [TestClass]
    public class ListBoxTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// ������
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            //�e�X�g�p�̉�ʋN��
            app = new WindowsAppFriend(Process.Start(Settings.TestApplicationPath));
            testDlg = WindowControl.FromZTop(app);
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
        }

        /// <summary>
        /// �I��
        /// </summary>
        [TestCleanup]
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
        [TestMethod]
        public void TestItemCount()
        {
            FormsListBox listbox1 = new FormsListBox(testDlg["listBox1"]());
            int itemCount = listbox1.ItemCount;
            Assert.AreEqual(7, itemCount);
        }

        /// <summary>
        /// FindListIndex�e�X�g
        /// </summary>
        [TestMethod]
        [Obsolete("", false)]
        public void TestFindListIndex()
        {
            FormsListBox listbox1 = new FormsListBox(testDlg["listBox1"]());
            int findIndex = listbox1.FindListIndex("Item-4");
            listbox1.EmulateChangeSelectedIndex(findIndex);
            Assert.AreEqual(3, listbox1.SelectedIndex);
        }

        /// <summary>
        /// FindString�e�X�g
        /// </summary>
        [TestMethod]
        public void TestFindString()
        {
            FormsListBox listbox1 = new FormsListBox(testDlg["listBox1"]());
            int findIndex = listbox1.FindString("Item-11");
            Assert.AreEqual(5, findIndex);
            listbox1["Items"]()["Add"](@"dmy");
            listbox1["Items"]()["Add"](@"Item-11");
            findIndex = listbox1.FindString(@"Item-11", 6);
            Assert.AreEqual(listbox1.ItemCount - 1, findIndex);
            listbox1["Items"]()["RemoveAt"](listbox1.ItemCount - 1);
            listbox1["Items"]()["RemoveAt"](listbox1.ItemCount - 1);
        }

        /// <summary>
        /// FindStringExact�e�X�g
        /// </summary>
        [TestMethod]
        public void TestFindExact()
        {
            FormsListBox listbox1 = new FormsListBox(testDlg["listBox1"]());
            int findIndex = listbox1.FindStringExact("Item-11");
            Assert.AreEqual(6, findIndex);
            listbox1["Items"]()["Add"](@"dmy");
            listbox1["Items"]()["Add"](@"Item-11");
            findIndex = listbox1.FindStringExact(@"Item-11", 7);
            Assert.AreEqual(listbox1.ItemCount - 1, findIndex);
            listbox1["Items"]()["RemoveAt"](listbox1.ItemCount - 1);
            listbox1["Items"]()["RemoveAt"](listbox1.ItemCount - 1);
        }

        /// <summary>
        /// SelectedIndext�e�X�g
        /// </summary>
        [TestMethod]
        public void TestSelectIndexes()
        {
            FormsListBox listbox2 = new FormsListBox(testDlg["listBox2"]());
            int[] select = new int[] { 5 };
            listbox2.EmulateChangeSelectedIndex(5, new Async());
            int selected = listbox2.SelectedIndex;
            Assert.AreEqual(5, selected);
            Assert.IsTrue(listbox2.GetItem(5).IsSelected);
        }

        /// <summary>
        /// SelectedIndext�e�X�g
        /// </summary>
        [TestMethod]
        public void TestItemtext()
        {
            FormsListBox listbox2 = new FormsListBox(testDlg["listBox2"]());
            Assert.AreEqual("Item-6", listbox2.GetItemText(5));
            Assert.AreEqual("Item-6", listbox2.GetItem(5).Text);
        }

        /// <summary>
        /// SelectionMode�e�X�g
        /// </summary>
        [TestMethod]
        public void TestSelectionMode()
        {
            FormsListBox listbox1 = new FormsListBox(testDlg["listBox1"]());
            FormsListBox listbox2 = new FormsListBox(testDlg["listBox2"]());
            Assert.AreEqual(SelectionMode.One, listbox1.SelectionMode);
            Assert.AreEqual(SelectionMode.MultiSimple, listbox2.SelectionMode);
        }

        /// <summary>
        /// EmulateChangeSelectedState�e�X�g
        /// </summary>
        [TestMethod]
        public void TestEmulateChangeSelectedState()
        {
            FormsListBox listbox2 = new FormsListBox(testDlg["listBox2"]());
            listbox2.EmulateChangeSelectedState(4, true);
            int[] selected1 = listbox2.SelectedIndexes;
            Assert.AreEqual(1, selected1.Length);
            Assert.AreEqual(4, selected1[0]);

            // �񓯊�
            app[GetType(), "ChangeSelectedIndexEvent"](listbox2.AppVar);
            listbox2.EmulateChangeSelectedState(2, true, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(1, selected1.Length);
            int[] selected2 = listbox2.SelectedIndexes;
            Assert.AreEqual(2, selected2[0]);
        }


        /// <summary>
        /// EmulateChangeSelectedState�e�X�g
        /// </summary>
        [TestMethod]
        public void TestEmulateChangeSelectedStateByItem()
        {
            FormsListBox listbox2 = new FormsListBox(testDlg["listBox2"]());
            listbox2.GetItem(4).EmulateChangeSelectedState(true);
            int[] selected1 = listbox2.SelectedIndexes;
            Assert.AreEqual(1, selected1.Length);
            Assert.AreEqual(4, selected1[0]);

            // �񓯊�
            app[GetType(), "ChangeSelectedIndexEvent"](listbox2.AppVar);
            listbox2.GetItem(2).EmulateChangeSelectedState(true, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(1, selected1.Length);
            int[] selected2 = listbox2.SelectedIndexes;
            Assert.AreEqual(2, selected2[0]);
        }

        /// <summary>
        /// EmulateChangeSelectedIndex�e�X�g
        /// </summary>
        [TestMethod]
        public void TestEmulateChangeSelectedIndex()
        {
            FormsListBox listbox2 = new FormsListBox(testDlg["listBox2"]());
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
        /// EmulateChangeSelectedIndex�e�X�g
        /// </summary>
        [TestMethod]
        public void TestEmulateChangeSelectedIndexByItem()
        {
            FormsListBox listbox2 = new FormsListBox(testDlg["listBox2"]());
            listbox2.GetItem(1).EmulateSelect();
            listbox2.GetItem(2).EmulateSelect();
            int[] selected1 = listbox2.SelectedIndexes;
            Assert.AreEqual(1, selected1[0]);
            Assert.AreEqual(2, selected1[1]);

            // �񓯊�
            app[GetType(), "ChangeSelectedIndexEvent"](listbox2.AppVar);
            listbox2.GetItem(3).EmulateSelect(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            int[] selected2 = listbox2.SelectedIndexes;
            Assert.AreEqual(1, selected2[0]);
            Assert.AreEqual(2, selected2[1]);
            Assert.AreEqual(3, selected2[2]);
        }

        /// <summary>
        /// �I��ύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="listbox">���X�g�{�b�N�X</param>
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
