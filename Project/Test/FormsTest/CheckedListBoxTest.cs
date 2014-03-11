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
    /// ListBoxテスト
    /// </summary>
    [TestClass]
    public class CheckedListBoxTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// 初期化
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            //テスト用の画面起動
            app = new WindowsAppFriend(Process.Start(Settings.TestApplicationPath));
            testDlg = WindowControl.FromZTop(app);
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
        }

        /// <summary>
        /// 終了
        /// </summary>
        [TestCleanup]
        public void TearDown()
        {
            //終了処理
            if (app != null)
            {
                app.Dispose();
                Process process = Process.GetProcessById(app.ProcessId);
                process.CloseMainWindow();
                app = null;
            }
        }

        /// <summary>
        /// ItemCountテスト
        /// </summary>
        [TestMethod]
        public void TestItemCount()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            int itemCount = checkedlistbox1.ItemCount;
            Assert.AreEqual(8, itemCount);
        }

        /// <summary>
        /// GetCheckStateテスト
        /// </summary>
        [TestMethod]
        public void TestGetCheckState()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateCheckState(0, CheckState.Checked);
            CheckState state = checkedlistbox1.GetCheckState(0);
            Assert.AreEqual(CheckState.Checked, state);
        }

        /// <summary>
        /// FindListIndexテスト
        /// </summary>
        [TestMethod]
        public void TestFindListIndex()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            int index = checkedlistbox1.FindListIndex(@"Item-1");
            Assert.AreEqual(0, index);
        }

        /// <summary>
        /// FindStringテスト
        /// </summary>
        [TestMethod]
        public void TestFindString()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
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
        /// FindStringExactテスト
        /// </summary>
        [TestMethod]
        public void TestFindStringExact()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
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
        /// FindStringExactテスト
        /// </summary>
        [TestMethod]
        public void TestFindExact()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            int index = checkedlistbox1.FindStringExact(@"Item-1");
            Assert.AreEqual(0, index);
        }

        /// <summary>
        /// CheckedIndicesテスト
        /// </summary>
        [TestMethod]
        public void TestCheckedIndices()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateCheckState(1, CheckState.Checked);

            int[] list = checkedlistbox1.CheckedIndices;
            Assert.AreEqual(1, list[0]);
        }

        /// <summary>
        /// SelectedItemIndexテスト
        /// </summary>
        [TestMethod]
        public void TestSelectedItemIndex()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateChangeSelectedIndex(4);
            Assert.AreEqual(4, checkedlistbox1.SelectedItemIndex);

            checkedlistbox1.EmulateChangeSelectedIndex(2,new Async());
            Assert.AreEqual(2, checkedlistbox1.SelectedItemIndex);
        }

        /// <summary>
        /// EmulateChangeSelectedIndexテスト
        /// </summary>
        [TestMethod]
        public void TestEmulateChangeSelectedIndex()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateChangeSelectedIndex(4);
            string checkedlistbox1Text = checkedlistbox1.Text;
            Assert.AreEqual("Item-5", checkedlistbox1Text);

            //非同期
            app[GetType(), "ChangeSelectedIndexEvent"](checkedlistbox1.AppVar);
            checkedlistbox1.EmulateChangeSelectedIndex(2, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            checkedlistbox1Text = checkedlistbox1.Text;
            Assert.AreEqual("Item-3", checkedlistbox1Text);
        }

        /// <summary>
        /// 状態変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="checkdListBox">チェックリストボックス</param>
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
        /// EmulateCheckStateテスト
        /// </summary>
        [TestMethod]
        public void TestEmulateCheckState()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateCheckState(0, CheckState.Checked);

            int[] list = checkedlistbox1.CheckedIndices;
            Assert.AreEqual(0, list[0]);

            //非同期
            app[GetType(), "ItemCheckedEvent"](checkedlistbox1.AppVar);
            checkedlistbox1.EmulateCheckState(0, CheckState.Unchecked,new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            int[] listUnchecked = checkedlistbox1.CheckedIndices;
            Assert.AreEqual(0, list[0]);
        }

        /// <summary>
        /// 状態変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="checkdListBox">チェックリストボックス</param>
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
