using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Reflection;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// WindowControlがSystem.Windows.Forms.ComboBoxのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsComboBox : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsComboBox(FormsControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsComboBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// 一覧のアイテム数を取得します
        /// </summary>
        public int ItemCount
        {
            get 
            {
                return (int)(this["Items"]()["Count"]().Core);
            }
        }

        /// <summary>
        /// 現在選択されているアイテムのインデックスを取得します
        /// </summary>
        public int SelectedItemIndex
        {
            get 
            {
                return (int)(this["SelectedIndex"]().Core);
            }
        }

        /// <summary>
        /// アイテム文字列取得
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>アイテム文字列</returns>
        public string GetItemText(int index)
        {
            return this["Items"]()["[]"](index).ToString();
        }

        /// <summary>
        /// 指定の文字列のアイテムを検索します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <param name="startIndex">検索開始インデックス。</param>
        /// <returns>アイテムインデックス。</returns>
        public int FindString(string text, int startIndex)
        {
            return (int)this["FindString"](text, startIndex).Core;
        }

        /// <summary>
        /// テキストを変更します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        public void EmulateChangeText(string text)
        {
            this["Text"](text);
        }

        /// <summary>
        /// テキストを変更します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateChangeText(string text, Async async)
        {
            this["Text", async](text);
        }

        /// <summary>
        /// 指定のインデックスのアイテムを選択します
        /// </summary>
        /// <param name="index">インデックス</param>
        public void EmulateChangeSelect(int index)
        {
            App[GetType(), "EmulateChangeSelectInTarget"](AppVar, index);
        }

        /// <summary>
        /// 指定のインデックスのアイテムを選択します
        /// 非同期で実行します。
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <param name="async">非同期実行オブジェクト</param>
        public void EmulateChangeSelect(int index, Async async)
        {
            App[GetType(), "EmulateChangeSelectInTarget", async](AppVar, index);
        }

        /// <summary>
        /// 指定のインデックスのアイテムを選択します
        /// </summary>
        /// <param name="comboBox">コンボボックス</param>
        /// <param name="index">インデックス</param>
        static void EmulateChangeSelectInTarget(ComboBox comboBox, int index)
        {
            comboBox.SelectedIndex = index;
            comboBox.GetType().GetMethod("OnSelectionChangeCommitted", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(comboBox, new object[] { EventArgs.Empty });
        }

    }
}