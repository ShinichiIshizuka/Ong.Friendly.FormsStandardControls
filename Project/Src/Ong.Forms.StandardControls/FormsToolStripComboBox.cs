using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.TestAssistant.GeneratorToolKit;
using System;

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
    [ControlDriver(TypeFullName = "System.Windows.Forms.ToolStripComboBox", DriverMappingEnabled = false)]
    public class FormsToolStripComboBox : AppVarWrapper
    {
#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsToolStripComboBox(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsToolStripComboBox(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsToolStripComboBox(AppVar windowObject).", false)]
        public FormsToolStripComboBox(WindowsAppFriend app, AppVar appVar)
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
        public FormsToolStripComboBox(AppVar appVar)
            : base(appVar) { }

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
        public FormsToolStripComboBox(FormsToolStripItem item) : base(item.AppVar) { }

#if ENG
        /// <summary>
        /// Returns a FormsComboBox object for the underlying combo box.
        /// </summary>
#else
        /// <summary>
        /// コンボボックスを取得します。
        /// </summary>
#endif
        public FormsComboBox ComboBox { get { return new FormsComboBox(this["ComboBox"]()); } }
    }
}
