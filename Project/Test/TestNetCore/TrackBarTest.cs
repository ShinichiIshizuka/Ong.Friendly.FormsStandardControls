using System;

using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace TestNetCore
{
    /// <summary>
    /// TrackBarテスト
    /// </summary>
    
    public class TrackBarTest
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
        /// 最大値を取得をします
        /// </summary>
        [Test]
        public void TestGetMaximun()
        {
            var track = new FormsTrackBar(testDlg["_trackBar"]());
            int progressMax = track.Maximum;
            Assert.AreEqual(100, progressMax);
        }

        /// <summary>
        /// 最小値を取得をします
        /// </summary>
        [Test]
        public void TestGetMinimun()
        {
            var track = new FormsTrackBar(testDlg["_trackBar"]());
            int progressMin = track.Minimum;
            Assert.AreEqual(0, progressMin);
        }

        /// <summary>
        /// 現在値を取得をします
        /// </summary>
        [Test]
        public void TestValue()
        {
            var track = new FormsTrackBar(testDlg["_trackBar"]());
            int progressPos = track.Value;
            Assert.AreEqual(50, progressPos);
        }       
        
        /// <summary>
        /// EmulateChangeValueとValueのテスト
        /// </summary>
        [Test]
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
