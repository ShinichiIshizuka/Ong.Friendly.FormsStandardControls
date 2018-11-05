using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System;
using Ong.Friendly.FormsStandardControls.Properties;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on tool strip buttons.
    /// </summary>
#else
    /// <summary>
    /// ツールストリップボタン操作クラスです。
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.ToolStripButton", DriverMappingEnabled = false)]
    public class FormsToolStripButton : FormsToolStripItem
    {
#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsToolStripButton(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsToolStripButton(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsToolStripButton(AppVar windowObject).", false)]
        public FormsToolStripButton(WindowsAppFriend app, AppVar appVar)
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
        public FormsToolStripButton(AppVar appVar)
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
        public FormsToolStripButton(FormsToolStripItem item) : base(item.AppVar) { }

#if ENG
        /// <summary>
        /// Returns the button's check state.
        /// </summary>
#else
        /// <summary>
        /// チェック状態を取得します。
        /// </summary>
#endif
        public CheckState CheckState
        {
            get { return (CheckState)(this["CheckState"]().Core); }
        }

#if ENG
        /// <summary>
        /// Sets the button's check state.
        /// </summary>
        /// <param name="value">Check state to use.</param>
#else
        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="value">チェック状態。</param>
#endif
        public void EmulateCheck(CheckState value)
        {
            App[typeof(FormsToolStripButton), "EmulateCheckInTarget"](AppVar, value);
        }

#if ENG
        /// <summary>
        /// Sets the button's check state.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="value">Check state to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// チェック状態を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="value">チェック状態。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateCheck(CheckState value, Async async)
        {
            App[typeof(FormsToolStripButton), "EmulateCheckInTarget", async](AppVar, value);
        }

        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="checkButton">チェックボックス。</param>
        /// <param name="value">チェック状態。</param>
        static void EmulateCheckInTarget(ToolStripButton checkButton, CheckState value)
        {
            if (checkButton.Owner == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetToolStrip);
            }
            checkButton.Owner.Focus();
            while (checkButton.CheckState != value)
            {
                checkButton.PerformClick();
            }
        }
    }
}
