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
    /// TrackBarテスト
    /// </summary>
    [TestClass]
    public class TrackBarTest
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
            var track = new FormsTrackBar(testDlg["_trackBar"]());
            int progressMax = track.Maximum;
            Assert.AreEqual(100, progressMax);
        }

        /// <summary>
        /// 最小値を取得をします
        /// </summary>
        [TestMethod]
        public void TestGetMinimun()
        {
            var track = new FormsTrackBar(testDlg["_trackBar"]());
            int progressMin = track.Minimum;
            Assert.AreEqual(0, progressMin);
        }

        /// <summary>
        /// 現在値を取得をします
        /// </summary>
        [TestMethod]
        public void TestValue()
        {
            var track = new FormsTrackBar(testDlg["_trackBar"]());
            int progressPos = track.Value;
            Assert.AreEqual(50, progressPos);
        }       
        
        /// <summary>
        /// EmulateChangeValueとValueのテスト
        /// </summary>
        [TestMethod]
        public void TestEmulateChangeValueAndValue()
        {
            var track = new FormsTrackBar(testDlg["_trackBar"]());
            track.EmulateChangeValue(60);
            Assert.AreEqual(60, track.Value);

            // 非同期
            app[GetType(), "ValueChangedEvent"](track.AppVar);
            track.EmulateChangeValue(80, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(80, track.Value);
        }

        /// <summary>
        /// 変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="track">NumericUpDown</param>
        static void ValueChangedEvent(TrackBar track)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                track.BeginInvoke((MethodInvoker)delegate
                {
                    track.ValueChanged -= handler;
                });
            };
            track.ValueChanged += handler;
        }
    }
}
