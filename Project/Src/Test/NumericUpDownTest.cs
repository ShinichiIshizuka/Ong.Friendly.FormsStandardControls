using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace Test
{
    /// <summary>
    /// NumericUpDownテスト
    /// </summary>
    [TestFixture]
    public class NumericUpDownTest
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
        /// EmulateChangeValueとValueのテスト
        /// </summary>
        [Test]
        public void TestEmulateChangeValueAndValue()
        {
            FormsNumericUpDown numericUpDown = new FormsNumericUpDown(app, testDlg["numericUpDown"]());
            numericUpDown.EmulateChangeValue(50);
            Assert.AreEqual(50, numericUpDown.Value);

            // 非同期
            app[GetType(), "ValueChangedEvent"](numericUpDown.AppVar);
            numericUpDown.EmulateChangeValue(80, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(80, numericUpDown.Value);
        }

        /// <summary>
        /// Minimumのテスト
        /// </summary>
        [Test]
        public void TestMinimum()
        {
            FormsNumericUpDown numericUpDown = new FormsNumericUpDown(app, testDlg["numericUpDown"]());
            Assert.AreEqual(0, numericUpDown.Minimum);
        }

        /// <summary>
        /// Maximumのテスト
        /// </summary>
        [Test]
        public void TestMaximum()
        {
            FormsNumericUpDown numericUpDown = new FormsNumericUpDown(app, testDlg["numericUpDown"]());
            Assert.AreEqual(100, numericUpDown.Maximum);
        }

        /// <summary>
        /// 変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="numericupdown">NumericUpDown</param>
        static void ValueChangedEvent(NumericUpDown numericupdown)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                numericupdown.BeginInvoke((MethodInvoker)delegate
                {
                    numericupdown.ValueChanged -= handler;
                });
            };
            numericupdown.ValueChanged += handler;
        }
    }
}
