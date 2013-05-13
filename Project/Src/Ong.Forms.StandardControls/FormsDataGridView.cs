using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// WindowControlがSystem.Windows.Forms.DataGridViewのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsDataGridView : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsDataGridView(FormsControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
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
            get
            {
                return (int)(this["ColumnCount"]().Core);
            }
        }

        /// <summary>
        /// 行数を取得します。
        /// </summary>
        public int RowCount
        {
            get
            {
                return (int)(this["RowCount"]().Core);
            }
        }

        /// <summary>
        /// 行列で指定したセルのテキストを取得します
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <returns>テキスト</returns>
        public string GetText(int row, int col)
        {
            return (string)(App[GetType(), "GetTextInTarget"](AppVar, row, col).Core);
        }

        /// <summary>
        /// 行列で指定したセルのテキストを取得します(内部)
        /// </summary>
        /// <param name="datagridview">データグリッドビュー</param>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <returns>テキスト</returns>
        private static string GetTextInTarget(DataGridView datagridview, int row, int col)
        {
            return (string)(datagridview.Rows[row].Cells[col].Value);
        }

        /// <summary>
        /// 指定した行列のテキストを変更します
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <param name="text">テキスト</param>
        public void EmulateChangeText(int row, int col, string text)
        {
            App[GetType(), "EmulateChangeTextInTarget"](AppVar, row, col, text);
        }

        /// <summary>
        /// 指定した行列のテキストを変更します
        /// 非同期で実行します
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <param name="text">テキスト</param>
        /// <param name="async">非同期動作オブジェクト</param>
        public void EmulateChangeText(int row, int col, string text, Async async)
        {
            App[GetType(), "EmulateChangeTextInTarget", async](AppVar, row, col, text);
        }

        /// <summary>
        /// 指定した行列のテキストを変更します(内部)
        /// </summary>
        /// <param name="datagridview">データグリッドビュー</param>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <param name="text">テキスト</param>
        private static void EmulateChangeTextInTarget(DataGridView datagridview, int row, int col, string text)
        {
            datagridview.Rows[row].Cells[col].Value = text;
        }
    }
}