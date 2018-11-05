using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.TestAssistant.GeneratorToolKit;
using System;

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
    [ControlDriver(TypeFullName = "System.Windows.Forms.ToolStripTextBox", DriverMappingEnabled = false)]
    public class FormsToolStripTextBox : FormsToolStripItem
    {
#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsToolStripTextBox(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsToolStripTextBox(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsToolStripTextBox(AppVar windowObject).", false)]
        public FormsToolStripTextBox(WindowsAppFriend app, AppVar appVar)
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
        public FormsToolStripTextBox(AppVar appVar)
            : base(appVar) { }

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
        public FormsToolStripTextBox(FormsToolStripItem item) : base(item.AppVar) { }

#if ENG
        /// <summary>
        /// Returns a FormsTextBox object for the underlying text box.
        /// </summary>
#else
        /// <summary>
        /// テキストボックス取得です。
        /// </summary>
#endif
        public FormsTextBox TextBox { get { return new FormsTextBox(this["TextBox"]()); } }
    }
}
