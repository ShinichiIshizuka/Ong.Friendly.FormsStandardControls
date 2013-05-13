using System;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

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
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsListViewItem(AppVar appVar)
            : base(appVar)
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
