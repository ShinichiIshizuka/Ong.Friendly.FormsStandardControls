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
    /// TypeがSystem.Windows.Forms.DataGridViewのウィンドウに対応した操作を提供します。
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
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
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
        /// 現在非推奨です。
        /// FormsDataGridView(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
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
        /// コンストラクタです。
        /// </summary>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        public FormsDataGridView(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the number of columns in the data grid.
        /// </summary>
#else
        /// <summary>
        /// 列数を取得します。
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
        /// 行数を取得します。
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
        /// 現在の選択セルを取得します。
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
        /// 現在の選択セルを取得します。
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
        /// 現在の選択行を取得します。
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
        /// 行列で指定したセルのテキストを取得します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <returns>テキスト。</returns>
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
        /// 行列で指定した範囲のセルのテキストを取得します。
        /// </summary>
        /// <param name="startCol">開始列。</param>
        /// <param name="startRow">開始行。</param>
        /// <param name="endCol">終了列。</param>
        /// <param name="endRow">終了行。</param>
        /// <returns>テキスト配列。</returns>
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
        /// セルのチェック状態を変更します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="isChecked">チェック状態。</param>
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
        /// セルのチェック状態を変更します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="isChecked">チェック状態。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
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
        /// セルのテキストを変更します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="text">テキスト。</param>
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
        /// セルのテキストを変更します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="text">テキスト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
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
        /// セルコンボの選択を変更します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="index">インデックス。</param>
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
        /// セルコンボの選択を変更します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="index">インデックス。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
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
        /// セルボタン、セルリンクをクリックします。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
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
        /// セルボタン、セルリンクをクリックします。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
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
        /// カレントセルを選択します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
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
        /// カレントセルを選択します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
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
        /// 選択状態を解除します。
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
        /// 選択状態を解除します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
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
        /// 選択状態を変更します。
        /// </summary>
        /// <param name="cells">選択セル情報。</param>
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
        /// 選択状態を変更します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        /// <param name="cells">選択セル情報。</param>
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
        /// 行選択状態を変更します。
        /// </summary>
        /// <param name="rows">選択行情報。</param>
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
        /// 行選択状態を変更します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        /// <param name="rows">選択行情報。</param>
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
        /// Delete操作をエミュレートします。
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
        /// Delete操作をエミュレートします。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateDelete(Async async)
        {
            App[GetType(), "EmulateDeleteInTarget", async](AppVar);
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
            list.Sort();
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
        /// <param name="datagridview">データグリッド。</param>
        /// <param name="startCol">開始列。</param>
        /// <param name="startRow">開始行。</param>
        /// <param name="endCol">終了列。</param>
        /// <param name="endRow">終了行。</param>
        /// <returns>テキスト配列。</returns>
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

            //Col,Rowでソート
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
        /// 選択状態を解除します。
        /// </summary>
        /// <param name="grid">グリッド。</param>
        static void EmulateClearSelectionInTarget(DataGridView grid)
        {
            grid.Focus();
            grid.ClearSelection();
        }

        /// <summary>
        /// Delete操作をエミュレートします。
        /// </summary>
        /// <param name="grid">グリッド。</param>
        static void EmulateDeleteInTarget(DataGridView grid)
        {
            grid.Focus();
            grid.Select(); grid.GetType().GetMethod("OnKeyDown", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(grid, new object[] { new KeyEventArgs(Keys.Delete) });
            grid.GetType().GetMethod("OnKeyUp", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(grid, new object[] { new KeyEventArgs(Keys.Delete) });
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