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
    /// DataGridView�e�X�g
    /// </summary>
    [TestFixture]
    public class DataGridViewTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// ������
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            //�e�X�g�p�̉�ʋN��
            app = new WindowsAppFriend(Process.Start(Settings.TestApplicationPath), "2.0");
            testDlg = WindowControl.FromZTop(app);
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
        }

        /// <summary>
        /// �I��
        /// </summary>
        [TestFixtureTearDown]
        public void TearDown()
        {
            //�I������
            if (app != null)
            {
                app.Dispose();
                Process process = Process.GetProcessById(app.ProcessId);
                process.CloseMainWindow();
                app = null;
            }
        }

        /// <summary>
        /// RowCount�̃e�X�g
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
        /// ColumnCount�̃e�X�g
        /// </summary>
        [Test]
        public void TestColumnCount()
        {
            FormsDataGridView datagridview = new FormsDataGridView(app, testDlg["dataGridView"]());
            Assert.AreEqual(5, datagridview.ColumnCount);
        }

        /// <summary>
        /// EmulateChangeCurrentCell��CurrentCell�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeCurrentCellAndCurrentCell()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());
            dataGridview.EmulateChangeCurrentCell(2, 0);
            Assert.AreEqual(new Cell(2, 0), dataGridview.CurrentCell);

            //�񓯊�
            app[GetType(), "CurrentCellChangedEvent"](dataGridview.AppVar);
            dataGridview.EmulateChangeCurrentCell(1, 0, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(new Cell(1, 0), dataGridview.CurrentCell);
        }

        /// <summary>
        /// �I��ύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="grid">�O���b�h</param>
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
        /// EmulateChangeCellSelected��SelectedCells�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeCellSelectedAndSelectedCells()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());
            dataGridview.EmulateClearSelection();
            dataGridview.EmulateChangeCellSelected(new CellSelectedInfo(1, 0, true), new CellSelectedInfo(2, 0, true));
            Assert.AreEqual(new Cell[] { new Cell(1, 0), new Cell(2, 0) }, dataGridview.SelectedCells);

            //�񓯊�
            app[GetType(), "SelectionChangedEvent"](dataGridview.AppVar);
            dataGridview.EmulateChangeCellSelected(new Async(), new CellSelectedInfo(1, 0, false));
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(new Cell[] { new Cell(2, 0) }, dataGridview.SelectedCells);
        }

        /// <summary>
        /// EmulateChangeRowSelected��SelectedRows�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeRowSelectedSelectedRows()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //�s�ǉ�
            dataGridview.EmulateCellCheck(1, 0, true);
            dataGridview.EmulateCellCheck(1, 1, true);
            dataGridview.EmulateCellCheck(1, 2, true);

            //�s�I���e�X�g
            dataGridview.EmulateClearSelection();
            dataGridview.EmulateChangeRowSelected(new RowSelectedInfo(1,true), new RowSelectedInfo(2, true));
            Assert.AreEqual(new int[] { 1, 2 }, dataGridview.SelectedRows);

            //�񓯊�
            app[GetType(), "SelectionChangedEvent"](dataGridview.AppVar);
            dataGridview.EmulateChangeRowSelected(new Async(), new RowSelectedInfo(1, false));
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(new int[] { 2 }, dataGridview.SelectedRows);

            //�s�N���A
            dataGridview["Rows"]()["Clear"]();
        }

        /// <summary>
        /// EmulateClearSelection�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateClearSelection()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());
            dataGridview.EmulateChangeCellSelected(new CellSelectedInfo(1, 0, true), new CellSelectedInfo(2, 0, true));
            dataGridview.EmulateClearSelection();
            Assert.AreEqual(new Cell[] {}, dataGridview.SelectedCells);

            //�񓯊�
            dataGridview.EmulateChangeCellSelected(new CellSelectedInfo(1, 0, true), new CellSelectedInfo(2, 0, true));
            app[GetType(), "SelectionChangedEvent"](dataGridview.AppVar);
            dataGridview.EmulateClearSelection(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(new Cell[] { }, dataGridview.SelectedCells);
        }

        /// <summary>
        /// �I��ύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="grid">�O���b�h</param>
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
        /// GetText�̃e�X�g
        /// </summary>
        [Test]
        public void TestGetText()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //�e�X�g�f�[�^
            dataGridview.EmulateChangeCellText(0, 0, "a");
            dataGridview.EmulateChangeCellText(0, 1, "b");
            dataGridview.EmulateChangeCellText(0, 2, "c");
            dataGridview.EmulateCellCheck(1, 0, true);
            dataGridview.EmulateCellCheck(1, 2, true);

            Assert.AreEqual("b", dataGridview.GetText(0, 1));
            Assert.AreEqual(new string[][] { new string[] { "a", true.ToString() }, 
                new string[] { "b", string.Empty }, 
                new string[] { "c", true.ToString() } }, dataGridview.GetText(0, 0, 1, 2));

            //�s�N���A
            dataGridview["Rows"]()["Clear"]();
        }


        /// <summary>
        /// EmulateDelete�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateDelete()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //�s�ǉ�
            dataGridview.EmulateCellCheck(1, 0, true);
            dataGridview.EmulateCellCheck(1, 1, true);
            dataGridview.EmulateCellCheck(1, 2, true);

            //�폜
            dataGridview.EmulateClearSelection();
            dataGridview.EmulateChangeRowSelected(new RowSelectedInfo(1, true));
            dataGridview.EmulateDelete();
            Assert.AreEqual(3, dataGridview.RowCount);

            //�񓯊�
            dataGridview.EmulateClearSelection();
            dataGridview.EmulateChangeRowSelected(new RowSelectedInfo(1, true));
            app[GetType(), "UserDeletedRowEvent"](dataGridview.AppVar);
            dataGridview.EmulateDelete(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(2, dataGridview.RowCount);

            //�s�N���A
            dataGridview["Rows"]()["Clear"]();
        }

        /// <summary>
        /// �s�폜���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="grid">�O���b�h</param>
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
        /// EmulateCellCheck�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateCellCheck()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //�`�F�b�N
            dataGridview.EmulateCellCheck(1, 0, true);
            Assert.AreEqual(true.ToString(), dataGridview.GetText(1, 0));

            //�񓯊�
            app[GetType(), "CellEndEditEvent"](dataGridview.AppVar);
            dataGridview.EmulateCellCheck(1, 0, false, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(false.ToString(), dataGridview.GetText(1, 0));

            //�s�N���A
            dataGridview["Rows"]()["Clear"]();
        }

        /// <summary>
        /// EmulateChangeCellText�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeCellText()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //�e�L�X�g�ύX
            dataGridview.EmulateChangeCellText(0, 0, "abc");
            Assert.AreEqual("abc", dataGridview.GetText(0, 0));

            //�񓯊�
            app[GetType(), "CellEndEditEvent"](dataGridview.AppVar);
            dataGridview.EmulateChangeCellText(0, 0, "efg", new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual("efg", dataGridview.GetText(0, 0));

            //�s�N���A
            dataGridview["Rows"]()["Clear"]();
        }

        /// <summary>
        /// EmulateChangeCellComboSelect�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeCellComboSelect()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //�e�L�X�g�ύX
            dataGridview.EmulateChangeCellComboSelect(2, 0, 2);
            Assert.AreEqual("2", dataGridview.GetText(2, 0));

            //�񓯊�
            app[GetType(), "CellEndEditEvent"](dataGridview.AppVar);
            dataGridview.EmulateChangeCellComboSelect(2, 0, 3, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual("3", dataGridview.GetText(2, 0));

            //�s�N���A
            dataGridview["Rows"]()["Clear"]();
        }

        /// <summary>
        /// �ҏW�I�����Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="grid">�O���b�h</param>
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
        /// EmulateClickCellContent�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateClickCellContent()
        {
            FormsDataGridView dataGridview = new FormsDataGridView(app, testDlg["dataGridView"]());

            //�s�ǉ�
            dataGridview.EmulateCellCheck(1, 0, true);

            //�{�^���N���b�N
            app[GetType(), "_testCol"](-1);
            app[GetType(), "CellContentClickEvent"](dataGridview.AppVar);
            dataGridview.EmulateClickCellContent(3, 0);
            Assert.AreEqual(3, (int)app[GetType(), "_testCol"]().Core);

            //�����N�N���b�N
            app[GetType(), "_testCol"](-1);
            app[GetType(), "CellContentClickEvent"](dataGridview.AppVar);
            dataGridview.EmulateClickCellContent(4, 0);
            Assert.AreEqual(4, (int)app[GetType(), "_testCol"]().Core);

            //�񓯊�
            app[GetType(), "_testCol"](-1);
            app[GetType(), "CellContentClickEventMessage"](dataGridview.AppVar);
            dataGridview.EmulateClickCellContent(3, 0, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(3, (int)app[GetType(), "_testCol"]().Core);

            //�s�N���A
            dataGridview["Rows"]()["Clear"]();
        }
        */
        static int _testCol;

        /// <summary>
        /// �Z���N���b�N���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="grid">�O���b�h</param>
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
        /// �Z���N���b�N���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="grid">�O���b�h</param>
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
