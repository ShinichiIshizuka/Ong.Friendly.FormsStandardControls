using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;

namespace Test
{
    /// <summary>
    /// ListViewテスト
    /// </summary>
    [TestFixture]
    public class ListViewTest
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
        /// 行数と列数を取得します
        /// </summary>
        [Test]
        public void ListViewRowColumnCount()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual(4, listView1.RowCount);
            Assert.AreEqual(3, listView1.ColumnCount);
        }

        /// <summary>
        /// リストアイテムをテキストで検索して選択します
        /// </summary>
        [Test]
        public void ListViewFindListItemAndSelect()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            FormsListViewItem item = listView1.FindItem("リンゴ");
            Assert.NotNull(item);
            listView1.EmulateItemSelect(item.RowIndex, new Async());
            Assert.AreEqual(3, listView1.SelectItem.RowIndex);
        }

        /// <summary>
        /// 行を選択し選択されたリストアイテムのテキストを取得します
        /// </summary>
        [Test]
        public void ListViewSelectAndTextGet()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            listView1.EmulateItemSelect(1, new Async());
            Assert.AreEqual("ピーマン", listView1.SelectItem.Text);
        }

        /// <summary>
        /// アイテムをチェックします
        /// </summary>
        [Test]
        public void ListViewItemCheck()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            FormsListViewItem item = listView1.FindItem("リンゴ");
            item.EmulateCheck(true);
            Assert.IsTrue(item.Checked);
        }
    }
}
