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
    /// Provides operations on controls of type System.Windows.Forms.ListBox.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.ListBoxのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.ListBox")]
    public class FormsListBox : FormsControlBase
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
        public FormsListBox(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsListBox(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsListBox(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsListBox(AppVar windowObject).", false)]
        public FormsListBox(WindowsAppFriend app, AppVar appVar)
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
        public FormsListBox(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// I get the number of items in the list.
        /// </summary>
#else
        /// <summary>
        /// 一覧のアイテム数を取得します。
        /// </summary>
#endif
        public int ItemCount
        {
            get { return (int)(this["Items"]()["Count"]().Core); }
        }

#if ENG
        /// <summary>
        /// I get the index of the currently selected item.
        /// </summary>
#else
        /// <summary>
        /// 現在選択されているアイテムのインデックスを取得します。
        /// </summary>
#endif
        public int SelectedIndex
        {
            get { return (int)(this["SelectedIndex"]().Core); }
        }

#if ENG
        /// <summary>
        /// I get the selection mode.
        /// </summary>
#else
        /// <summary>
        /// 選択モードを取得します。
        /// </summary>
#endif
        public SelectionMode SelectionMode
        {
            get { return (SelectionMode)(this["SelectionMode"]().Core); }
        }

#if ENG
        /// <summary>
        /// I get a list item list in the selected state.
        /// </summary>
#else
        /// <summary>
        /// 選択状態のリスト項目一覧を取得します。
        /// </summary>
#endif
        public int[] SelectedIndexes
        {
            get { return (int[])(App[typeof(FormsListBox), "GetSelectedIndexesInTarget"](AppVar).Core); }
        }

#if ENG
        /// <summary>
        /// Finds an item with the indicated text.
        /// </summary>
        /// <param name="itemText">Text of the item.</param>
        /// <returns>Index of the found item. Returns -1 if the item could not be found.</returns>
#else
        /// <summary>
        /// アイテムを指定されたテキストで検索します。
        /// </summary>
        /// <param name="itemText">アイテムのテキスト。</param>
        /// <returns>検索されたアイテムのインデックス。未発見時は-1が返ります。</returns>
#endif
        [Obsolete("Please use one of the following. FindString, FindStringExact", false)]
        public int FindListIndex(string itemText)
        {
            return (int)(this["FindString"](itemText).Core);
        }

#if ENG
        /// <summary>
        /// Finds an item with the indicated text.
        /// </summary>
        /// <param name="itemText">Text of the item.</param>
        /// <returns>Index of the found item. Returns -1 if the item could not be found.</returns>
#else
        /// <summary>
        /// 指定した文字列で始まる最初の項目を検索します。
        /// </summary>
        /// <param name="itemText">アイテムのテキスト。</param>
        /// <returns>検索されたアイテムのインデックス。未発見時は-1が返ります。</returns>
#endif
        public int FindString(string itemText)
        {
            return (int)(this["FindString"](itemText).Core);
        }

#if ENG
        /// <summary>
        /// Finds the first item that starts with the specified string. The search starts at a specific starting index.
        /// </summary>
        /// <param name="itemText">Text of the item.</param>
        /// <param name="startIndex">Index of the item before the first item to be searched. Set to -1 to search from the beginning. </param>
        /// <returns>Index of the found item. Returns -1 if the item could not be found.</returns>
#else
        /// <summary>
        /// 指定した文字列で始まる最初のアイテムを検索します。指定した開始インデックスから検索が開始します。
        /// </summary>
        /// <param name="itemText">アイテムのテキスト。</param>
        /// <param name="startIndex">最初の検索対象項目の前にある項目のインデックス。 先頭から検索する場合は-1に設定します。 </param>
        /// <returns>検索されたノードのインデックス。未発見時は-1が返ります。</returns>
#endif
        public int FindString(string itemText, int startIndex)
        {
            return (int)(this["FindString"](itemText, startIndex).Core);
        }

#if ENG
        /// <summary>
        /// Finds the first item that exactly matches the specified string.
        /// </summary>
        /// <param name="itemText">Text of the item.</param>
        /// <returns>Index of the first item found; returns -1 if no match is found.</returns>
#else
        /// <summary>
        /// 指定した文字列と正確に一致する最初の項目を検索します。
        /// </summary>
        /// <param name="itemText">アイテムのテキスト。</param>
        /// <returns>最初に見つかった項目のインデックス。一致する項目が見つからない場合は-1を返します。</returns>
#endif
        public int FindStringExact(string itemText)
        {
            return (int)(this["FindStringExact"](itemText).Core);
        }

#if ENG
        /// <summary>
        /// Finds the first item that exactly matches the specified string. The search starts at a specific starting index.
        /// </summary>
        /// <param name="itemText">Text of the item.</param>
        /// <param name="startIndex">Index of the item before the first item to be searched. Set to -1 to search from the beginning. </param>
        /// <returns>Index of the first item found; returns -1 if no match is found.</returns>
#else
        /// <summary>
        /// 指定した文字列と正確に一致する最初の項目を検索します。 指定した開始インデックスから検索が開始します。
        /// </summary>
        /// <param name="itemText">各ノードのテキスト</param>
        /// <param name="startIndex">最初の検索対象項目の前にある項目のインデックス。 先頭から検索する場合は-1に設定します。</param>
        /// <returns>最初に見つかった項目のインデックス。一致する項目が見つからない場合は-1を返します。</returns>
#endif
        public int FindStringExact(string itemText, int startIndex)
        {
            return (int)(this["FindStringExact"](itemText, startIndex).Core);
        }

#if ENG
        /// <summary>
        /// Get itme text.
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>Item text.</returns>
#else
        /// <summary>
        /// アイテム文字列取得
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>アイテム文字列</returns>
#endif
        public string GetItemText(int index)
        {
            var item = this["Items"]()["[]"](index);
            return item.IsNull ? string.Empty : (string)item["ToString"]().Core;
        }

#if ENG
        /// <summary>
        /// Get all item text.
        /// </summary>
        /// <returns>All item text.</returns>
#else
        /// <summary>
        /// アイテム文字列全取得
        /// </summary>
        /// <returns>全アイテム文字列</returns>
#endif
        public string[] GetAllItemText()
        {
            return (string[])(App[typeof(FormsListBox), "GetAllItemText"](this).Core);
        }

#if ENG
        /// <summary>
        /// I want to select an item state corresponding to the specified index.
        /// </summary>
#else
        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// </summary>
#endif
        public void EmulateChangeSelectedIndex(int index)
        {
            App[typeof(FormsListBox), "EmulateChangeSelectedIndexInTarget"](AppVar, index);
        }

#if ENG
        /// <summary>
        /// I want to select an item state corresponding to the specified index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// 非同期に実行します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateChangeSelectedIndex(int index, Async async)
        {
            App[typeof(FormsListBox), "EmulateChangeSelectedIndexInTarget", async](AppVar, index);
        }

#if ENG
        /// <summary>
        /// I want to select an item state corresponding to the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="isSelect">Set true to the selected state.</param>
#else
        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
#endif
        public void EmulateChangeSelectedState(int index, bool isSelect)
        {
            App[typeof(FormsListBox), "EmulateChangeSelectedStateInTarget"](AppVar, index, isSelect);
        }

#if ENG
        /// <summary>
        /// I want to select an item state corresponding to the specified index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="isSelect">Set true to the selected state.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// 非同期に実行します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
        /// <param name="async">非同期オブジェクト</param>
#endif
        public void EmulateChangeSelectedState(int index, bool isSelect, Async async)
        {
            App[typeof(FormsListBox), "EmulateChangeSelectedStateInTarget", async](AppVar, index, isSelect);
        }

        /// <summary>
        /// リストアイテムを選択します（内部）。
        /// </summary>
        /// <param name="listbox">リストボックス</param>
        private static int[] GetSelectedIndexesInTarget(ListBox listbox)
        {
            List<int> list = new List<int>();
            ListBox.SelectedIndexCollection collection = listbox.SelectedIndices;
            for (int itemIndex = 0; itemIndex < collection.Count; itemIndex++)
            {
                list.Add(collection[itemIndex]);
            }
            return list.ToArray();
        }

        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// 非同期に実行します。
        /// </summary>
        /// <param name="listbox">ListBox。</param>
        /// <param name="index">インデックス。</param>
        static void EmulateChangeSelectedIndexInTarget(ListBox listbox, int index)
        {
            listbox.Focus();
            listbox.SelectedIndex = index;
        }

        /// <summary>
        /// リストアイテムを選択します（内部）。
        /// </summary>
        /// <param name="listbox">ListBox。</param>
        /// <param name="index">インデックス。</param>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
        private static void EmulateChangeSelectedStateInTarget(ListBox listbox, int index, bool isSelect)
        {
            listbox.Focus();
            listbox.SetSelected(index, isSelect);
            if (isSelect)
            {
                listbox.SelectedIndex = index;
            }
        }

        /// <summary>
        /// アイテム文字列を全取得
        /// </summary>
        /// <param name="list">リスト</param>
        /// <returns>全アイテム文字列</returns>
        private static string[] GetAllItemText(ListBox list)
        {
            var items = new List<string>();
            foreach (var e in list.Items)
            {
                items.Add(e == null ? string.Empty : e.ToString());
            }
            return items.ToArray();
        }
    }
}
