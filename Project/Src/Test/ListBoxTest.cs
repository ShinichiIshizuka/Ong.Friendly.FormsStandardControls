using NUnit.Framework;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
namespace Test
{
    /// <summary>
    /// ListBoxテスト
    /// </summary>
    [TestFixture]
    public class ListBoxTest
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
        /// リストのアイテム数取得テスト
        /// </summary>
        [Test]
        public void TestListBoxItemCount()
        {
            FormsListBox listbox1 = new FormsListBox(app, testDlg["listBox1"]());
            int itemCount = listbox1.ItemCount;
            Assert.AreEqual(5, itemCount);
        }

        /// <summary>
        /// アイテムをテキストで検索し選択。そのアイテムのテキストとインデックスを取得します
        /// </summary>
        [Test]
        public void TestListBoxSelectAndItemTextGet()
        {
            FormsListBox listbox1 = new FormsListBox(app, testDlg["listBox1"]());
            int findIndex = listbox1.FindListIndex("Item-4");

            listbox1.EmulateChangeSelectedIndex(findIndex);

            Assert.AreEqual(3, listbox1.SelectedIndex);
        }

        /// <summary>
        /// リストアイテムを選択状態にします。選択一覧を取得します。
        /// </summary>
        [Test]
        public void TestSelectIndexes()
        {
            FormsListBox listbox2 = new FormsListBox(app, testDlg["listBox2"]());
            int[] select = new int[]{5};
            listbox2.EmulateChangeSelectedIndexes(select);
            int[] selected = listbox2.EmulateGetSelectedIndexes();
            Assert.AreEqual(1, selected.Length);
            Assert.AreEqual(5, selected[0]);
        }
    }
}
