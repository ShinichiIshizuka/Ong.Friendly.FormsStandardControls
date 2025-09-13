using System;

using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using Codeer.Friendly.Windows.NativeStandardControls;
using System.Windows.Forms;

namespace TestNetCore
{
    /// <summary>
    /// Buttonテスト
    /// </summary>
    
    public class ButtonTest
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

        static void AAA()
        {

            var x = typeof(FormsControlBase).ToString();
            
        }



        /// <summary>
        /// EmulateClickのテスト
        /// </summary>
        [Test]
        public void TestButtonClick()
        {
            app.LoadAssembly(GetType().Assembly);
            app.LoadAssembly(typeof(Cell).Assembly);
            app.LoadAssembly(typeof(WindowControl).Assembly);
            app.LoadAssembly(typeof(FormsControlBase).Assembly);
            var cell = app.Dim(new Cell());
            string t = (string)cell["GetType"]()["Assembly"]()["ToString"]().Core;

            app[GetType(), "AAA"]();

            FormsButton button = new FormsButton(testDlg["button"]());
            button.EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(1, count);

            //非同期
            app[GetType(), "ClickEvent"](button.AppVar);
            button.EmulateClick(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(2, count);
        }

        /// <summary>
        /// クリック時にメッセージボックスを表示する
        /// </summary>
        /// <param name="button">ボタン</param>
        static void ClickEvent(Button button)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                button.BeginInvoke((MethodInvoker)delegate
                {
                    button.Click -= handler;
                });
            };
            button.Click += handler;
        }
    }
}
