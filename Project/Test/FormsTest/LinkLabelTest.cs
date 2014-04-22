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
    /// LinkLabelテスト
    /// </summary>
    [TestClass]
    public class LinkLabelTest
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
        /// クリックします。
        /// </summary>
        [TestMethod]
        public void TestLinkClick()
        {
            FormsLinkLabel linklabel = new FormsLinkLabel(testDlg["linkLabel"]());
            linklabel.EmulateLinkClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(12, count);
            //非同期
            app[GetType(), "LinkClickEvent"](linklabel.AppVar);
            linklabel.EmulateLinkClick(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(12, count);
        }

        /// <summary>
        /// クリック時にメッセージボックスを表示する
        /// </summary>
        /// <param name="linklabel">ボタン</param>
        static void LinkClickEvent(LinkLabel linklabel)
        {
            LinkLabelLinkClickedEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                linklabel.BeginInvoke((MethodInvoker)delegate
                {
                    linklabel.LinkClicked -= handler;
                });
            };
            linklabel.LinkClicked += handler;
        }
    }
}
