using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Collections.Generic;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがSystem.Windows.Forms.ListViewのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsListView : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです。</param>
        public FormsListView(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
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
            get { return (int)(this["Columns"]()["Count"]().Core); }
        }

        /// <summary>
        /// アイテム数を取得します。
        /// </summary>
        public int ItemCount
        {
            get { return (int)(this["Items"]()["Count"]().Core); }
        }

        /// <summary>
        /// 選択されたインデックスの一覧を取得します。
        /// </summary>
        public int[] SelectIndexes
        {
            get { return (int[])(App[GetType(), "GetSelectedIndexesTarget"](AppVar).Core); } 
        }
        
        /// <summary>
        /// 選択されたインデックスの一覧を取得します（内部）。
        /// </summary>
        /// <param name="listview">リストビュー</param>
        /// <returns>選択されたインデックス一覧。</returns>
        private static int[] GetSelectedIndexesTarget(ListView listview)
        {
            List<int> list = new List<int>();
            for (int itemIndex = 0; itemIndex < listview.Items.Count; itemIndex++)
            {
                if (listview.Items[itemIndex].Selected == true)
                {
                    list.Add(itemIndex);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// 指定したインデックスのアイテムを取得します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <returns>指定したインデックスのアイテム。</returns>
        public FormsListViewItem GetListViewItem(int index)
        {
            return new FormsListViewItem(App, this["Items"]()["[]"](index));
        }
        // GetListViewItem FormsListViewItemsを返す
  
        // EmulateChangeSelectedStateを作る
        /*
        /// <summary>
        /// 行を選択します。
        /// </summary>
        /// <param name="itemIndex">行番号。</param>
        public void EmulateItemSelect(int itemIndex)
        {
            App[GetType(), "ItemSelectInTarget"](AppVar, itemIndex);
        }

        /// <summary>
        /// リストアイテム（行）を選択します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="itemIndex">ノード。</param>
        /// <param name="async">非同期オブジェクト。</param>
        public void EmulateItemSelect(int itemIndex, Async async)
        {
            App[GetType(), "ItemSelectInTarget", async](AppVar, itemIndex);
        }

        /// <summary>
        /// リストアイテム選択（内部）。
        /// </summary>
        /// <param name="listview">リストビュー。</param>
        /// <param name="itemIndex">インデックス。</param>
        private static void ItemSelectInTarget(ListView listview, int itemIndex)
        {
            listview.Items[itemIndex].Selected = true;
        }
        */
        //Delete

        /// <summary>
        /// リストアイテムを指定されたテキストで検索します。
        /// </summary>
        /// <param name="itemText">テキスト</param>
        /// <returns>検索されたアイテムのアイテムハンドル。未発見時はnullが返ります。</returns>
        public FormsListViewItem FindItem(string itemText)
        {
            AppVar returnItem = this["FindItemWithText"](itemText, true, 0);
            if (returnItem != null)
            {
                return new FormsListViewItem(App, returnItem);
            }
            return null;
        }

        /// <summary>
        /// Viewモードを取得します。
        /// </summary>
        public View ViewMode
        {
            get { return (View)(this["View"]().Core); } 
        }
    }
}