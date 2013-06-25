using System;
using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
namespace Test
{
    /// <summary>
    /// TextBoxテスト
    /// </summary>
    [TestFixture]
    public class TextBoxTest
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
        /// テキスト設定・取得をします
        /// @@@非同期
        /// </summary>
        [Test]
        public void TestEmulateChangeText()
        {
            FormsTextBox textbox1 = new FormsTextBox(app, testDlg["textBox1"]());
            textbox1.EmulateChangeText("TEXTBOX1");
            string textbox1Text = textbox1.Text;
            Assert.AreEqual("TEXTBOX1", textbox1Text);

            textbox1.EmulateChangeText("TEXTBOX11", new Async());
            textbox1Text = textbox1.Text;
            Assert.AreEqual("TEXTBOX11", textbox1Text);
        }
    }
}
