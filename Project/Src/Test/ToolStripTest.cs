using NUnit.Framework;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;

namespace Test
{
    /// <summary>
    /// ContextMenuStripテスト
    /// </summary>
    [TestFixture]
    public class ToolStripTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// 初期化
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            //テスト用の画面起動
            app = new WindowsAppFriend(Process.Start(Settings.TestApplicationPath), "2.0");
            testDlg = WindowControl.FromZTop(app);
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
        }
        
        /// <summary>
        /// 終了
        /// </summary>
        [TestFixtureTearDown]
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

        //@@@
        //FormsToolStripItem GetItem(params int[] indexs)
        //FormsToolStripItem GetItem(params string[] keys)
        //FormsToolStripItem FindItem(params string[] texts)

        //通常
        //public string Text { get { return (string)this["Text"]().Core; } }
        //public bool Visible { get { return (bool)this["Visible"]().Core; } }
        //public bool Enabled { get { return (bool)this["Enabled"]().Core; } }
        //public void EmulateClick()
        //public void EmulateClick(Async async)
        
        //ボタン
        //CheckState CheckState
        //void EmulateCheck(CheckState value)
        //void EmulateCheck(CheckState value, Async async)

        //コンボ
        //public FormsComboBox ComboBox { get { return new FormsComboBox(App, this["ComboBox"]()); } }

        //テキスト
        //public FormsTextBox TextBox
        
        /*
        /// <summary>
        /// クリック
        /// </summary>
        [Test]
        public void TestContextMenuStripClick1()
        {
            FormsToolStrip contextmenustrip1 = new FormsToolStrip(app, testDlg["contextMenuStrip1"]());
            contextmenustrip1.FindItem("MenuItem1").EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(1, count);
        }

        /// <summary>
        /// クリック
        /// </summary>
        [Test]
        public void TestContextMenuStripClick2()
        {
            FormsToolStrip contextmenustrip1 = new FormsToolStrip(app, testDlg["contextMenuStrip1"]());
            contextmenustrip1.FindItem("MenuItem2").EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(2, count);
        }

        /// <summary>
        /// メニュークリック
        /// </summary>
        [Test]
        public void TestMenuStripClickmenu001ToolStripMenuItem()
        {
            FormsToolStrip menustrip1 = new FormsToolStrip(app, testDlg["menuStrip1"]());
            FormsToolStripItem menuitem = menustrip1.FindItem("Menu001");
            menuitem.EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(100, count);
        }

        /// <summary>
        /// サブメニュークリック 
        /// </summary>
        [Test]
        public void TestMenuStripClickmenu00101ToolStripMenuItem()
        {
            FormsToolStrip menustrip1 = new FormsToolStrip(app, testDlg["menuStrip1"]());
            FormsToolStripItem menuitem1 = menustrip1.FindItem("Menu001", "Menu001-01");
            menuitem1.EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(101, count);
        }*/
    }
}
