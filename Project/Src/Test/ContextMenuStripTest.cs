using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using Codeer.Friendly.Windows.NativeStandardControls;
using System.Windows.Forms;
namespace Test
{
    /// <summary>
    /// ContextMenuStripテスト
    /// </summary>
    [TestFixture]
    public class ContextMenuStripTest
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

        /// <summary>
        /// クリック
        /// </summary>
        [Test]
        public void TestContextMenuStripClick1()
        {
            FormsContextMenuStrip contextmenustrip1 = new FormsContextMenuStrip(app, testDlg["contextMenuStrip1"]());
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
            FormsContextMenuStrip contextmenustrip1 = new FormsContextMenuStrip(app, testDlg["contextMenuStrip1"]());
            contextmenustrip1.FindItem("MenuItem2").EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(2, count);
        }
    }
}
