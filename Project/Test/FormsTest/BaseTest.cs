using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using System.Diagnostics;
using Ong.Friendly.FormsStandardControls;

namespace FormsTest
{
    /// <summary>
    /// Buttonテスト
    /// </summary>
    [TestClass]
    public class BaseTest
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
        /// Textのテスト
        /// </summary>
        [TestMethod]
        public void TestText()
        {
            FormsButton button = new FormsButton(testDlg["button"]());
            button["Text"]("abc");
            Assert.AreEqual("abc", button.Text);
        }

        /// <summary>
        /// Visibleのテスト
        /// </summary>
        [TestMethod]
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
        [TestMethod]
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
