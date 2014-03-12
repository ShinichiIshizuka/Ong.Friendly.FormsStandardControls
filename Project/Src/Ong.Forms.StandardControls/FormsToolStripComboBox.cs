using Codeer.Friendly;
using Codeer.Friendly.Windows;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on tool strip combo boxes.
    /// </summary>
#else
    /// <summary>
    /// ツールストリップアイテム操作クラスです。
    /// </summary>
#endif
    public class FormsToolStripComboBox : AppVarWrapper
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
        public FormsToolStripComboBox(WindowsAppFriend app, AppVar appVar) : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="item">ToolStripItem manipulation object.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="item">ToolStripItem操作クラス。</param>
#endif
        public FormsToolStripComboBox(FormsToolStripItem item) : base(item.App, item.AppVar) { }

#if ENG
        /// <summary>
        /// Returns a FormsComboBox object for the underlying combo box.
        /// </summary>
#else
        /// <summary>
        /// コンボボックスを取得します。
        /// </summary>
#endif
        public FormsComboBox ComboBox { get { return new FormsComboBox(App, this["ComboBox"]()); } }
    }
}
