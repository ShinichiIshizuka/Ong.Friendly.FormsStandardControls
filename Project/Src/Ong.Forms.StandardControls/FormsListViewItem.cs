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
        /// コンストラクタ
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsListViewItem(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
        }
    
        /// <summary>
        /// テキストを取得します
        /// </summary>
        /// <returns>テキスト</returns>
        public String Text
        {
            get { return (String)this["Text"]().Core; }
        }

        /// <summary>
        /// 行を取得します
        /// </summary>
        /// <returns>行番号</returns>
        public int RowIndex
        {
            get { return (int)this["Index"]().Core; }
        }

        public bool Checked
        {
            get { return (bool)this["Checked"]().Core; }
        }

        /// <summary>
        /// チェック状態を設定します
        /// </summary>
        /// <param name="value">チェック状態</param>
        public void EmulateCheck(bool value)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, value);
        }

        /// <summary>
        /// チェック状態を設定します
        /// 非同期で実行します
        /// </summary>
        /// <param name="value">チェック状態</param>
        /// <param name="async">非同期実行オブジェクト</param>
        public void EmulateCheck(bool value, Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar, value);
        }

        /// <summary>
        /// チェック状態を設定します
        /// </summary>
        /// <param name="listviewitem">リストビューアイテム</param>
        /// <param name="value">チェック状態</param>
        static void EmulateCheckInTarget(ListViewItem listviewitem, bool value)
        {
            listviewitem.Checked = value;
        }
    }
}
