
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace TestNetCore
{
    /// <summary>
    /// TabControlテスト
    /// </summary>
    
    public class TabControlTest
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
        /// TabCountテスト
        /// </summary>
        [Test]
        public void TestTabCount()
        {
            FormsTabControl tabControl = new FormsTabControl(testDlg["tabControl"]());
            Assert.AreEqual(3, tabControl.TabCount);
        }

        /// <summary>
        /// SelectedIndexテスト
        /// </summary>
        [Test]
        public void TestSelectedIndex()
        {
            FormsTabControl tabControl = new FormsTabControl(testDlg["tabControl"]());
            tabControl.EmulateTabSelect(2);
            Assert.AreEqual(2, tabControl.SelectedIndex);
        }

        /// <summary>
        /// EmulateTabSelect
        /// </summary>
        [Test]
        public void TestTabSelect()
        {
            FormsTabControl tabControl = new FormsTabControl(testDlg["tabControl"]());
            tabControl.EmulateTabSelect(1);
            Assert.AreEqual(1, tabControl.SelectedIndex);

            //非同期
            app[GetType(), "TabSelectEvent"](tabControl.AppVar);
            tabControl.EmulateTabSelect(2, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(2, tabControl.SelectedIndex);
        }

        /// <summary>
        /// 状態変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="tabcontrol">タブコントロール</param>
        static void TabSelectEvent(TabControl tabcontrol)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                tabcontrol.BeginInvoke((MethodInvoker)delegate
                {
                    tabcontrol.SelectedIndexChanged -= handler;
                });
            };
            tabcontrol.SelectedIndexChanged += handler;
        }
    }
}
