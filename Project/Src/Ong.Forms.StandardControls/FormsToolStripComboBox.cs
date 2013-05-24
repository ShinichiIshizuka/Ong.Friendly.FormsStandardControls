using Codeer.Friendly;
using Codeer.Friendly.Windows;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ツールストリップアイテム操作クラスです。
    /// </summary>
    public class FormsToolStripComboBox : AppVarWrapper
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">対象アプリ操作クラス。</param>
        /// <param name="appVar">対象アプリケーション内変数操作クラス。</param>
        public FormsToolStripComboBox(WindowsAppFriend app, AppVar appVar) : base(app, appVar) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="item">ToolStripItem操作クラス。</param>
        public FormsToolStripComboBox(FormsToolStripItem item) : base(item.App, item.AppVar) { }

        /// <summary>
        /// コンボボックスを取得します。
        /// </summary>
        public FormsComboBox ComboBox { get { return new FormsComboBox(App, this["ComboBox"]()); } }
    }
}
