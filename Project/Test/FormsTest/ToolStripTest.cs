using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using Codeer.Friendly;
using Codeer.Friendly.Windows.NativeStandardControls;

namespace FormsTest
{
    /// <summary>
    /// ContextMenuStripテスト
    /// </summary>
    [TestClass]
    public class ToolStripTest
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
        /// GetItem(int)のテスト
        /// </summary>
        [TestMethod]
        public void TestGetItemInt()
        {
            FormsToolStrip menu = new FormsToolStrip(testDlg["menuStrip1"]());
            Assert.AreEqual("Menu001-02", menu.GetItem(0, 1).Text);
            FormsToolStrip toolBar = new FormsToolStrip(testDlg["toolStrip1"]());
            Assert.AreEqual("toolStripButton2", toolBar.GetItem(1).Text);
        }

        /// <summary>
        /// GetItem(string)のテスト
        /// </summary>
        [TestMethod]
        public void TestGetItemString()
        {
            FormsToolStrip menu = new FormsToolStrip(testDlg["menuStrip1"]());
            Assert.AreEqual("Menu001-02", menu.GetItem("menu001ToolStripMenuItem", "menu00102ToolStripMenuItem").Text);
            FormsToolStrip toolBar = new FormsToolStrip(testDlg["toolStrip1"]());
            Assert.AreEqual("toolStripButton2", toolBar.GetItem("toolStripButton2").Text);
            FormsToolStrip context = new FormsToolStrip(testDlg["contextMenuStrip1"]());
            Assert.AreEqual("MenuItem2", context.GetItem("menuItem2ToolStripMenuItem").Text);
        }

        /// <summary>
        /// FindItemのテスト
        /// </summary>
        [TestMethod]
        public void TestGetFindItem()
        {
            FormsToolStrip menu = new FormsToolStrip(testDlg["menuStrip1"]());
            Assert.AreEqual("Menu001-02", menu.FindItem("Menu001", "Menu001-02").Text);
            FormsToolStrip toolBar = new FormsToolStrip(testDlg["toolStrip1"]());
            Assert.AreEqual("toolStripButton2", toolBar.FindItem("toolStripButton2").Text);
            FormsToolStrip context = new FormsToolStrip(testDlg["contextMenuStrip1"]());
            Assert.AreEqual("MenuItem2", context.FindItem("MenuItem2").Text);
        }

        /// <summary>
        /// FormsToolStripItemのTextテスト
        /// </summary>
        [TestMethod]
        public void TestItemText()
        {
            FormsToolStripItem item = new FormsToolStrip(testDlg["menuStrip1"]()).FindItem("Menu001", "Menu001-02");
            Assert.AreEqual("Menu001-02", item.Text);
        }

        /// <summary>
        /// FormsToolStripItemのVisibleテスト
        /// </summary>
        [TestMethod]
        public void TestItemVisible()
        {
            FormsToolStripItem item = new FormsToolStrip(testDlg["toolStrip1"]()).FindItem("toolStripButton2");
            item["Visible"](false);
            Assert.AreEqual(false, item.Visible);
            item["Visible"](true);
            Assert.AreEqual(true, item.Visible);
        }

        /// <summary>
        /// FormsToolStripItemのEnabledテスト
        /// </summary>
        [TestMethod]
        public void TestItemEnabled()
        {
            FormsToolStripItem item = new FormsToolStrip(testDlg["menuStrip1"]()).FindItem("Menu001", "Menu001-02");
            item["Enabled"](false);
            Assert.AreEqual(false, item.Enabled);
            item["Enabled"](true);
            Assert.AreEqual(true, item.Enabled);
        }

