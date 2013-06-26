using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

//@@@����ς�ł��邾���A1�R�[���ŏ����������ł���悤�ɂ���

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��System.Windows.Forms.DataGridView�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
    public class FormsDataGridView : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���B</param>
        public FormsDataGridView(WindowControl src)
            : base(src) { }

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsDataGridView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// �񐔂��擾���܂��B
        /// </summary>
        public int ColumnCount
        {
            get { return (int)(this["ColumnCount"]().Core); }
        }

        /// <summary>
        /// �s�����擾���܂��B
        /// </summary>
        public int RowCount
        {
            get { return (int)(this["RowCount"]().Core); }
        }

        /// <summary>
        /// ���݂̑I���Z�����擾���܂��B
        /// </summary>
        public Cell CurrentCell
        {
            get { return (Cell)(App[GetType(), "GetCurrentCellInTarget"](AppVar).Core); }
        }

        /// <summary>
        /// ���݂̑I���Z�����擾���܂��B
        /// </summary>
        public Cell[] SelectedCells
        {
            get { return (Cell[])(App[GetType(), "GetSelectedCellsInTarget"](AppVar).Core); }
        }

        /// <summary>
        /// ���݂̑I���s���擾���܂��B
        /// </summary>
        public int[] SelectedRows
        {
            get { return (int[])(App[GetType(), "GetSelectedRowsInTarget"](AppVar).Core); }
        }

        /// <summary>
        /// �s��Ŏw�肵���Z���̃e�L�X�g���擾���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <returns>�e�L�X�g�B</returns>
        public string GetText(int col, int row)
        {
            return (string)(App[GetType(), "GetTextInTarget"](AppVar, col, row).Core);
        }

        /// <summary>
        /// �s��Ŏw�肵���͈͂̃Z���̃e�L�X�g���擾���܂��B
        /// </summary>
        /// <param name="startCol">�J�n��B</param>
        /// <param name="startRow">�J�n�s�B</param>
        /// <param name="endCol">�I����B</param>
        /// <param name="endRow">�I���s�B</param>
        /// <returns>�e�L�X�g�z��B</returns>
        public string[][] GetText(int startCol, int startRow, int endCol, int endRow)
        {
            return (string[][])(App[GetType(), "GetTextInTarget"](AppVar, startCol, startRow, endCol, endRow).Core);
        }

        /// <summary>
        /// �Z���̃`�F�b�N��Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="isChecked">�`�F�b�N��ԁB</param>
        public void EmulateCellCheck(int col, int row, bool isChecked)
        {
            App[GetType(), "EmulateCellCheckInTarget"](AppVar, col, row, isChecked);
        }

        /// <summary>
        /// �Z���̃`�F�b�N��Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="isChecked">�`�F�b�N��ԁB</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateCellCheck(int col, int row, bool isChecked, Async async)
        {
            App[GetType(), "EmulateCellCheckInTarget", async](AppVar, col, row, isChecked);
        }

        /// <summary>
        /// �Z���̃e�L�X�g��ύX���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="text">�e�L�X�g�B</param>
        public void EmulateChangeCellText(int col, int row, string text)
        {
            App[GetType(), "EmulateChangeCellTextInTarget"](AppVar, col, row, text);
        }

        /// <summary>
        /// �Z���̃e�L�X�g��ύX���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="text">�e�L�X�g�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateChangeCellText(int col, int row, string text, Async async)
        {
            App[GetType(), "EmulateChangeCellTextInTarget", async](AppVar, col, row, text);
        }

        /// <summary>
        /// �Z���R���{�̑I����ύX���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        public void EmulateChangeCellComboSelect(int col, int row, int index)
        {
            App[GetType(), "EmulateChangeCellComboSelectInTarget"](AppVar, col, row, index);
        }

        /// <summary>
        /// �Z���R���{�̑I����ύX���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateChangeCellComboSelect(int col, int row, int index, Async async)
        {
            App[GetType(), "EmulateChangeCellComboSelectInTarget", async](AppVar, col, row, index);
        }

        /// <summary>
        /// �Z���{�^���A�Z�������N���N���b�N���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        public void EmulateClickCellContent(int col, int row)
        {
            App[GetType(), "EmulateClickCellContentInTarget"](AppVar, col, row);
        }

        /// <summary>
        /// �Z���{�^���A�Z�������N���N���b�N���܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="async"></param>
        public void EmulateClickCellContent(int col, int row, Async async)
        {
            App[GetType(), "EmulateClickCellContentInTarget", async](AppVar, col, row);
        }

        /// <summary>
        /// �J�����g�Z����I�����܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        public void EmulateChangeCurrentCell(int col, int row)
        {
            App[GetType(), "EmulateChangeCurrentCellInTarget"](AppVar, col, row);
        }

        /// <summary>
        /// �J�����g�Z����I�����܂��B
        /// </summary>
        /// <param name="col">��B</param>
        /// <param name="row">�s�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateChangeCurrentCell(int col, int row, Async async)
        {
            App[GetType(), "EmulateChangeCurrentCellInTarget", async](AppVar, col, row);
        }

        /// <summary>
        /// �I����Ԃ��������܂��B
        /// </summary>
        public void EmulateClearSelection()
        {
            this["ClearSelection"]();
        }

        /// <summary>
        /// �I����Ԃ��������܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateClearSelection(Async async)
        {
            this["ClearSelection", async]();
        }

        /// <summary>
        /// �I����Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="cells">�I���Z�����B</param>
        public void EmulateChangeCellSelected(params CellSelectedInfo[] cells)
        {
            App[GetType(), "EmulateChangeCellSelectedInTarget"](AppVar, cells);
        }

        /// <summary>
        /// �I����Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        /// <param name="cells">�I���Z�����B</param>
        public void EmulateChangeCellSelected(Async async, params CellSelectedInfo[] cells)
        {
            App[GetType(), "EmulateChangeCellSelectedInTarget"](AppVar, cells);
        }

        /// <summary>
        /// �s�I����Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="rows">�I���s���B</param>
        public void EmulateChangeRowSelected(params RowSelectedInfo[] rows)
        {
            App[GetType(), "EmulateChangeRowSelectedInTarget"](AppVar, rows);
        }

        /// <summary>
        /// �s�I����Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        /// <param name="rows">�I���s���B</param>
        public void EmulateChangeRowSelected(Async async, params RowSelectedInfo[] rows)
        {
            App[GetType(), "EmulateChangeRowSelectedInTarget"](AppVar, rows);
        }

        /// <summary>
        /// Delete������G�~�����[�g���܂��B
        /// </summary>
        public void EmulateDelete()
        {
            this["Focus"]();
            this["Select"]();
            this["OnKeyDown"](App.Dim(new NewInfo<KeyEventArgs>(Keys.Delete)));
            this["OnKeyUp"](App.Dim(new NewInfo<KeyEventArgs>(Keys.Delete)));
        }

        /// <summary>
        /// Delete������G�~�����[�g���܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateDelete(Async async)
        {
            this["Focus", new Async()]();
            this["Select", new Async()]();
            this["OnKeyDown", new Async()](App.Dim(new NewInfo<KeyEventArgs>(Keys.Delete)));
            this["OnKeyUp", async](App.Dim(new NewInfo<KeyEventArgs>(Keys.Delete)));
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
        /// <param name="startCol">�J�n��B</param>
        /// <param name="startRow">�J�n�s�B</param>
        /// <param name="endCol">�I����B</param>
        /// <param name="endRow">�I���s�B</param>
        /// <returns>�e�L�X�g�z��B</returns>
        static string[][] GetTextInTarget(DataGridView datagridview, int startCol, int startRow, int endCol, int endRow)
        {
            int colCount = endRow - startRow + 1;
            int rowCount = endRow - endCol + 1;
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