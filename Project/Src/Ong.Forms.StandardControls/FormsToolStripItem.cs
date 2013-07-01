using Codeer.Friendly;
using Codeer.Friendly.Windows;
using System.Windows.Forms;

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
        /// テキスト
        /// </summary>
        public string Text { get { return (string)this["Text"]().Core; } }

        /// <summary>
        /// 可視状態か
        /// </summary>
        public bool Visible { get { return (bool)this["Visible"]().Core; } }

        /// <summary>
        /// 有効であるか
        /// </summary>
        public bool Enabled { get { return (bool)this["Enabled"]().Core; } }

        /// <summary>
        /// クリックです。
        /// </summary>
        public void EmulateClick()
        {
            App[GetType(), "EmulateClickInTarget"](AppVar);
        }

        /// <summary>
        /// クリックです。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateClick(Async async)
        {
            App[GetType(), "EmulateClickInTarget", async](AppVar);
        }

        /// <summary>
        /// クリックです。
        /// </summary>
        /// <param name="item">アイテム。</param>
        static void EmulateClickInTarget(ToolStripItem item)
        {
            if (item.Owner != null)
            {
                item.Owner.Focus();
            }
            item.PerformClick();
        }
    }
}
