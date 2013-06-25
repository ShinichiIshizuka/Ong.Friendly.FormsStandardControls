using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
namespace Test
{
    /// <summary>
    /// TabControlテスト
    /// </summary>
    [TestFixture]
    public class TabControlTest
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
        /// TabCountテスト
        /// </summary>
        [Test]
        public void TestTabCount()
        {
            FormsTabControl tabcontrol1 = new FormsTabControl(app, testDlg["tabControl1"]());
            Assert.AreEqual(3, tabcontrol1.TabCount);
        }

        /// <summary>
        /// SelectedIndexテスト
        /// </summary>
        [Test]
        public void TestSelectedIndex()
        {
            FormsTabControl tabcontrol1 = new FormsTabControl(app, testDlg["tabControl1"]());
            tabcontrol1.EmulateTabSelect(2);
            Assert.AreEqual(2, tabcontrol1.SelectedIndex);
        }

        /// <summary>
        /// EmulateTabSelect
        /// @@@非同期
        /// </summary>
        [Test]
        public void TestTabSelect()
        {
            FormsTabControl tabcontrol1 = new FormsTabControl(app, testDlg["tabControl1"]());
            tabcontrol1.EmulateTabSelect(2,new Async());
        }
    }
}
