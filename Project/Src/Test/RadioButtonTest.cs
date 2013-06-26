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
    /// RadioButtonテスト
    /// </summary>
    [TestFixture]
    public class RadioButtonTest
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
        /// チェックテスト
        /// EmulateCheck
        /// Checked
        /// の両方をテスト
        /// </summary>
        [Test]
        public void TestCheckBoxCheck()
        {
            FormsRadioButton radiobutton1 = new FormsRadioButton(app, testDlg["radioButton1"]());
            radiobutton1.EmulateCheck();
            Assert.AreEqual(true, radiobutton1.Checked);

            //非同期
            FormsRadioButton radiobutton2 = new FormsRadioButton(app, testDlg["radioButton2"]());
            app[GetType(), "CheckedChangeEvent"](radiobutton2.AppVar);
            radiobutton2.EmulateCheck(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(11, count);
        }

        /// <summary>
        /// 状態変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="radioButton">チェックボックス</param>
        static void CheckedChangeEvent(RadioButton radioButton)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                radioButton.BeginInvoke((MethodInvoker)delegate
                {
                    radioButton.CheckedChanged -= handler;
                });
            };
            radioButton.CheckedChanged += handler;
        }
    }
}
