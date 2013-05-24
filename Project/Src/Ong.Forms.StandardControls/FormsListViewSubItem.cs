using System;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.Friendly.Windows;
using System.Windows.Forms;
using System.Reflection;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// リストビューサブアイテムです。
    /// </summary>
    public class FormsListViewSubItem:AppVarWrapper
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsListViewSubItem(WindowsAppFriend app, AppVar appVar)
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
    }
}
