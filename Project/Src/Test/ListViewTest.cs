using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;

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
            Assert.AreEqual(4, listView1.ItemCount);
            Assert.AreEqual(3, listView1.ColumnCount);
        }

        /// <summary>
        /// リストアイテムをテキストで検索して選択します
        /// </summary>
        [Test]
        public void ListViewFindListItemAndSelect()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            FormsListViewItem item = listView1.FindItemWithText("リンゴ", true, 0);
            Assert.NotNull(item);
            listView1.EmulateChangeSelectedState(item.ItemIndex,true ,new Async());
            Assert.AreEqual(3, listView1.SelectIndexes[0]);
        }

        /// <summary>
        /// 行を選択し選択されたリストアイテムのテキストを取得します
        /// </summary>
        [Test]
        public void ListViewSelectAndTextGet()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            listView1.EmulateChangeSelectedState(1, true, new Async());
            Assert.AreEqual("ピーマン", listView1.GetListViewItem(listView1.SelectIndexes[0]).Text);
        }

        /// <summary>
        /// アイテムをチェックします
        /// サブアイテムを含めてチェックします
        /// </summary>
        [Test]
        public void ListViewItemCheck()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            FormsListViewItem item1 = listView1.FindItemWithText("リンゴ", true, 0);
            item1.EmulateCheck(true);
            Assert.IsTrue(item1.Checked);
            FormsListViewItem item2 = listView1.FindItemWithText("野菜", true, 0);
            Assert.AreEqual("トマト", item2.Text);
        }

        /// <summary>
        /// Viewのスタイルを取得します
        /// </summary>
        [Test]
        public void ListViewStyle()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            View viewStyle = listView1.ViewMode;
            Assert.AreEqual(View.Details, viewStyle);
        }

        /// <summary>
        /// サブアイテムを取得します
        /// </summary>
        [Test]
        public void ListViewGetSubItem()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            FormsListViewItem item1 = listView1.FindItemWithText("リンゴ", true , 0);
            FormsListViewSubItem subitem1 = item1.GetSubItem(1);
            Assert.AreEqual("果物", subitem1.Text);
        }
    }
}
