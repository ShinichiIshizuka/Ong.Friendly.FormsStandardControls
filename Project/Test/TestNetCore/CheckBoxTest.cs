using System;

using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace TestNetCore
{
    /// <summary>
    /// CheckBoxテスト
    /// </summary>
    
    public class CheckBoxTest
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
        /// チェックテスト
        /// EmulateCheck
        /// CheckState
        /// の両方をテスト
        /// </summary>
        [Test]
        public void TestCheckBoxCheck()
        {
            FormsCheckBox checkbox = new FormsCheckBox(testDlg["checkBox"]());
            checkbox.EmulateCheck(CheckState.Checked);
            Assert.AreEqual(CheckState.Checked, checkbox.CheckState);

            //非同期
            app[GetType(), "CheckedChangeEvent"](checkbox.AppVar);
            checkbox.EmulateCheck(CheckState.Unchecked, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(CheckState.Unchecked, checkbox.CheckState);
        }

        /// <summary>
        /// 状態変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="checkBox">チェックボックス</param>
        static void CheckedChangeEvent(CheckBox checkBox)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                checkBox.BeginInvoke((MethodInvoker)delegate
                {
                    checkBox.CheckedChanged -= handler;
                });
            };
            checkBox.CheckedChanged += handler;
        }
    }
}
