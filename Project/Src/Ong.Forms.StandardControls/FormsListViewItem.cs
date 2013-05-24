using System;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.Friendly.Windows;
using System.Windows.Forms;
using System.Reflection;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// リストアイテム
    /// </summary>
    public class FormsListViewItem:AppVarWrapper
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsListViewItem(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
        }
    
        /// <summary>
        /// テキストを取得します。
        /// </summary>
        /// <returns>テキスト。</returns>
        public String Text
        {
            get { return (String)this["Text"]().Core; }
        }

        /// <summary>
        /// アイテムインデックスを取得します。
        /// </summary>
        /// <returns>行番号。</returns>
        public int ItemIndex
        {
            get { return (int)this["Index"]().Core; }
        }

        /// <summary>
        /// チェック状態を取得します。
        /// </summary>
        public bool Checked
        {
            get { return (bool)this["Checked"]().Core; }
        }

        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="value">チェック状態。</param>
        public void EmulateCheck(bool value)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, value);
        }

        /// <summary>
        /// チェック状態を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="value">チェック状態。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateCheck(bool value, Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar, value);
        }

        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="listviewitem">リストビューアイテム。</param>
        /// <param name="value">チェック状態。</param>
        static void EmulateCheckInTarget(ListViewItem listviewitem, bool value)
        {
            listviewitem.Checked = value;
        }

        /// <summary>
        /// サブアイテムを取得します。
        /// </summary>
        /// <param name="subitemindex">サブアイテムインデックス。</param>
        /// <returns></returns>
        public FormsListViewSubItem GetSubItem(int subitemindex)
        {
            return new FormsListViewSubItem(App, App[GetType(), "GetSubItemInTarget"](AppVar, subitemindex));
        }

        /// <summary>
        /// サブアイテムを取得します(内部)。
        /// </summary>
        /// <param name="listviewitem">リストビューアイテム。</param>
        /// <param name="subitemindex">リストビューサブアイテムインデックス。</param>
        /// <returns>FormsListViewSubItem</returns>
        static ListViewItem.ListViewSubItem GetSubItemInTarget(ListViewItem listviewitem, int subitemindex)
        {
            return listviewitem.SubItems[subitemindex];
        }
    }
}
