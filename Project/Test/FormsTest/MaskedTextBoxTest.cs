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
    [TestClass]
    public class MaskedTextBoxTest
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
        /// テキスト設定・取得をします
        /// </summary>
        [TestMethod]
        public void TestDisplayText()
        {
            FormsMaskedTextBox textBox = new FormsMaskedTextBox(testDlg["_maskedTextBox"]());
            textBox.EmulateChangeText("12345");
            Assert.AreEqual("12345-____-____", textBox.DisplayText);
        }

        /// <summary>
        /// テキスト設定・取得をします
        /// </summary>
        [TestMethod]
        public void TestEmulateChangeText()
        {
            FormsMaskedTextBox textBox = new FormsMaskedTextBox(testDlg["_maskedTextBox"]());
            textBox.EmulateChangeText("12345-6789-0123");
            string textBoxText = textBox.Text;
            Assert.AreEqual("12345-6789-0123", textBoxText);

            // 非同期
            app[GetType(), "ChangeTextEvent"](textBox.AppVar);
            textBox.EmulateChangeText("1111122223333", new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            textBoxText = textBox.Text;
            Assert.AreEqual("11111-2222-3333", textBoxText);
        }

        /// <summary>
        /// テキスト変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="textbox">ボタン</param>
        static void ChangeTextEvent(MaskedTextBox textbox)
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
