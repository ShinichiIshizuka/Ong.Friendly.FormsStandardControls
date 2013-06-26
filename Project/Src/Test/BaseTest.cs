using NUnit.Framework;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using System.Diagnostics;
using Ong.Friendly.FormsStandardControls;

namespace Test
{
    /// <summary>
    /// Buttonテスト
    /// </summary>
    [TestFixture]
    public class BaseTest
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
        /// Textのテスト
        /// </summary>
        [Test]
        public void TestText()
        {
            FormsButton button = new FormsButton(app, testDlg["button1"]());
            button["Text"]("abc");
            Assert.AreEqual("abc", button.Text);
        }

        /// <summary>
        /// Visibleのテスト
        /// </summary>
        [Test]
        public void TestVisible()
        {
            FormsButton button = new FormsButton(app, testDlg["button1"]());
            button["Visible"](false);
            Assert.IsFalse(button.Visible);
            button["Visible"](true);
            Assert.IsTrue(button.Visible);
        }

        /// <summary>
        /// Enabledのテスト
        /// </summary>
        [Test]
        public void TestEnabled()
        {
            FormsButton button = new FormsButton(app, testDlg["button1"]());
            button["Enabled"](false);
            Assert.IsFalse(button.Enabled);
            button["Enabled"](true);
            Assert.IsTrue(button.Enabled);
        }
    }
}
