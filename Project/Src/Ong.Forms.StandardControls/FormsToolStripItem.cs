using Codeer.Friendly;
using Codeer.Friendly.Windows;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ツールストリップアイテム操作クラスです。
    /// </summary>
    public class FormsToolStripItem : AppVarWrapper
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">対象アプリ操作クラス。</param>
        /// <param name="appVar">対象アプリケーション内変数操作クラス。</param>
        public FormsToolStripItem(WindowsAppFriend app, AppVar appVar) : base(app, appVar) { }

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
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateClick(Async async)
        {
            this["PerformClick", async]();
        }
    }
}
