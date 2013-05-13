using System;
using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace Test
{
    /// <summary>
    /// Buttonテスト
    /// </summary>
    [TestFixture]
    public class ButtonTest
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
        /// クリックテスト
        /// </summary>
        [Test]
        public void TestButtonClick()
        {
            FormsButton button1 = new FormsButton(app, testDlg["button1"]());
            button1.EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(3, count);            

            FormsButton button2 = new FormsButton(app, testDlg["button2"]());
            button2.EmulateClick(new Async());
            WindowControl msg = testDlg.WaitForNextModal();
            NativeButton buttonOK = new NativeButton(msg.IdentifyFromWindowText("OK"));
            buttonOK.EmulateClick();
        }

        /// <summary>
        /// テキストを取得します
        /// </summary>
        [Test]
        public void TestButtonTextGet()
        {
            FormsButton button1 = new FormsButton(app, testDlg["button1"]());
            String buttonText = button1.Text;
            Assert.AreEqual("button1", buttonText);
        }
    }
}
