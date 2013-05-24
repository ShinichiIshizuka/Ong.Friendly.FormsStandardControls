using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Drawing;
using System.Reflection;
using System;

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
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsDataGridView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

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
        /// 行列で指定したセルのテキストを取得します(内部)。
        /// </summary>
        /// <param name="datagridview">データグリッドビュー。</param>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <returns>テキスト。</returns>
        private static string GetTextInTarget(DataGridView datagridview, int col, int row)
        {
            object obj = datagridview.Rows[row].Cells[col].Value;
            return obj != null ? obj.ToString() : string.Empty;
        }

        /// <summary>
        /// セルのチェック状態を順に変更します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        public void EmulateToggleCellCheck(int col, int row)
        {
            EmulateChangeCurrentCell(col, row);
            this["OnKeyDown"](App.Dim(new NewInfo<KeyEventArgs>(Keys.Space)));
            this["OnKeyUp"](App.Dim(new NewInfo<KeyEventArgs>(Keys.Space)));
        }

        /// <summary>
        /// セルのチェック状態を順に変更します。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateToggleCellCheck(int col, int row, Async async)
        {
            EmulateChangeCurrentCell(col, row, new Async());
            this["OnKeyDown", new Async()](App.Dim(new NewInfo<KeyEventArgs>(Keys.Space)));
            this["OnKeyUp", async](App.Dim(new NewInfo<KeyEventArgs>(Keys.Space)));
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
        /// セルボタンをクリックします。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        public void EmulateClickCellButton(int col, int row)
        {
            EmulateChangeCurrentCell(col, row);
            this["OnCellContentClick"](App.Dim(new NewInfo<DataGridViewCellEventArgs>(col, row)));
        }

        /// <summary>
        /// セルボタンをクリックします。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="async"></param>
        public void EmulateClickCellButton(int col, int row, Async async)
        {
            EmulateChangeCurrentCell(col, row, new Async());
            this["OnCellContentClick", async](App.Dim(new NewInfo<DataGridViewCellEventArgs>(col, row)));
        }

        /// <summary>
        /// セルリンクをクリックします。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        public void EmulateClickCellLink(int col, int row)
        {
            EmulateChangeCurrentCell(col, row);
            this["OnCellContentClick"](App.Dim(new NewInfo<DataGridViewCellEventArgs>(col, row)));
        }

        /// <summary>
        /// セルリンクをクリックします。
        /// </summary>
        /// <param name="col">列。</param>
        /// <param name="row">行。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateClickCellLink(int col, int row, Async async)
        {
            EmulateChangeCurrentCell(col, row, new Async());
            this["OnCellContentClick", async](App.Dim(new NewInfo<DataGridViewCellEventArgs>(col, row)));
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
    }
}