using System.Windows.Forms;
using System.Collections.Generic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.ListView.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.ListViewのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.ListView")]
    public class FormsListView : FormsControlBase
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
        public FormsListView(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsListView(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsListView(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsListView(AppVar windowObject).", false)]
        public FormsListView(WindowsAppFriend app, AppVar appVar)
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
        public FormsListView(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the control's View Mode.
        /// </summary>
#else
        /// <summary>
        /// Viewモードを取得します。
        /// </summary>
#endif
        public View ViewMode
        {
            get { return (View)(this["View"]().Core); }
        }

#if ENG
        /// <summary>
        /// Returns the number of columns.
        /// </summary>
#else
        /// <summary>
        /// 列数を取得します。
        /// </summary>
#endif
        public int ColumnCount
        {
            get { return (int)(this["Columns"]()["Count"]().Core); }
        }

#if ENG
        /// <summary>
        /// Returns the number of items.
        /// </summary>
#else
        /// <summary>
        /// アイテム数を取得します。
        /// </summary>
#endif
        public int ItemCount
        {
            get { return (int)(this["Items"]()["Count"]().Core); }
        }

#if ENG
        /// <summary>
        /// Returns a list of the selected index.
        /// </summary>
#else
        /// <summary>
        /// 選択されたインデックスの一覧を取得します。
        /// </summary>
#endif
        public int[] SelectIndexes
        {
            get { return (int[])(App[GetType(), "GetSelectedIndexesInTarget"](AppVar).Core); } 
        }

#if ENG
        /// <summary>
        /// Retrieves the item at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Item at the specified index.</returns>
#else
        /// <summary>
        /// 指定したインデックスのアイテムを取得します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <returns>指定したインデックスのアイテム。</returns>
#endif
        public FormsListViewItem GetListViewItem(int index)
        {
            return new FormsListViewItem(this["Items"]()["[]"](index));
        }

#if ENG
        /// <summary>
        /// Finds the first item whose text begins with the specified value.
        /// </summary>
        /// <param name="itemText">Text to search for.</param>
        /// <param name="includeSubItemsInSearch">True to include sub-items in the search. Otherwise, false.</param>
        /// <param name="startIndex">The index of the item at which to start the search.</param>
        /// <returns>The first found item whose text begins with the specified text value.</returns>
#else
        /// <summary>
        /// 指定したテキスト値で始まる最初のアイテムを検索します。
        /// </summary>
        /// <param name="itemText">テキスト。</param>
        /// <param name="includeSubItemsInSearch">検索にサブ項目を含める場合は true。それ以外の場合は false。</param>
        /// <param name="startIndex">検索を開始する位置の項目のインデックス。</param>
        /// <returns>指定したテキスト値で始まる最初のアイテム</returns>
#endif
        public FormsListViewItem FindItemWithText(string itemText, bool includeSubItemsInSearch, int startIndex)
        {
            AppVar returnItem = this["FindItemWithText"](itemText, includeSubItemsInSearch, startIndex);
            if ((bool)App[GetType(), "ReferenceEquals"](returnItem, null).Core)
            {
                return null;
            }
            return new FormsListViewItem(returnItem);
        }

#if ENG
        /// <summary>
        /// Sets the selection state of the item with the specified index.
        /// </summary>
        /// <param name="index">Index of the item to change.</param>
        /// <param name="isSelect">The selection state (true to select).</param>
#else
        /// <summary>
        /// 指定されたインデックスに該当するアイテムの選択状態を変更します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
#endif
        public void EmulateChangeSelectedState(int index, bool isSelect)
        {
            App[GetType(), "EmulateChangeSelectedStateInTarget"](AppVar, index, isSelect);
        }

#if ENG
        /// <summary>
        /// Sets the selection state of the item with the specified index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Index of the item to change.</param>
        /// <param name="isSelect">The selection state (true to select).</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 指定されたインデックスに該当するアイテムの選択状態を変更します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
        /// <param name="async">非同期オブジェクト。</param>
#endif
        public void EmulateChangeSelectedState(int index, bool isSelect, Async async)
        {
            App[GetType(), "EmulateChangeSelectedStateInTarget", async](AppVar, index, isSelect);
        }

        /// <summary>
        /// 選択されたインデックスの一覧を取得します（内部）。
        /// </summary>
        /// <param name="listview">リストビュー</param>
        /// <returns>選択されたインデックス一覧。</returns>
        private static int[] GetSelectedIndexesInTarget(ListView listview)
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
        /// リストビューアイテムを選択します（内部）。
        /// </summary>
        /// <param name="listview">リストビュー。</param>
        /// <param name="index">インデックス。</param>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
        private static void EmulateChangeSelectedStateInTarget(ListView listview, int index, bool isSelect)
        {
            listview.Focus();
            listview.Items[index].Selected = isSelect;
        }
    }
}