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
        /// </summary>
        [Test]
        public void TestRadioButtonCheck()
        {
            //同期処理
            FormsRadioButton radiobutton1 = new FormsRadioButton(app, testDlg["radioButton1"]());
            radiobutton1.EmulateCheck();
            Assert.AreEqual(true, radiobutton1.Checked);

            //非同期実行
            FormsRadioButton radiobutton2 = new FormsRadioButton(app, testDlg["radioButton2"]());
            radiobutton2.EmulateCheck(new Async());
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(11, count);
        }

        /// <summary>
        /// テキストを取得します
        /// </summary>
        [Test]
        public void TestRadioButtonTextGet()
        {
            FormsRadioButton radiobutton1 = new FormsRadioButton(app, testDlg["radioButton1"]());
            String radiobutton1Text = radiobutton1.Text;
            Assert.AreEqual("radioButton1", radiobutton1Text);
        }
    }
}
