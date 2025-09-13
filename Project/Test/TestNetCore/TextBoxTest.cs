using System;

using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace TestNetCore
{
    /// <summary>
    /// TextBoxテスト
    /// </summary>
    
    public class TextBoxTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// 初期化
        /// </summary>
        [SetUp]
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
        [TearDown]
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
            FormsTextBox textBox = new FormsTextBox(testDlg["textBox"]());
            textBox.EmulateChangeText("textBox");
            string textBoxText = textBox.Text;
            Assert.AreEqual("textBox", textBoxText);

            // 非同期
            app[GetType(), "ChangeTextEvent"](textBox.AppVar);
            textBox.EmulateChangeText("textBox1", new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            textBoxText = textBox.Text;
            Assert.AreEqual("textBox1", textBoxText);
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
