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
            FormsTextBox textbox1 = new FormsTextBox(app, testDlg["textBox1"]());
            textbox1.EmulateChangeText("TEXTBOX1");
            string textbox1Text = textbox1.Text;
            Assert.AreEqual("TEXTBOX1", textbox1Text);

            // 非同期
            app[GetType(), "ChangeTextEvent"](textbox1.AppVar);
            textbox1.EmulateChangeText("TEXTBOX11", new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            textbox1Text = textbox1.Text;
            Assert.AreEqual("TEXTBOX11", textbox1Text);
        }

        /// <summary>
        /// テキスト変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="textbox">ボタン</param>
        static void ChangeTextEvent(TextBox textbox)
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
