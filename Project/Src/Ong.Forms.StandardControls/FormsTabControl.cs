using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがWindowControlがSystem.Windows.Forms.TabControlのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsTabControl : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
        public FormsTabControl(WindowControl src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsTabControl(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// タブ数を取得します。
        /// </summary>
        /// <returns>タブ数。</returns>
        public int TabCount
        {
            get { return (int)this["TabCount"]().Core; }
        }

        /// <summary>
        /// 選択されたタブインデックスを取得します。
        /// </summary>
        /// <returns>タブインデックス。</returns>
        public int SelectedIndex
        {
            get { return (int)this["SelectedIndex"]().Core; }
        }

        /// <summary>
        /// タブを選択します。
        /// </summary>
        /// <param name="index">タブインデックス（０始まり）。</param>
        public void EmulateTabSelect(int index)
        {
            this["Focus"]();
            this["SelectedIndex"](index);
        }

        /// <summary>
        /// タブを選択します。
        /// </summary>
        /// <param name="index">タブインデックス（０始まり）。</param>
        /// <param name="async">非同期オブジェクト。</param>
        public void EmulateTabSelect(int index, Async async)
        {
            this["Focus", new Async()]();
            this["SelectedIndex", async](index);
        }
    }
}