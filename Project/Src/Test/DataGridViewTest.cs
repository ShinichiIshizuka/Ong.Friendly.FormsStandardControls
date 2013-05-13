using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
namespace Test
{
    /// <summary>
    /// DataGridViewテスト
    /// </summary>
    [TestFixture]
    public class DataGridViewTest
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
        /// 行数と列数数取得
        /// </summary>
        [Test]
        public void TestDataGridViewRowColCount()
        {
            FormsDataGridView datagridview1 = new FormsDataGridView(app, testDlg["dataGridView1"]());
            Assert.AreEqual(6, datagridview1.RowCount);
            Assert.AreEqual(3, datagridview1.ColumnCount);
        }

        /// <summary>
        /// 指定した行列のテキスト変更
        /// </summary>
        [Test]
        public void TestDataGridViewChangeText()
        {
            FormsDataGridView datagridview1 = new FormsDataGridView(app, testDlg["dataGridView1"]());
            datagridview1.EmulateChangeText(1, 1, "変更",new Async());
        }

        /// <summary>
        /// 指定した行列のテキスト取得
        /// </summary>
        [Test]
        public void TestDataGridViewGetText()
        {
            FormsDataGridView datagridview1 = new FormsDataGridView(app, testDlg["dataGridView1"]());
            Assert.AreEqual("変更", datagridview1.GetText(1, 1));
        }
    }
}
