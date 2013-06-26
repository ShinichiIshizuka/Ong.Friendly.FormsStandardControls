using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

//@@@やっぱりできるだけ、1コールで処理を完結できるようにする

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがSystem.Windows.Forms.DataGridViewのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsDataGridView : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
        public FormsDataGridView(WindowControl src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsDataGridView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// 列数を取得します。
        /// </summary>
        public int ColumnCount
        {
            get { return (int)(this["ColumnCount"]().Core); }
        }

        /// <summary>
        /// 行数を取得します。
        /// </summary>
        public int RowCount
        {
            get { return (int)(this["RowCount"]().Core); }
        }

        /// <summary>
        /// 現在の選択セルを取得します。
        /// </summary>
        public Cell CurrentCell
        {
            get { return (Cell)(App[GetType(), "GetCurrentCellInTarget"](AppVar).Core); }
        }

        /// <summary>
        /// 現在の選択セルを取得します。
        /// </summary>
        public Cell[] SelectedCells
        {
            get { return (Cell[])(App[GetType(), "GetSelectedCellsInTarget"](AppVar).Core); }
        }

        /// <summary>
        /// 現在の選択行を取得します。
        /// </summary>
        public int[] SelectedRows
        {
            get { return (int[])(App[GetType(), "GetSelectedRowsInTarget"](AppVar).Core); }
        }

        /// <summary>
        /// 行列で指定したセルのテキストを取得します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <returns>テキスト。</returns>
        public string GetText(int col, int row)
        {
            return (string)(App[GetType(), "GetTextInTarget"](AppVar, col, row).Core);
        }

        /// <summary>
        /// 行列で指定した範囲のセルのテキストを取得します。
        /// </summary>
        /// <param name="startCol">開始列。</param>
        /// <param name="startRow">開始行。</param>
        /// <param name="endCol">終了列。</param>
        /// <param name="endRow">終了行。</param>
        /// <returns>テキスト配列。</returns>
        public string[][] GetText(int startCol, int startRow, int endCol, int endRow)
        {
            return (string[][])(App[GetType(), "GetTextInTarget"](AppVar, startCol, startRow, endCol, endRow).Core);
        }

        /// <summary>
        /// セルのチェック状態を変更します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="isChecked">チェック状態。</param>
        public void EmulateCellCheck(int col, int row, bool isChecked)
        {
            App[GetType(), "EmulateCellCheckInTarget"](AppVar, col, row, isChecked);
        }

        /// <summary>
        /// セルのチェック状態を変更します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="isChecked">チェック状態。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateCellCheck(int col, int row, bool isChecked, Async async)
        {
            App[GetType(), "EmulateCellCheckInTarget", async](AppVar, col, row, isChecked);
        }

        /// <summary>
        /// セルのテキストを変更します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="text">テキスト。</param>
        public void EmulateChangeCellText(int col, int row, string text)
        {
            App[GetType(), "EmulateChangeCellTextInTarget"](AppVar, col, row, text);
        }

        /// <summary>
        /// セルのテキストを変更します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="text">テキスト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateChangeCellText(int col, int row, string text, Async async)
        {
            App[GetType(), "EmulateChangeCellTextInTarget", async](AppVar, col, row, text);
        }

        /// <summary>
        /// セルコンボの選択を変更します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="index">インデックス。</param>
        public void EmulateChangeCellComboSelect(int col, int row, int index)
        {
            App[GetType(), "EmulateChangeCellComboSelectInTarget"](AppVar, col, row, index);
        }

        /// <summary>
        /// セルコンボの選択を変更します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="index">インデックス。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateChangeCellComboSelect(int col, int row, int index, Async async)
        {
            App[GetType(), "EmulateChangeCellComboSelectInTarget", async](AppVar, col, row, index);
        }

        /// <summary>
        /// セルボタン、セルリンクをクリックします。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        public void EmulateClickCellContent(int col, int row)
        {
            App[GetType(), "EmulateClickCellContentInTarget"](AppVar, col, row);
        }

        /// <summary>
        /// セルボタン、セルリンクをクリックします。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="async"></param>
        public void EmulateClickCellContent(int col, int row, Async async)
        {
            App[GetType(), "EmulateClickCellContentInTarget", async](AppVar, col, row);
        }

        /// <summary>
        /// カレントセルを選択します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        public void EmulateChangeCurrentCell(int col, int row)
        {
            App[GetType(), "EmulateChangeCurrentCellInTarget"](AppVar, col, row);
        }

        /// <summary>
        /// カレントセルを選択します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateChangeCurrentCell(int col, int row, Async async)
        {
            App[GetType(), "EmulateChangeCurrentCellInTarget", async](AppVar, col, row);
        }

        /// <summary>
        /// 選択状態を解除します。
        /// </summary>
        public void EmulateClearSelection()
        {
            this["ClearSelection"]();
        }

        /// <summary>
        /// 選択状態を解除します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateClearSelection(Async async)
        {
            this["ClearSelection", async]();
        }

        /// <summary>
        /// 選択状態を変更します。
        /// </summary>
        /// <param name="cells">選択セル情報。</param>
        public void EmulateChangeCellSelected(params CellSelectedInfo[] cells)
        {
            App[GetType(), "EmulateChangeCellSelectedInTarget"](AppVar, cells);
        }

        /// <summary>
        /// 選択状態を変更します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        /// <param name="cells">選択セル情報。</param>
        public void EmulateChangeCellSelected(Async async, params CellSelectedInfo[] cells)
        {
            App[GetType(), "EmulateChangeCellSelectedInTarget"](AppVar, cells);
        }

        /// <summary>
        /// 行選択状態を変更します。
        /// </summary>
        /// <param name="rows">選択行情報。</param>
        public void EmulateChangeRowSelected(params RowSelectedInfo[] rows)
        {
            App[GetType(), "EmulateChangeRowSelectedInTarget"](AppVar, rows);
        }

        /// <summary>
        /// 行選択状態を変更します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        /// <param name="rows">選択行情報。</param>
        public void EmulateChangeRowSelected(Async async, params RowSelectedInfo[] rows)
        {
            App[GetType(), "EmulateChangeRowSelectedInTarget"](AppVar, rows);
        }

        /// <summary>
        /// Delete操作をエミュレートします。
        /// </summary>
        public void EmulateDelete()
        {
            this["Focus"]();
            this["Select"]();
            this["OnKeyDown"](App.Dim(new NewInfo<KeyEventArgs>(Keys.Delete)));
            this["OnKeyUp"](App.Dim(new NewInfo<KeyEventArgs>(Keys.Delete)));
        }

        /// <summary>
        /// Delete操作をエミュレートします。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateDelete(Async async)
        {
            this["Focus", new Async()]();
            this["Select", new Async()]();
            this["OnKeyDown", new Async()](App.Dim(new NewInfo<KeyEventArgs>(Keys.Delete)));
            this["OnKeyUp", async](App.Dim(new NewInfo<KeyEventArgs>(Keys.Delete)));
        }

        /// <summary>
        /// 現在の選択行を取得します。
        /// </summary>
        /// <param name="grid">グリッド。</param>
        /// <returns>現在の選択行。</returns>
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
        /// 行列で指定したセルのテキストを取得します(内部)。
        /// </summary>
        /// <param name="datagridview">データグリッドビュー。</param>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <returns>テキスト。</returns>
        static string GetTextInTarget(DataGridView datagridview, int col, int row)
        {
            object obj = datagridview.Rows[row].Cells[col].Value;
            return obj != null ? obj.ToString() : string.Empty;
        }

        /// <summary>
        /// 行列で指定した範囲のセルのテキストを取得します。
        /// </summary>
        /// <param name="startCol">開始列。</param>
        /// <param name="startRow">開始行。</param>
        /// <param name="endCol">終了列。</param>
        /// <param name="endRow">終了行。</param>
        /// <returns>テキスト配列。</returns>
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
        /// 現在の選択セルを取得します。
        /// </summary>
        /// <param name="grid">グリッド。</param>
        /// <returns>現在の選択セル。</returns>
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
        /// セルのチェック状態を変更します。
        /// </summary>
        /// <param name="grid">グリッド。</param>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="isChecked">チェック状態。</param>
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
        /// セルのテキストを変更します。
        /// </summary>
        /// <param name="grid">グリッド。</param>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="text">テキスト。</param>
        static void EmulateChangeCellTextInTarget(DataGridView grid, int col, int row, string text)
        {
            EmulateChangeCurrentCellInTarget(grid, col, row);
            grid.BeginEdit(false);
            grid.EditingControl.Text = text;
            grid.EndEdit();
        }

        /// <summary>
        /// 行選択状態を変更します。
        /// </summary>
        /// <param name="grid">グリッド。</param>
        /// <param name="rows">選択行情報。</param>
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
        /// セルコンボの選択を変更します。
        /// </summary>
        /// <param name="grid">グリッド。</param>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="index">インデックス。</param>
        static void EmulateChangeCellComboSelectInTarget(DataGridView grid, int col, int row, int index)
        {
            EmulateChangeCurrentCellInTarget(grid, col, row);
            grid.BeginEdit(false);
            ((ComboBox)grid.EditingControl).SelectedIndex = index;
            grid.EndEdit();
        }

        /// <summary>
        /// セルボタン、セルリンクをクリックします。
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        static void EmulateClickCellContentInTarget(DataGridView grid, int col, int row)
        {
            EmulateChangeCurrentCellInTarget(grid, col, row);
            grid.GetType().GetMethod("OnKeyDown", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(grid, new object[] { new KeyEventArgs(Keys.Space) });
            grid.GetType().GetMethod("OnKeyUp", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(grid, new object[] { new KeyEventArgs(Keys.Space) });
        }

        /// <summary>
        /// カレントセルを選択します。
        /// </summary>
        /// <param name="grid">グリッド。</param>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        static void EmulateChangeCurrentCellInTarget(DataGridView grid, int col, int row)
        {
            grid.Focus();
            grid.Select();
            grid.CurrentCell = grid[col, row];
        }

        /// <summary>
        /// 選択状態を変更します。
        /// </summary>
        /// <param name="grid">グリッド。</param>
        /// <param name="cells">選択セル情報。</param>
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
        /// 現在の選択セルを取得します。
        /// </summary>
        /// <param name="grid">グリッド。</param>
        /// <returns>現在の選択セル。</returns>
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