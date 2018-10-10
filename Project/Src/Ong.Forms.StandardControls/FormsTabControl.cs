using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using System;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.TabControl.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.TabControlのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.TabControl", SearchDescendantUserControls = true)]
    public class FormsTabControl : FormsControlBase
    {
#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="src">WindowControl object for the underlying control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
#endif
        public FormsTabControl(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsTabControl(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsTabControl(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsTabControl(AppVar windowObject).", false)]
        public FormsTabControl(WindowsAppFriend app, AppVar appVar)
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
        public FormsTabControl(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the number of tabs.
        /// </summary>
#else
        /// <summary>
        /// タブ数を取得します。
        /// </summary>
#endif
        public int TabCount
        {
            get { return (int)this["TabCount"]().Core; }
        }

#if ENG
        /// <summary>
        /// Returns the currently selected index.
        /// </summary>
#else
        /// <summary>
        /// 選択されたタブインデックスを取得します。
        /// </summary>
#endif
        public int SelectedIndex
        {
            get { return (int)this["SelectedIndex"]().Core; }
        }

#if ENG
        /// <summary>
        /// Selects a certain tab.
        /// </summary>
        /// <param name="index">Index (0-based) of the tab to select.</param>
#else
        /// <summary>
        /// タブを選択します。
        /// </summary>
        /// <param name="index">タブインデックス（０始まり）。</param>
#endif
        public void EmulateTabSelect(int index)
        {
            App[typeof(FormsTabControl), "EmulateTabSelectInTarget"](AppVar, index);
        }

#if ENG
        /// <summary>
        /// Selects a certain tab.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Index (0-based) of the tab to select.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// タブを選択します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="index">タブインデックス（０始まり）。</param>
        /// <param name="async">非同期オブジェクト。</param>
#endif
        public void EmulateTabSelect(int index, Async async)
        {
            App[typeof(FormsTabControl), "EmulateTabSelectInTarget", async](AppVar, index);
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