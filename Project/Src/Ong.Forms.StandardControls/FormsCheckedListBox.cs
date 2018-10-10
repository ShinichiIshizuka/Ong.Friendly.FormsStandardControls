using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using System;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.CheckedListBox.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.CheckdListBoxのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.CheckedListBox")]
    public class FormsCheckedListBox : FormsControlBase
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
        [Obsolete("Please use FormsCheckedListBox(WindowControl src)", false)]
        public FormsCheckedListBox(FormsControlBase src)
            : base(src) { }

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
        public FormsCheckedListBox(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsCheckedListBox(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsCheckedListBox(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsCheckedListBox(AppVar windowObject).", false)]
        public FormsCheckedListBox(WindowsAppFriend app, AppVar appVar)
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
        public FormsCheckedListBox(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the number of items in the list.
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
        /// Returns the index of the currently selected item.
        /// </summary>
#else
        /// <summary>
        /// 現在選択されているアイテムのインデックスを取得します。
        /// </summary>
#endif
        public int SelectedItemIndex
        {
            get { return (int)(this["SelectedIndex"]().Core); }
        }

#if ENG
        /// <summary>
        /// Returns an array of the indices that are currently checked.
        /// </summary>
#else
        /// <summary>
        /// 現在チェックされているアイテムのインデックスを配列で取得します。
        /// </summary>
#endif
        public int[] CheckedIndices
        {
            get { return (int[])(App[typeof(FormsCheckedListBox), "CheckedIndicsInTarget"](AppVar).Core); }
        }

#if ENG
        /// <summary>
        /// Returns the control's check state.
        /// </summary>
        /// <returns>The check state.</returns>
#else
        /// <summary>
        /// チェック状態を取得します。
        /// </summary>
        /// <returns>チェック状態</returns>
#endif
        public CheckState GetCheckState(int index)
        {
            return (CheckState)(this["GetItemCheckState"](index).Core);
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
        /// <param name="itemText">テキスト。</param>
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
        /// <param name="startIndex">最初の検索対象項目の前にある項目のインデックス番号。 先頭から検索する場合は-1に設定します。</param>
        /// <returns>最初に見つかった項目のインデックス。一致する項目が見つからない場合は-1を返します。</returns>
#endif
        public int FindStringExact(string itemText, int startIndex)
        {
            return (int)(this["FindStringExact"](itemText, startIndex).Core);
        }

#if ENG
        /// <summary>
        /// Sets the check state of a certain item.
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <param name="value">Check state.</param>
#else
        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="value">チェック状態。</param>
#endif
        public void EmulateCheckState(int index, CheckState value)
        {
            App[typeof(FormsCheckedListBox), "EmulateCheckStateInTarget"](AppVar, index, value);
        }

#if ENG
        /// <summary>
        /// Sets the check state of a certain item.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <param name="value">Check state.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// チェック状態を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="value">チェック状態。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateCheckState(int index ,CheckState value, Async async)
        {
            App[typeof(FormsCheckedListBox), "EmulateCheckStateInTarget", async](AppVar, index, value);
        }

#if ENG
        /// <summary>
        /// Sets the currently selected index.
        /// </summary>
        /// <param name="index">The index.</param>
#else
        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// </summary>
        /// <param name="index">インデックス。</param>
#endif
        public void EmulateChangeSelectedIndex(int index)
        {
            App[typeof(FormsCheckedListBox), "EmulateChangeSelectedIndexInTarget"](AppVar, index);
        }

#if ENG
        /// <summary>
        /// Sets the currently selected index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">The index.</param>
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
            App[typeof(FormsCheckedListBox), "EmulateChangeSelectedIndexInTarget", async](AppVar, index);
        }

        /// <summary>
        /// チェック状態を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="checkedListBox">対象のチェックリストボックス。</param>
        /// <param name="index">インデックス。</param>
        /// <param name="value">チェック状態。</param>
        static void EmulateCheckStateInTarget(CheckedListBox checkedListBox, int index, CheckState value)
        {
            checkedListBox.Focus();
            checkedListBox.SetItemCheckState(index, value);
        }

        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// 非同期に実行します。
        /// </summary>
        /// <param name="checkedListBox">対象のチェックリストボックス。</param>
        /// <param name="index">インデックス。</param>
        static void EmulateChangeSelectedIndexInTarget(CheckedListBox checkedListBox, int index)
        {
            checkedListBox.Focus();
            checkedListBox.SelectedIndex = index;
        }

        /// <summary>
        /// 現在チェックされているアイテムのインデックスを配列で取得します(内部)。
        /// </summary>
        /// <param name="checkedListBox">対象のチェックリストボックス。</param>
        /// <returns></returns>
        private static int[] CheckedIndicsInTarget(CheckedListBox checkedListBox)
        {
            List<int> checkedlist = new List<int>();
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    checkedlist.Add(i);
                }
            }
            return checkedlist.ToArray();
        }
    }
}