        /// <summary>
        /// FormsToolStripItemのEmulateClickテスト
        /// </summary>
        [TestMethod]
        public void TestEmulateClick()
        {
            FormsToolStripItem item =  new FormsToolStrip(testDlg["contextMenuStrip1"]()).GetItem(1);
            item.EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(0, count);

            //非同期
            app[GetType(), "ClickEvent"](testDlg.AppVar, item.AppVar);
            item.EmulateClick(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(0, count);
        }

        /// <summary>
        /// クリック時にメッセージボックスを表示する
        /// </summary>
        /// <param name="control">コントロール</param>
        /// <param name="item">アイテム</param>
        static void ClickEvent(Control control, ToolStripItem item)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                control.BeginInvoke((MethodInvoker)delegate
                {
                    item.Click -= handler;
                });
            };
            item.Click += handler;
        }

        /// <summary>
        /// FormsToolStripItemのEmulateCheckとCheckStateのテスト
        /// </summary>
        [TestMethod]
        public void TestEmulateCheckAndCheckState()
        {
            FormsToolStripButton item = new FormsToolStripButton(new FormsToolStrip(testDlg["toolStrip1"]()).GetItem(3));
            item.EmulateCheck(CheckState.Checked);
            Assert.AreEqual(CheckState.Checked, item.CheckState);

            //非同期
            app[GetType(), "CheckEvent"](testDlg.AppVar, item.AppVar);
            item.EmulateCheck(CheckState.Unchecked, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(CheckState.Unchecked, item.CheckState);
        }

        /// <summary>
        /// チェック時にメッセージボックスを表示する
        /// </summary>
        /// <param name="control">コントロール</param>
        /// <param name="item">アイテム</param>
        static void CheckEvent(Control control, ToolStripButton item)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                control.BeginInvoke((MethodInvoker)delegate
                {
                    item.CheckedChanged -= handler;
                });
            };
            item.CheckedChanged += handler;
        }

        /// <summary>
        /// コンボボックス取得テスト
        /// </summary>
        [TestMethod]
        public void TestGetComboBox()
        {
            FormsToolStripComboBox item = new FormsToolStripComboBox(new FormsToolStrip(testDlg["toolStrip1"]()).GetItem(4));
            Assert.AreEqual(typeof(ComboBox), (Type)item.ComboBox["GetType"]()["BaseType"]().Core);
        }

        /// <summary>
        /// テキストボックス取得テスト
        /// </summary>
        [TestMethod]
        public void TestTextBox()
        {
            FormsToolStripTextBox item = new FormsToolStripTextBox(new FormsToolStrip(testDlg["toolStrip1"]()).GetItem(6));
            Assert.AreEqual(typeof(TextBox), (Type)item.TextBox["GetType"]()["BaseType"]().Core);
        }

        /// <summary>
        /// 初期化テスト
        /// </summary>
        [TestMethod]
        public void TestToolStripItemInitialize()
        {
            FormsToolStripItem item = new FormsToolStripItem(testDlg["menu001ToolStripMenuItem"]());
            item.EmulateClick();
        }

        /// <summary>
        /// メニューの開閉テスト
        /// </summary>
        [TestMethod]
        public void TestShowClose1()
        {
            FormsToolStripItem item = new FormsToolStripItem(testDlg["menu00104ToolStripMenuItem"]());
            Assert.IsFalse(item.Enabled);
            Assert.IsFalse(item.Visible);
            item.EmulateShow();
            Assert.IsTrue(item.Enabled);
            Assert.IsTrue(item.Visible);
            item.EmulateHide();
            Assert.IsFalse(item.Enabled);
            Assert.IsFalse(item.Visible);
        }

        /// <summary>
        /// メニューの開閉テスト
        /// </summary>
        [TestMethod]
        public void TestShowClose2()
        {
            FormsToolStripItem item = new FormsToolStripItem(testDlg["menuItem4ToolStripMenuItem"]());
            Assert.IsFalse(item.Enabled);
            Assert.IsFalse(item.Visible);
            item.EmulateShow();
            Assert.IsTrue(item.Enabled);
            Assert.IsTrue(item.Visible);
            item.EmulateHide();
            Assert.IsFalse(item.Enabled);
            Assert.IsFalse(item.Visible);
        }




        /// <summary>
        /// メニューの開閉テスト
        /// </summary>
        [TestMethod]
        public void TestShowClick1()
        {
            FormsToolStripItem item = new FormsToolStripItem(testDlg["menu00104ToolStripMenuItem"]());
            item.EmulateShow();
            item.EmulateClick();
            item.EmulateHide();
            Assert.IsFalse(item.Enabled);
            Assert.IsFalse(item.Visible);
        }

        /// <summary>
        /// メニューの開閉テスト
        /// </summary>
        [TestMethod]
        public void TestShowClick2()
        {
            FormsToolStripItem item = new FormsToolStripItem(testDlg["menuItem4ToolStripMenuItem"]());
            item.EmulateShow();
            item.EmulateClick();
            item.EmulateHide();
            Assert.IsFalse(item.Enabled);
            Assert.IsFalse(item.Visible);
        }
    }
}
