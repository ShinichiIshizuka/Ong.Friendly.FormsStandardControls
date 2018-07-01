using System;
using System.Reflection;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.ComboBox.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.ComboBoxのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.ComboBox")]
    public class FormsComboBox : FormsControlBase
    {
#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="src">Window control object for the underlying control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
#endif
        public FormsComboBox(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsComboBox(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsComboBox(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsComboBox(AppVar windowObject).", false)]
        public FormsComboBox(WindowsAppFriend app, AppVar appVar)
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
        public FormsComboBox(AppVar appVar)
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
        /// Returns the text for an item in the list.
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <returns>The item's text.</returns>
#else
        /// <summary>
        /// アイテムの文字列を取得します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <returns>アイテム文字列。</returns>
#endif
        public string GetItemText(int index)
        {
            return this["Items"]()["[]"](index).ToString();
        }

#if ENG
        /// <summary>
        /// Returns the index of the first item in the ComboBox that starts with the specified string.
        /// </summary>
        /// <param name="text">Text of item.</param>
        /// <returns>Index of the first item found; returns -1 if no match is found.</returns>
#else
        /// <summary>
        /// 指定の文字列のアイテムを部分一致検索します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <returns>アイテムインデックス。</returns>
#endif
        public int FindString(string text)
        {
            return (int)this["FindString"](text).Core;
        }

#if ENG
        /// <summary>
        /// Returns the index of the first item in the ComboBox beyond the specified index that contains the specified string. The search is not case sensitive.
        /// </summary>
        /// <param name="text">Text of item.</param>
        /// <param name="startIndex">Index of the item before the first item to be searched. Set to -1 to search from the beginning of the control. </param>
        /// <returns>Index of the first item found; returns -1 if no match is found.</returns>
#else
        /// <summary>
        /// 指定の文字列のアイテムを部分一致検索します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <param name="startIndex">検索開始インデックス。</param>
        /// <returns>アイテムインデックス。</returns>
#endif
        public int FindString(string text, int startIndex)
        {
            return (int)this["FindString"](text, startIndex).Core;
        }

#if ENG
        /// <summary>
        /// Finds the first item in the combo box that matches the specified string.
        /// </summary>
        /// <param name="text">Text of item.</param>
        /// <returns>Index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies Empty.</returns>
#else
        /// <summary>
        /// 指定の文字列のアイテムを完全一致検索します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <returns>アイテムインデックス。</returns>
#endif
        public int FindStringExact(string text)
        {
            return (int)this["FindStringExact"](text).Core;
        }

#if ENG
        /// <summary>
        /// Finds the first item after the specified index that matches the specified string.
        /// </summary>
        /// <param name="text">Text of item.</param>
        /// <param name="startIndex">Index of the item before the first item to be searched. Set to -1 to search from the beginning of the control. </param>
        /// <returns>Index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies Empty.</returns>
#else
        /// <summary>
        /// 指定の文字列のアイテムを完全一致検索します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <param name="startIndex">検索開始インデックス。</param>
        /// <returns>アイテムインデックス。</returns>
#endif
        public int FindStringExact(string text, int startIndex)
        {
            return (int)this["FindStringExact"](text, startIndex).Core;
        }

#if ENG
        /// <summary>
        /// Modifies the control's text.
        /// </summary>
        /// <param name="text">Text to use.</param>
#else
        /// <summary>
        /// テキストを変更します。
        /// </summary>
        /// <param name="text">テキスト。</param>
#endif
        public void EmulateChangeText(string text)
        {
            App[GetType(), "EmulateChangeTextInTarget"](AppVar, text);
        }

#if ENG
        /// <summary>
        /// Modifies the control's text.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="text">Text to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// テキストを変更します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateChangeText(string text, Async async)
        {
            App[GetType(), "EmulateChangeTextInTarget", async](AppVar, text);
        }

#if ENG
        /// <summary>
        /// Selects the item with the specified index.
        /// </summary>
        /// <param name="index">Item index.</param>
#else
        /// <summary>
        /// 指定のインデックスのアイテムを選択します。
        /// </summary>
        /// <param name="index">インデックス。</param>
#endif
        public void EmulateChangeSelect(int index)
        {
            App[GetType(), "EmulateChangeSelectInTarget"](AppVar, index);
        }

#if ENG
        /// <summary>
        /// Selects the item with the specified index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Item index.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 指定のインデックスのアイテムを選択します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateChangeSelect(int index, Async async)
        {
            App[GetType(), "EmulateChangeSelectInTarget", async](AppVar, index);
        }

        /// <summary>
        /// テキストを変更します。
        /// </summary>
        /// <param name="comboBox">コンボボックス。</param>
        /// <param name="text">テキスト。</param>
        static void EmulateChangeTextInTarget(ComboBox comboBox, string text)
        {
            comboBox.Focus();
            comboBox.Text = text;
        }

        /// <summary>
        /// 指定のインデックスのアイテムを選択します。
        /// </summary>
        /// <param name="comboBox">コンボボックス。</param>
        /// <param name="index">インデックス。</param>
        static void EmulateChangeSelectInTarget(ComboBox comboBox, int index)
        {
            comboBox.Focus();
            comboBox.SelectedIndex = index;
            comboBox.GetType().GetMethod("OnSelectionChangeCommitted", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(comboBox, new object[] { EventArgs.Empty });
        }
    }
}