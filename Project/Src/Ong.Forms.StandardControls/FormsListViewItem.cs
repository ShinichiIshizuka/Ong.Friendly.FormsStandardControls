using System;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.Friendly.Windows;

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
    }
}
