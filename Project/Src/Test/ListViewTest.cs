using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using Codeer.Friendly.Windows.NativeStandardControls;

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
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
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
        /// ItemCountのテスト
        /// </summary>
        [Test]
        public void TestItemCount()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual(4, listView1.ItemCount);
        }

        /// <summary>
        /// ColumnCountのテスト
        /// </summary>
        [Test]
        public void TestColumnCount()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual(3, listView.ColumnCount);
        }

        /// <summary>
        /// ViewModeのテスト
        /// </summary>
        [Test]
        public void TestViewMode()
        {
            FormsListView listView1 = new FormsListView(app, testDlg["listView1"]());
            View viewStyle = listView1.ViewMode;
            Assert.AreEqual(View.Details, viewStyle);
        }

        /// <summary>
        /// SelectIndexesのテスト
        /// </summary>
        [Test]
        public void TestSelectIndexes()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());

            //初期化
            for (int i = 0; i < listView.ItemCount; i++)
            {
                listView.EmulateChangeSelectedState(i, false);
            }

            listView.EmulateChangeSelectedState(0, true);
            listView.EmulateChangeSelectedState(2, true);
            Assert.AreEqual(new int[]{0, 2}, listView.SelectIndexes);
        }

        /// <summary>
        /// GetListViewItemのテスト
        /// </summary>
        [Test]
        public void TestGetListViewItem()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual("ピーマン", listView.GetListViewItem(1).Text);
        }

        /// <summary>
        /// FindItemWithTextのテスト
        /// </summary>
        [Test]
        public void TestFindItemWithText()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual("ピーマン", listView.FindItemWithText("ピーマン", true, 0).Text);
            Assert.IsNull(listView.FindItemWithText("ピーマン", true, 2));
        }

        /// <summary>
        /// EmulateChangeSelectedStateのテスト
        /// </summary>
        [Test]
        public void TestEmulateChangeSelectedState()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());

            //初期化
            for (int i = 0; i < listView.ItemCount; i++)
            {
                listView.EmulateChangeSelectedState(i, false);
            }

            listView.EmulateChangeSelectedState(0, true);
            Assert.AreEqual(new int[] { 0 }, listView.SelectIndexes);

            //非同期
            app[GetType(), "SelectEvent"](listView.AppVar);
            listView.EmulateChangeSelectedState(2, true, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(new int[] { 0, 2 }, listView.SelectIndexes);
        }

        /// <summary>
        /// 選択変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="listView">リストビュー</param>
        static void SelectEvent(ListView listView)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                listView.BeginInvoke((MethodInvoker)delegate
                {
                    listView.SelectedIndexChanged -= handler;
                });
            };
            listView.SelectedIndexChanged += handler;
        }

        /// <summary>
        /// ListViewItemのTextのテスト
        /// </summary>
        [Test]
        public void TestItemText()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual("ピーマン", listView.GetListViewItem(1).Text);
        }

        /// <summary>
        /// ListViewItemのItemIndexのテスト
        /// </summary>
        [Test]
        public void TestItemIndex()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual(1, listView.GetListViewItem(1).ItemIndex);
        }

        /// <summary>
        /// GetSubItemとSubItemのTextのテスト
        /// </summary>
        [Test]
        public void TestGetSubItemAndSubItemText()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            Assert.AreEqual("野菜", listView.GetListViewItem(1).GetSubItem(1).Text);
        }

        /// <summary>
        /// ListViewItemのEmulateCheckとCheckedのテスト
        /// </summary>
        [Test]
        public void TestItemEmulateCheckAndChecked()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            FormsListViewItem item = listView.GetListViewItem(1);
            item.EmulateCheck(true);
            Assert.AreEqual(true, item.Checked);

            //非同期
            app[GetType(), "CheckedEvent"](listView.AppVar);
            item.EmulateCheck(false, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(false, item.Checked);
        }

        /// <summary>
        /// チェック変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="listView">リストビュー</param>
        static void CheckedEvent(ListView listView)
        {
            ItemCheckedEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                listView.BeginInvoke((MethodInvoker)delegate
                {
                    listView.ItemChecked -= handler;
                });
            };
            listView.ItemChecked += handler;
        }

        /// <summary>
        /// EmulateEditLabelのテスト
        /// </summary>
        [Test]
        public void TestItemEmulateEditLabel()
        {
            FormsListView listView = new FormsListView(app, testDlg["listView1"]());
            FormsListViewItem item = listView.GetListViewItem(1);
            string bk = item.Text;
            item.EmulateEditLabel("abc");
            Assert.AreEqual("abc", item.Text);

            //非同期
            app[GetType(), "LabelEditEvent"](listView.AppVar);
            item.EmulateEditLabel(bk, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(bk, item.Text);
        }

        /// <summary>
        /// ラベル変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="listView">リストビュー</param>
        static void LabelEditEvent(ListView listView)
        {
            LabelEditEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                listView.BeginInvoke((MethodInvoker)delegate
                {
                    listView.AfterLabelEdit -= handler;
                });
            };
            listView.AfterLabelEdit += handler;
        }
    }
}
