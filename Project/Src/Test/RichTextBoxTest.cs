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
        /// テキスト設定・取得をします
        /// </summary>
        [Test]
        public void TestEmulateChangeText()
        {
            FormsRichTextBox richTextBox = new FormsRichTextBox(app, testDlg["richTextBox"]());
            richTextBox.EmulateChangeText("richTextBox");
            string richTextBoxText = richTextBox.Text;
            Assert.AreEqual("richTextBox", richTextBoxText);

            // 非同期
            app[GetType(), "ChangeTextEvent"](richTextBox.AppVar);
            richTextBox.EmulateChangeText("richTextBox1", new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            richTextBoxText = richTextBox.Text;
            Assert.AreEqual("richTextBox1", richTextBoxText);
        }

        /// <summary>
        /// テキスト変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="textbox">リッチテキスト</param>
        static void ChangeTextEvent(RichTextBox textbox)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                textbox.BeginInvoke((MethodInvoker)delegate
                {
                    textbox.TextChanged -= handler;
                });
            };
            textbox.TextChanged += handler;
        }
    }
}
