using Codeer.Friendly;
using Codeer.Friendly.Windows;
using System;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Represents a sub-item in a list view.
    /// </summary>
#else
    /// <summary>
    /// リストビューサブアイテムです。
    /// </summary>
#endif
    public class FormsListViewSubItem : AppVarWrapper
    {
#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsListViewSubItem(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsListViewSubItem(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsListViewSubItem(AppVar windowObject).", false)]
        public FormsListViewSubItem(WindowsAppFriend app, AppVar appVar)
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
        public FormsListViewSubItem(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the sub-item's text.
        /// </summary>
#else
        /// <summary>
        /// テキストを取得します。
        /// </summary>
#endif
        public string Text
        {
            get { return (string)this["Text"]().Core; }
        }
    }
}
