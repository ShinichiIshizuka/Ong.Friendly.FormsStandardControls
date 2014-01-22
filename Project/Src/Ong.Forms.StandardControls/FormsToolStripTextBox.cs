using Codeer.Friendly;
using Codeer.Friendly.Windows;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on tool strip textboxes.
    /// </summary>
#else
    /// <summary>
    /// ツールストリップアイテム操作クラスです。
    /// </summary>
#endif
    public class FormsToolStripTextBox : FormsToolStripItem
    {
#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">対象アプリ操作クラス。</param>
        /// <param name="appVar">対象アプリケーション内変数操作クラス。</param>
#endif
        public FormsToolStripTextBox(WindowsAppFriend app, AppVar appVar) : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="item">ToolStripItem操作クラス</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="item">ToolStripItem操作クラス</param>
#endif
        public FormsToolStripTextBox(FormsToolStripItem item) : base(item.App, item.AppVar) { }

#if ENG
        /// <summary>
        /// Returns a FormsTextBox object for the underlying text box.
        /// </summary>
#else
        /// <summary>
        /// テキストボックス取得です。
        /// </summary>
#endif
        public FormsTextBox TextBox { get { return new FormsTextBox(App, this["TextBox"]()); } }
    }
}
