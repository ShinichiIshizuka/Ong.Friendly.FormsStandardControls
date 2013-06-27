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
        /// RowCountのテスト
        /// </summary>
        [Test]
        public void TestRowCount()
        {
            FormsDataGridView datagridview = new FormsDataGridView(app, testDlg["dataGridView"]());
            datagridview.EmulateChangeCellText(0, 0, "a");
            Assert.AreEqual(2, datagridview.RowCount);
            datagridview["Rows"]()["Clear"]();
        }

        /// <summary>
        /// ColumnCountのテスト
        /// </summary>
        [Test]
        public void TestColumnCount()
        {
            FormsDataGridView datagridview = new FormsDataGridView(app, testDlg["dataGridView"]());
            Assert.AreEqual(5, datagridview.ColumnCount);
        }

        /// <summary>
        /// EmulateChangeCurrentCellとCurrentCellのテスト
        /// </summary>
        [Test]
        public void TestEmulateChangeCurrentCellAndCurrentCell()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());
            dataGridview.EmulateChangeCurrentCell(2, 0);
            Assert.AreEqual(new Cell(2, 0), dataGridview.CurrentCell);

            //非同期
            app[GetType(), "CurrentCellChangedEvent"](dataGridview.AppVar);
            dataGridview.EmulateChangeCurrentCell(1, 0, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(new Cell(1, 0), dataGridview.CurrentCell);
        }

        /// <summary>
        /// 選択変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="grid">グリッド</param>
        static void CurrentCellChangedEvent(DataGridView grid)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                grid.BeginInvoke((MethodInvoker)delegate
                {
                    grid.CurrentCellChanged -= handler;
                });
            };
            grid.CurrentCellChanged += handler;
        }

        /// <summary>
        /// EmulateChangeCellSelectedとSelectedCellsのテスト
        /// </summary>
        [Test]
        public void TestEmulateChangeCellSelectedAndSelectedCells()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());
            dataGridview.EmulateClearSelection();
            dataGridview.EmulateChangeCellSelected(new CellSelectedInfo(1, 0, true), new CellSelectedInfo(2, 0, true));
            Assert.AreEqual(new Cell[] { new Cell(1, 0), new Cell(2, 0) }, dataGridview.SelectedCells);

            //非同期
            app[GetType(), "SelectionChangedEvent"](dataGridview.AppVar);
            dataGridview.EmulateChangeCellSelected(new Async(), new CellSelectedInfo(1, 0, false));
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(new Cell[] { new Cell(2, 0) }, dataGridview.SelectedCells);
        }

        /// <summary>
        /// EmulateChangeRowSelectedとSelectedRowsのテスト
        /// </summary>
        [Test]
        public void TestEmulateChangeRowSelectedSelectedRows()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //行追加
            dataGridview.EmulateCellCheck(1, 0, true);
            dataGridview.EmulateCellCheck(1, 1, true);
            dataGridview.EmulateCellCheck(1, 2, true);

            //行選択テスト
            dataGridview.EmulateClearSelection();
            dataGridview.EmulateChangeRowSelected(new RowSelectedInfo(1,true), new RowSelectedInfo(2, true));
            Assert.AreEqual(new int[] { 1, 2 }, dataGridview.SelectedRows);

            //非同期
            app[GetType(), "SelectionChangedEvent"](dataGridview.AppVar);
            dataGridview.EmulateChangeRowSelected(new Async(), new RowSelectedInfo(1, false));
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(new int[] { 2 }, dataGridview.SelectedRows);

            //行クリア
            dataGridview["Rows"]()["Clear"]();
        }

        /// <summary>
        /// EmulateClearSelectionのテスト
        /// </summary>
        [Test]
        public void TestEmulateClearSelection()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());
            dataGridview.EmulateChangeCellSelected(new CellSelectedInfo(1, 0, true), new CellSelectedInfo(2, 0, true));
            dataGridview.EmulateClearSelection();
            Assert.AreEqual(new Cell[] {}, dataGridview.SelectedCells);

            //非同期
            dataGridview.EmulateChangeCellSelected(new CellSelectedInfo(1, 0, true), new CellSelectedInfo(2, 0, true));
            app[GetType(), "SelectionChangedEvent"](dataGridview.AppVar);
            dataGridview.EmulateClearSelection(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(new Cell[] { }, dataGridview.SelectedCells);
        }

        /// <summary>
        /// 選択変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="grid">グリッド</param>
        static void SelectionChangedEvent(DataGridView grid)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                grid.BeginInvoke((MethodInvoker)delegate
                {
                    grid.SelectionChanged -= handler;
                });
            };
            grid.SelectionChanged += handler;
        }
        
        /// <summary>
        /// GetTextのテスト
        /// </summary>
        [Test]
        public void TestGetText()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //テストデータ
            dataGridview.EmulateChangeCellText(0, 0, "a");
            dataGridview.EmulateChangeCellText(0, 1, "b");
            dataGridview.EmulateChangeCellText(0, 2, "c");
            dataGridview.EmulateCellCheck(1, 0, true);
            dataGridview.EmulateCellCheck(1, 2, true);

            Assert.AreEqual("b", dataGridview.GetText(0, 1));
            Assert.AreEqual(new string[][] { new string[] { "a", true.ToString() }, 
                new string[] { "b", string.Empty }, 
                new string[] { "c", true.ToString() } }, dataGridview.GetText(0, 0, 1, 2));

            //行クリア
            dataGridview["Rows"]()["Clear"]();
        }


        /// <summary>
        /// EmulateDeleteのテスト
        /// </summary>
        [Test]
        public void TestEmulateDelete()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //行追加
            dataGridview.EmulateCellCheck(1, 0, true);
            dataGridview.EmulateCellCheck(1, 1, true);
            dataGridview.EmulateCellCheck(1, 2, true);

            //削除
            dataGridview.EmulateClearSelection();
            dataGridview.EmulateChangeRowSelected(new RowSelectedInfo(1, true));
            dataGridview.EmulateDelete();
            Assert.AreEqual(3, dataGridview.RowCount);

            //非同期
            dataGridview.EmulateClearSelection();
            dataGridview.EmulateChangeRowSelected(new RowSelectedInfo(1, true));
            app[GetType(), "UserDeletedRowEvent"](dataGridview.AppVar);
            dataGridview.EmulateDelete(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(2, dataGridview.RowCount);

            //行クリア
            dataGridview["Rows"]()["Clear"]();
        }

        /// <summary>
        /// 行削除時にメッセージボックスを表示する
        /// </summary>
        /// <param name="grid">グリッド</param>
        static void UserDeletedRowEvent(DataGridView grid)
        {
            DataGridViewRowEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                grid.BeginInvoke((MethodInvoker)delegate
                {
                    grid.UserDeletedRow -= handler;
                });
            };
            grid.UserDeletedRow += handler;
        }

        /// <summary>
        /// EmulateCellCheckのテスト
        /// </summary>
        [Test]
        public void TestEmulateCellCheck()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //チェック
            dataGridview.EmulateCellCheck(1, 0, true);
            Assert.AreEqual(true.ToString(), dataGridview.GetText(1, 0));

            //非同期
            app[GetType(), "CellEndEditEvent"](dataGridview.AppVar);
            dataGridview.EmulateCellCheck(1, 0, false, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(false.ToString(), dataGridview.GetText(1, 0));

            //行クリア
            dataGridview["Rows"]()["Clear"]();
        }

        /// <summary>
        /// EmulateChangeCellTextのテスト
        /// </summary>
        [Test]
        public void TestEmulateChangeCellText()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //テキスト変更
            dataGridview.EmulateChangeCellText(0, 0, "abc");
            Assert.AreEqual("abc", dataGridview.GetText(0, 0));

            //非同期
            app[GetType(), "CellEndEditEvent"](dataGridview.AppVar);
            dataGridview.EmulateChangeCellText(0, 0, "efg", new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual("efg", dataGridview.GetText(0, 0));

            //行クリア
            dataGridview["Rows"]()["Clear"]();
        }

        /// <summary>
        /// EmulateChangeCellComboSelectのテスト
        /// </summary>
        [Test]
        public void TestEmulateChangeCellComboSelect()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //テキスト変更
            dataGridview.EmulateChangeCellComboSelect(2, 0, 2);
            Assert.AreEqual("2", dataGridview.GetText(2, 0));

            //非同期
            app[GetType(), "CellEndEditEvent"](dataGridview.AppVar);
            dataGridview.EmulateChangeCellComboSelect(2, 0, 3, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual("3", dataGridview.GetText(2, 0));

            //行クリア
            dataGridview["Rows"]()["Clear"]();
        }

        /// <summary>
        /// 編集終了時にメッセージボックスを表示する
        /// </summary>
        /// <param name="grid">グリッド</param>
        static void CellEndEditEvent(DataGridView grid)
        {
            DataGridViewCellEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                grid.BeginInvoke((MethodInvoker)delegate
                {
                    grid.CellEndEdit -= handler;
                });
            };
            grid.CellEndEdit += handler;
        }
        /*@@@
        /// <summary>
        /// EmulateClickCellContentのテスト
        /// </summary>
        [Test]
        public void TestEmulateClickCellContent()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //行追加
            dataGridview.EmulateCellCheck(1, 0, true);

            //ボタンクリック
            app[GetType(), "_testCol"](-1);
            app[GetType(), "CellContentClickEvent"](dataGridview.AppVar);
            dataGridview.EmulateClickCellContent(3, 0);
            Assert.AreEqual(3, (int)app[GetType(), "_testCol"]().Core);

            //リンククリック
            app[GetType(), "_testCol"](-1);
            app[GetType(), "CellContentClickEvent"](dataGridview.AppVar);
            dataGridview.EmulateClickCellContent(4, 0);
            Assert.AreEqual(4, (int)app[GetType(), "_testCol"]().Core);

            //非同期
            app[GetType(), "_testCol"](-1);
            app[GetType(), "CellContentClickEventMessage"](dataGridview.AppVar);
            dataGridview.EmulateClickCellContent(3, 0, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(3, (int)app[GetType(), "_testCol"]().Core);

            //行クリア
            dataGridview["Rows"]()["Clear"]();
        }
        */
        static int _testCol;

        /// <summary>
        /// セルクリック時にメッセージボックスを表示する
        /// </summary>
        /// <param name="grid">グリッド</param>
        static void CellContentClickEvent(DataGridView grid)
        {
            DataGridViewCellEventHandler handler = null;
            handler = delegate(object sender, DataGridViewCellEventArgs e)
            {
                _testCol = e.ColumnIndex;
                grid.BeginInvoke((MethodInvoker)delegate
                {
                    grid.CellContentClick -= handler;
                });
            };
            grid.CellEndEdit += handler;
        }

        /// <summary>
        /// セルクリック時にメッセージボックスを表示する
        /// </summary>
        /// <param name="grid">グリッド</param>
        static void CellContentClickEventMessage(DataGridView grid)
        {
            DataGridViewCellEventHandler handler = null;
            handler = delegate(object sender, DataGridViewCellEventArgs e)
            {
                _testCol = e.ColumnIndex;
                MessageBox.Show("");
                grid.BeginInvoke((MethodInvoker)delegate
                {
                    grid.CellContentClick -= handler;
                });
            };
            grid.CellEndEdit += handler;
        }
        //@@@

        //
        //
        //
        //
    }
}
