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
    /// <summary>
    /// Progressテスト
    /// </summary>
    [TestClass]
    public class ProgressBarTest
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
        /// 最大値を取得をします
        /// </summary>
        [TestMethod]
        public void TestGetMaximun()
        {
            FormsProgressBar progress = new FormsProgressBar(app, testDlg["progressBar"]());
            int progressMax = progress.Max;
            Assert.AreEqual(100, progressMax);
        }

        /// <summary>
        /// 最小値を取得をします
        /// </summary>
        [TestMethod]
        public void TestGetMinimun()
        {
            FormsProgressBar progress = new FormsProgressBar(app, testDlg["progressBar"]());
            int progressMin = progress.Min;
            Assert.AreEqual(0, progressMin);
        }

        /// <summary>
        /// 現在値を取得をします
        /// </summary>
        [TestMethod]
        public void TestGetPos()
        {
            FormsProgressBar progress = new FormsProgressBar(app, testDlg["progressBar"]());
            int progressPos = progress.Pos;
            Assert.AreEqual(50, progressPos);
        }
    }
}
