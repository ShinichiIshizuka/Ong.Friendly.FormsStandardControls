using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;

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
            App[GetType(), "EmulateTabSelectInTarget"](AppVar, index);
        }

        /// <summary>
        /// タブを選択します。
        /// </summary>
        /// <param name="index">タブインデックス（０始まり）。</param>
        /// <param name="async">非同期オブジェクト。</param>
        public void EmulateTabSelect(int index, Async async)
        {
            App[GetType(), "EmulateTabSelectInTarget", async](AppVar, index);
        }

        /// <summary>
        /// 指定のインデックスのアイテムを選択します。
        /// </summary>
        /// <param name="tabControl">タブコントロール。</param>
        /// <param name="index">インデックス。</param>
        static void EmulateTabSelectInTarget(TabControl tabControl, int index)
        {
            tabControl.Focus();
            tabControl.SelectedIndex = index;
        }
    }
}