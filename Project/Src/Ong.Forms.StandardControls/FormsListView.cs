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
    /// WindowControlがSystem.Windows.Forms.ListViewのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsListView : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsListView(FormsControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsListView(WindowsAppFriend app, AppVar appVar)
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
                return (int)(this["Columns"]()["Count"]().Core);
            }
        }

        /// <summary>
        /// 行数を取得します。
        /// </summary>
        public int RowCount
        {
            get
            {
                return (int)(this["Items"]()["Count"]().Core);
            }
        }

        /// <summary>
        /// 選択している最初のリストアイテムを取得します
        /// </summary>
        public FormsListViewItem SelectItem
        {
            get
            {
                AppVar returnItem = (App[GetType(), "SelectItemInTarget"](AppVar));
                return new FormsListViewItem(returnItem);
            }
        }

        /// <summary>
        /// 選択リストアイテム（内部）
        /// </summary>
        /// <param name="listview">リストビュー</param>
        /// <returns>選択されたリストアイテム</returns>
        private static ListViewItem SelectItemInTarget(ListView listview)
        {
            for (int row = 0; row < listview.Items.Count; row++)
            {
                if (listview.Items[row].Selected == true)
                {
                    return listview.Items[row];
                }
            }
            return null;
        }

        /// <summary>
        /// 行を選択します
        /// </summary>
        /// <param name="row">行番号</param>
        public void EmulateRowSelect(int row)
        {
            App[GetType(), "RowSelectInTarget"](AppVar, row);
        }

        /// <summary>
        /// リストアイテム（行）を選択します
        /// 非同期で実行します
        /// </summary>
        /// <param name="row">ノード</param>
        /// <param name="async">非同期オブジェクト</param>
        public void EmulateRowSelect(int row, Async async)
        {
            App[GetType(), "RowSelectInTarget", async](AppVar, row);
        }

        /// <summary>
        /// リストアイテム選択（内部）
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="row"></param>
        private static void RowSelectInTarget(ListView listview, int row)
        {
            listview.Items[row].Selected = true;
        }

        /// <summary>
        /// リストアイテムを指定されたテキストで検索します
        /// </summary>
        /// <param name="itemText">テキスト</param>
        /// <returns>検索されたアイテムのアイテムハンドル。未発見時はnullが返ります</returns>
        public FormsListViewItem FindItem(string itemText)
        {
            AppVar returnItem = this["FindItemWithText"](itemText);
            if (returnItem != null)
            {
                return new FormsListViewItem(returnItem);
            }
            return null;
        }
    }
}