using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using Codeer.Friendly.Windows.NativeStandardControls;

namespace FormsTest
{
    /// <summary>
    /// ListBox�e�X�g
    /// </summary>
    [TestClass]
    public class CheckedListBoxTest
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
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(testDlg["checkedListBox1"]());
            int itemCount = checkedlistbox1.ItemCount;
            Assert.AreEqual(8, itemCount);
        }

        /// <summary>
        /// GetCheckState�e�X�g
        /// </summary>
        [TestMethod]
        public void TestGetCheckState()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateCheckState(0, CheckState.Checked);
            CheckState state = checkedlistbox1.GetCheckState(0);
            Assert.AreEqual(CheckState.Checked, state);
        }

        /// <summary>
        /// FindListIndex�e�X�g
        /// </summary>
        [TestMethod]
        [Obsolete("", false)]
        public void TestFindListIndex()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(testDlg["checkedListBox1"]());
            int index = checkedlistbox1.FindListIndex(@"Item-1");
            Assert.AreEqual(0, index);
        }

        /// <summary>
        /// FindString�e�X�g
        /// </summary>
        [TestMethod]
        public void TestFindString()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(testDlg["checkedListBox1"]());
            int index = checkedlistbox1.FindString(@"Item-2");
            Assert.AreEqual(1, index);
            checkedlistbox1["Items"]()["Add"](@"dmy");
            checkedlistbox1["Items"]()["Add"](@"Item-2");
            index = checkedlistbox1.FindString(@"Item-2", 2);
            Assert.AreEqual(checkedlistbox1.ItemCount - 1, index);
            checkedlistbox1["Items"]()["RemoveAt"](checkedlistbox1.ItemCount - 1);
            checkedlistbox1["Items"]()["RemoveAt"](checkedlistbox1.ItemCount - 1);
        }

        /// <summary>
        /// FindStringExact�e�X�g
        /// </summary>
        [TestMethod]
        public void TestFindStringExact()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(testDlg["checkedListBox1"]());
            int index = checkedlistbox1.FindStringExact(@"Item-11");
            Assert.AreEqual(7, index);
            checkedlistbox1["Items"]()["Add"](@"dmy");
            checkedlistbox1["Items"]()["Add"](@"Item-11");
            index = checkedlistbox1.FindStringExact(@"Item-11", 8);
            Assert.AreEqual(checkedlistbox1.ItemCount - 1, index);
            checkedlistbox1["Items"]()["RemoveAt"](checkedlistbox1.ItemCount - 1);
            checkedlistbox1["Items"]()["RemoveAt"](checkedlistbox1.ItemCount - 1);
        }

        /// <summary>
        /// FindStringExact�e�X�g
        /// </summary>
        [TestMethod]
        public void TestFindExact()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(testDlg["checkedListBox1"]());
            int index = checkedlistbox1.FindStringExact(@"Item-1");
            Assert.AreEqual(0, index);
        }

        /// <summary>
        /// CheckedIndices�e�X�g
        /// </summary>
        [TestMethod]
        public void TestCheckedIndices()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateCheckState(1, CheckState.Checked);

            int[] list = checkedlistbox1.CheckedIndices;
            Assert.AreEqual(1, list[0]);
        }

        /// <summary>
        /// SelectedItemIndex�e�X�g
        /// </summary>
        [TestMethod]
        public void TestSelectedItemIndex()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateChangeSelectedIndex(4);
            Assert.AreEqual(4, checkedlistbox1.SelectedItemIndex);

            checkedlistbox1.EmulateChangeSelectedIndex(2,new Async());
            Assert.AreEqual(2, checkedlistbox1.SelectedItemIndex);
        }

        /// <summary>
        /// EmulateChangeSelectedIndex�e�X�g
        /// </summary>
        [TestMethod]
        public void TestEmulateChangeSelectedIndex()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateChangeSelectedIndex(4);
            string checkedlistbox1Text = checkedlistbox1.Text;
            Assert.AreEqual("Item-5", checkedlistbox1Text);

            //�񓯊�
            app[GetType(), "ChangeSelectedIndexEvent"](checkedlistbox1.AppVar);
            checkedlistbox1.EmulateChangeSelectedIndex(2, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            checkedlistbox1Text = checkedlistbox1.Text;
            Assert.AreEqual("Item-3", checkedlistbox1Text);
        }

        /// <summary>
        /// ��ԕύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="checkdListBox">�`�F�b�N���X�g�{�b�N�X</param>
        static void ChangeSelectedIndexEvent(CheckedListBox checkdListBox)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                checkdListBox.BeginInvoke((MethodInvoker)delegate
                {
                    checkdListBox.SelectedIndexChanged -= handler;
                });
            };
            checkdListBox.SelectedIndexChanged += handler;
        }
        
        /// <summary>
        /// EmulateCheckState�e�X�g
        /// </summary>
        [TestMethod]
        public void TestEmulateCheckState()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateCheckState(0, CheckState.Checked);

            int[] list = checkedlistbox1.CheckedIndices;
            Assert.AreEqual(0, list[0]);

            //�񓯊�
            app[GetType(), "ItemCheckedEvent"](checkedlistbox1.AppVar);
            checkedlistbox1.EmulateCheckState(0, CheckState.Unchecked,new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            int[] listUnchecked = checkedlistbox1.CheckedIndices;
            Assert.AreEqual(0, list[0]);
        }

        /// <summary>
        /// ��ԕύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="checkdListBox">�`�F�b�N���X�g�{�b�N�X</param>
        static void ItemCheckedEvent(CheckedListBox checkdListBox)
        {
            ItemCheckEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                checkdListBox.BeginInvoke((MethodInvoker)delegate
                {
                    checkdListBox.ItemCheck -= handler;
                });
            };
            checkdListBox.ItemCheck += handler;
        }    
    }
}