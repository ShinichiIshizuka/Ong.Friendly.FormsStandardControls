using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.DataGridView.
    /// </summary>
#else
    /// <summary>
    /// Type��System.Windows.Forms.DataGridView�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
#endif
    public class FormsDataGridView : FormsControlBase
    {
#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="src">WindowControl object for the underlying control.</param>
#else
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���B</param>
#endif
        public FormsDataGridView(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsDataGridView(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// ���ݔ񐄏��ł��B
        /// FormsDataGridView(AppVar windowObject)���g�p���Ă��������B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
#endif
        [Obsolete("Please use FormsDataGridView(AppVar windowObject).", false)]
        public FormsDataGridView(WindowsAppFriend app, AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
#endif
        public FormsDataGridView(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the number of columns in the data grid.
        /// </summary>
#else
        /// <summary>
        /// �񐔂��擾���܂��B
        /// </summary>
#endif
        public int ColumnCount
        {
            get { return (int)(this["ColumnCount"]().Core); }
        }

#if ENG
        /// <summary>
        /// Returns the number of rows in the data grid.
        /// </summary>
#else
        /// <summary>
        /// �s�����擾���܂��B
        /// </summary>
#endif
        public int RowCount
        {
            get { return (int)(this["RowCount"]().Core); }
        }

#if ENG
        /// <summary>
        /// Returns the currently selected cell.
        /// </summary>
#else
        /// <summary>
        /// ���݂̑I���Z�����擾���܂��B
        /// </summary>
#endif
        public Cell CurrentCell
        {
            get { return (Cell)(App[GetType(), "GetCurrentCellInTarget"](AppVar).Core); }
        }

#if ENG
        /// <summary>
        /// Returns the currently selected cells.
        /// </summary>
#else
        /// <summary>
        /// ���݂̑I���Z�����擾���܂��B
        /// </summary>
#endif
        public Cell[] SelectedCells
        {
            get { return (Cell[])(App[GetType(), "GetSelectedCellsInTarget"](AppVar).Core); }
        }

#if ENG
        /// <summary>
        /// Returns the currently selected row numbers.
        /// </summary>
#else
        /// <summary>
        /// ���݂̑I���s���擾���܂��B
        /// </summary>
#endif
        public int[] SelectedRows
        {
            get { return (int[])(App[GetType(), "GetSelectedRowsInTarget"](AppVar).Core); }
        }

#if ENG
        /// <summary>
        /// Returns the text of a cell in the table.
        /// </summary>
        /// <param name="col">Column number of the cell.</param>
        /// <param name="row">Row number of the cell.</param>
        /// <returns>The cell's text.</returns>
#else
        /// <summary>
        /// �s��Ŏw�肵���Z���̃e�L�X�g���擾���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <returns>�e�L�X�g�B</returns>
#endif
        public string GetText(int col, int row)
        {
            return (string)(App[GetType(), "GetTextInTarget"](AppVar, col, row).Core);
        }

#if ENG
        /// <summary>
        /// Returns the text of the table cells in the specified range.
        /// </summary>
        /// <param name="startCol">Starting column number.</param>
        /// <param name="startRow">Starting row number.</param>
        /// <param name="endCol">Ending column number.</param>
        /// <param name="endRow">Ending row number.</param>
        /// <returns>Cell values.</returns>
#else
        /// <summary>
        /// �s��Ŏw�肵���͈͂̃Z���̃e�L�X�g���擾���܂��B
        /// </summary>
        /// <param name="startCol">�J�n��B</param>
        /// <param name="startRow">�J�n�s�B</param>
        /// <param name="endCol">�I����B</param>
        /// <param name="endRow">�I���s�B</param>
        /// <returns>�e�L�X�g�z��B</returns>
#endif
        public string[][] GetText(int startCol, int startRow, int endCol, int endRow)
        {
            return (string[][])(App[GetType(), "GetTextInTarget"](AppVar, startCol, startRow, endCol, endRow).Core);
        }

#if ENG
        /// <summary>
        /// Sets the checked state state of a cell.
        /// </summary>
        /// <param name="col">Column number of the cell.</param>
        /// <param name="row">Row number of the cell.</param>
        /// <param name="isChecked">Checked state to use.</param>
#else
        /// <summary>
        /// �Z���̃`�F�b�N��Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="isChecked">�`�F�b�N��ԁB</param>
#endif
        public void EmulateCellCheck(int col, int row, bool isChecked)
        {
            App[GetType(), "EmulateCellCheckInTarget"](AppVar, col, row, isChecked);
        }

#if ENG
        /// <summary>
        /// Sets the checked state state of a cell.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="col">Column number of the cell.</param>
        /// <param name="row">Row number of the cell.</param>
        /// <param name="isChecked">Checked state to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �Z���̃`�F�b�N��Ԃ�ύX���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="isChecked">�`�F�b�N��ԁB</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateCellCheck(int col, int row, bool isChecked, Async async)
        {
            App[GetType(), "EmulateCellCheckInTarget", async](AppVar, col, row, isChecked);
        }

#if ENG
        /// <summary>
        /// Modifies the text of a cell.
        /// </summary>
        /// <param name="col">Column number of the cell.</param>
        /// <param name="row">Row number of the cell.</param>
        /// <param name="text">The text to use.</param>
#else
        /// <summary>
        /// �Z���̃e�L�X�g��ύX���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="text">�e�L�X�g�B</param>
#endif
        public void EmulateChangeCellText(int col, int row, string text)
        {
            App[GetType(), "EmulateChangeCellTextInTarget"](AppVar, col, row, text);
        }

#if ENG
        /// <summary>
        /// Modifies the text of a cell.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="col">Column number of the cell.</param>
        /// <param name="row">Row number of the cell.</param>
        /// <param name="text">The text to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �Z���̃e�L�X�g��ύX���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="text">�e�L�X�g�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateChangeCellText(int col, int row, string text, Async async)
        {
            App[GetType(), "EmulateChangeCellTextInTarget", async](AppVar, col, row, text);
        }

#if ENG
        /// <summary>
        /// Sets the selected value of a combo box cell.
        /// </summary>
        /// <param name="col">Column number of the cell.</param>
        /// <param name="row">Row number of the cell.</param>
        /// <param name="index">The index to select.</param>
#else
        /// <summary>
        /// �Z���R���{�̑I����ύX���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
#endif
        public void EmulateChangeCellComboSelect(int col, int row, int index)
        {
            App[GetType(), "EmulateChangeCellComboSelectInTarget"](AppVar, col, row, index);
        }

#if ENG
        /// <summary>
        /// Sets the selected value of a combo box cell.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="col">Column number of the cell.</param>
        /// <param name="row">Row number of the cell.</param>
        /// <param name="index">The index to select.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �Z���R���{�̑I����ύX���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateChangeCellComboSelect(int col, int row, int index, Async async)
        {
            App[GetType(), "EmulateChangeCellComboSelectInTarget", async](AppVar, col, row, index);
        }

#if ENG
        /// <summary>
        /// Performs a click in a cell.
        /// </summary>
        /// <param name="col">Column number of the cell.</param>
        /// <param name="row">Row number of the cell.</param>
#else
        /// <summary>
        /// �Z���{�^���A�Z�������N���N���b�N���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
#endif
        public void EmulateClickCellContent(int col, int row)
        {
            App[GetType(), "EmulateClickCellContentInTarget"](AppVar, col, row);
        }

#if ENG
        /// <summary>
        /// Performs a click in a cell.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="col">Column number of the cell.</param>
        /// <param name="row">Row number of the cell.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �Z���{�^���A�Z�������N���N���b�N���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateClickCellContent(int col, int row, Async async)
        {
            App[GetType(), "EmulateClickCellContentInTarget", async](AppVar, col, row);
        }

#if ENG
        /// <summary>
        /// Sets the currently selected cell.
        /// </summary>
        /// <param name="col">Column number of the cell.</param>
        /// <param name="row">Row number of the cell.</param>
#else
        /// <summary>
        /// �J�����g�Z����I�����܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
#endif
        public void EmulateChangeCurrentCell(int col, int row)
        {
            App[GetType(), "EmulateChangeCurrentCellInTarget"](AppVar, col, row);
        }

#if ENG
        /// <summary>
        /// Sets the currently selected cell.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="col">Column number of the cell.</param>
        /// <param name="row">Row number of the cell.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �J�����g�Z����I�����܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateChangeCurrentCell(int col, int row, Async async)
        {
            App[GetType(), "EmulateChangeCurrentCellInTarget", async](AppVar, col, row);
        }

#if ENG
        /// <summary>
        /// Clears any selections.
        /// </summary>
#else
        /// <summary>
        /// �I����Ԃ��������܂��B
        /// </summary>
#endif
        public void EmulateClearSelection()
        {
            App[GetType(), "EmulateClearSelectionInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Clears any selections.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �I����Ԃ��������܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateClearSelection(Async async)
        {
            App[GetType(), "EmulateClearSelectionInTarget", async](AppVar);
        }

#if ENG
        /// <summary>
        /// Changes the cell selected state of cells.
        /// </summary>
        /// <param name="cells">Cell selection information.</param>
#else
        /// <summary>
        /// �I����Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="cells">�I���Z�����B</param>
#endif
        public void EmulateChangeCellSelected(params CellSelectedInfo[] cells)
        {
            App[GetType(), "EmulateChangeCellSelectedInTarget"](AppVar, cells);
        }

#if ENG
        /// <summary>
        /// Changes the cell selected state of cells.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
        /// <param name="cells">Cell selection information.</param>
#else
        /// <summary>
        /// �I����Ԃ�ύX���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        /// <param name="cells">�I���Z�����B</param>
#endif
        public void EmulateChangeCellSelected(Async async, params CellSelectedInfo[] cells)
        {
            App[GetType(), "EmulateChangeCellSelectedInTarget", async](AppVar, cells);
        }

#if ENG
        /// <summary>
        /// Sets the currently selected rows.
        /// </summary>
        /// <param name="rows">Row selection information.</param>
#else
        /// <summary>
        /// �s�I����Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="rows">�I���s���B</param>
#endif
        public void EmulateChangeRowSelected(params RowSelectedInfo[] rows)
        {
            App[GetType(), "EmulateChangeRowSelectedInTarget"](AppVar, rows);
        }

#if ENG
        /// <summary>
        /// Sets the currently selected rows.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
        /// <param name="rows">Row selection information.</param>
#else
        /// <summary>
        /// �s�I����Ԃ�ύX���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        /// <param name="rows">�I���s���B</param>
#endif
        public void EmulateChangeRowSelected(Async async, params RowSelectedInfo[] rows)
        {
            App[GetType(), "EmulateChangeRowSelectedInTarget", async](AppVar, rows);
        }

#if ENG
        /// <summary>
        /// Emulates a row deletion operation.
        /// </summary>
#else
        /// <summary>
        /// Delete������G�~�����[�g���܂��B
        /// </summary>
#endif
        public void EmulateDelete()
        {
            App[GetType(), "EmulateDeleteInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Emulates a row deletion operation.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// Delete������G�~�����[�g���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateDelete(Async async)
        {
            App[GetType(), "EmulateDeleteInTarget", async](AppVar);
        }

        /// <summary>
        /// ���݂̑I���s���擾���܂��B
        /// </summary>
        /// <param name="grid">�O���b�h�B</param>
        /// <returns>���݂̑I���s�B</returns>
        static int[] GetSelectedRowsInTarget(DataGridView grid)
        {
            List<int> list = new List<int>();
            foreach (DataGridViewRow element in grid.SelectedRows)
            {
                list.Add(element.Index);
            }
            list.Sort();
            return list.ToArray();
        }

        /// <summary>
        /// �s��Ŏw�肵���Z���̃e�L�X�g���擾���܂�(����)�B
        /// </summary>
        /// <param name="datagridview">�f�[�^�O���b�h�r���[�B</param>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <returns>�e�L�X�g�B</returns>
        static string GetTextInTarget(DataGridView datagridview, int col, int row)
        {
            object obj = datagridview.Rows[row].Cells[col].Value;
            return obj != null ? obj.ToString() : string.Empty;
        }

        /// <summary>
        /// �s��Ŏw�肵���͈͂̃Z���̃e�L�X�g���擾���܂��B
        /// </summary>
        /// <param name="datagridview">�f�[�^�O���b�h�B</param>
        /// <param name="startCol">�J�n��B</param>
        /// <param name="startRow">�J�n�s�B</param>
        /// <param name="endCol">�I����B</param>
        /// <param name="endRow">�I���s�B</param>
        /// <returns>�e�L�X�g�z��B</returns>
        static string[][] GetTextInTarget(DataGridView datagridview, int startCol, int startRow, int endCol, int endRow)
        {
            int colCount = endCol - startCol+ 1;
            int rowCount = endRow - startRow + 1;
            string[][] texts = new string[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                int row = i + startRow;
                texts[i] = new string[colCount];
                for (int j = 0; j < colCount; j++)
                {
                    int col = j + startCol;
                    texts[i][j] = GetTextInTarget(datagridview, col, row);
                }
            }
            return texts;
        }

        /// <summary>
        /// ���݂̑I���Z�����擾���܂��B
        /// </summary>
        /// <param name="grid">�O���b�h�B</param>
        /// <returns>���݂̑I���Z���B</returns>
        static Cell[] GetSelectedCellsInTarget(DataGridView grid)
        {
            List<Cell> list = new List<Cell>();
            foreach (DataGridViewCell element in grid.SelectedCells)
            {
                list.Add(new Cell(element.ColumnIndex, element.RowIndex));
            }

            //Col,Row�Ń\�[�g
            list.Sort(delegate(Cell data1, Cell data2)
            {
                if (data1.Col < data2.Col)
                {
                    return -1;
                }
                if (data2.Col < data1.Col)
                {
                    return 1;
                }
                if (data1.Row < data2.Row)
                {
                    return -1;
                }
                if (data2.Row < data1.Row)
                {
                    return 1;
                }
                return 0;
            });
            return list.ToArray();
        }

        /// <summary>
        /// �Z���̃`�F�b�N��Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="grid">�O���b�h�B</param>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="isChecked">�`�F�b�N��ԁB</param>
        static void EmulateCellCheckInTarget(DataGridView grid, int col, int row, bool isChecked)
        {
            EmulateChangeCurrentCellInTarget(grid, col, row);
            while (true)
            {
                object data = grid[col, row].Value;
                bool currentCheck = (data == null) ? false : (bool)data;
                if (currentCheck == isChecked)
                {
                    break;
                }
                grid.BeginEdit(false);
                grid.GetType().GetMethod("OnKeyDown", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(grid, new object[] { new KeyEventArgs(Keys.Space) });
                grid.GetType().GetMethod("OnKeyUp", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(grid, new object[] { new KeyEventArgs(Keys.Space) });
                grid.EndEdit();
            }
        }

        /// <summary>
        /// �Z���̃e�L�X�g��ύX���܂��B
        /// </summary>
        /// <param name="grid">�O���b�h�B</param>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="text">�e�L�X�g�B</param>
        static void EmulateChangeCellTextInTarget(DataGridView grid, int col, int row, string text)
        {
            EmulateChangeCurrentCellInTarget(grid, col, row);
            grid.BeginEdit(false);
            grid.EditingControl.Text = text;
            grid.EndEdit();
        }

        /// <summary>
        /// �s�I����Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="grid">�O���b�h�B</param>
        /// <param name="rows">�I���s���B</param>
        static void EmulateChangeRowSelectedInTarget(DataGridView grid, RowSelectedInfo[] rows)
        {
            grid.Focus();
            grid.Select();
            foreach (RowSelectedInfo row in rows)
            {
                grid.Rows[row.Row].Selected = row.Selected;
            }
        }

        /// <summary>
        /// �Z���R���{�̑I����ύX���܂��B
        /// </summary>
        /// <param name="grid">�O���b�h�B</param>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        static void EmulateChangeCellComboSelectInTarget(DataGridView grid, int col, int row, int index)
        {
            EmulateChangeCurrentCellInTarget(grid, col, row);
            grid.BeginEdit(false);
            ((ComboBox)grid.EditingControl).SelectedIndex = index;
            grid.EndEdit();
        }

        /// <summary>
        /// �Z���{�^���A�Z�������N���N���b�N���܂��B
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        static void EmulateClickCellContentInTarget(DataGridView grid, int col, int row)
        {
            EmulateChangeCurrentCellInTarget(grid, col, row);
            grid.GetType().GetMethod("OnKeyDown", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(grid, new object[] { new KeyEventArgs(Keys.Space) });
            grid.GetType().GetMethod("OnKeyUp", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(grid, new object[] { new KeyEventArgs(Keys.Space) });
        }

        /// <summary>
        /// �J�����g�Z����I�����܂��B
        /// </summary>
        /// <param name="grid">�O���b�h�B</param>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        static void EmulateChangeCurrentCellInTarget(DataGridView grid, int col, int row)
        {
            grid.Focus();
            grid.Select();
            grid.CurrentCell = grid[col, row];
        }

        /// <summary>
        /// �I����Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="grid">�O���b�h�B</param>
        /// <param name="cells">�I���Z�����B</param>
        static void EmulateChangeCellSelectedInTarget(DataGridView grid, CellSelectedInfo[] cells)
        {
            grid.Focus();
            grid.Select();
            foreach (CellSelectedInfo cell in cells)
            {
                grid[cell.Col, cell.Row].Selected = cell.Selected;
            }
        }

        /// <summary>
        /// �I����Ԃ��������܂��B
        /// </summary>
        /// <param name="grid">�O���b�h�B</param>
        static void EmulateClearSelectionInTarget(DataGridView grid)
        {
            grid.Focus();
            grid.ClearSelection();
        }

        /// <summary>
        /// Delete������G�~�����[�g���܂��B
        /// </summary>
        /// <param name="grid">�O���b�h�B</param>
        static void EmulateDeleteInTarget(DataGridView grid)
        {
            grid.Focus();
            grid.Select(); grid.GetType().GetMethod("OnKeyDown", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(grid, new object[] { new KeyEventArgs(Keys.Delete) });
            grid.GetType().GetMethod("OnKeyUp", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(grid, new object[] { new KeyEventArgs(Keys.Delete) });
        }

        /// <summary>
        /// ���݂̑I���Z�����擾���܂��B
        /// </summary>
        /// <param name="grid">�O���b�h�B</param>
        /// <returns>���݂̑I���Z���B</returns>
        static Cell GetCurrentCellInTarget(DataGridView grid)
        {
            if (grid.CurrentCell == null)
            {
                return null;
            }
            return new Cell(grid.CurrentCell.ColumnIndex, grid.CurrentCell.RowIndex);
        }
    }
}