using System;
using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace Test
{
    /// <summary>
    /// LinkLabelテスト
    /// </summary>
    [TestFixture]
    public class LinkLabelTest
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

        /// <summary>
        /// クリックします。
        /// </summary>
        [Test]
        public void TestLinkClick()
        {
            FormsLinkLabel linklabel = new FormsLinkLabel(app, testDlg["linkLabel"]());
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
