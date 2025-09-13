
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using TestNetCore;

namespace TestNetCore
{
    /// <summary>
    /// Buttonテスト
    /// </summary>
    
    public class BaseTest
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
        /// Textのテスト
        /// </summary>
        [Test]
        public void TestText()
        {
            FormsButton button = new FormsButton(testDlg["button"]());
            button["Text"]("abc");
            Assert.AreEqual("abc", button.Text);
        }

        /// <summary>
        /// Visibleのテスト
        /// </summary>
        [Test]
        public void TestVisible()
        {
            FormsButton button = new FormsButton(testDlg["button"]());
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
            FormsButton button = new FormsButton(testDlg["button"]());
            button["Enabled"](false);
            Assert.IsFalse(button.Enabled);
            button["Enabled"](true);
            Assert.IsTrue(button.Enabled);
        }
    }
}
