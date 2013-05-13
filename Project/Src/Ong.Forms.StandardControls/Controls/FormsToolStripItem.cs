using System;
using System.Collections.Generic;
using System.Text;
using Codeer.Friendly;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ツールストリップアイテム操作クラス
    /// </summary>
    public class FormsToolStripItem : AppVarWrapBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="appVar">対象アプリケーション内変数操作クラス</param>
        public FormsToolStripItem(AppVar appVar) : base(appVar) { }

        /// <summary>
        /// クリックをエミュレートします。
        /// </summary>
        public void EmulateClick()
        {
            this["PerformClick"]();
        }

        /// <summary>
        /// クリックをエミュレートします。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト</param>
        public void EmulateClick(Async async)
        {
            this["PerformClick", async]();
        }
    }
}
