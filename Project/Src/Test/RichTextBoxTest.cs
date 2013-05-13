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
    /// RichTextBoxテスト
    /// </summary>
    [TestFixture]
    public class RichTextBoxTest
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
        /// </summary>
        [Test]
        public void TestRichTextBoxTextGetAndSet()
        {
            FormsRichTextBox richtextbox1 = new FormsRichTextBox(app, testDlg["richTextBox1"]());
            richtextbox1.EmulateChangeText("RICHTEXTBOX1");
            String richtextbox1Text = richtextbox1.Text;
            Assert.AreEqual("RICHTEXTBOX1", richtextbox1Text);

            richtextbox1.EmulateChangeText("RICHTEXTBOX11", new Async());
            richtextbox1Text = richtextbox1.Text;
            Assert.AreEqual("RICHTEXTBOX11", richtextbox1Text);
        }
    }
}
