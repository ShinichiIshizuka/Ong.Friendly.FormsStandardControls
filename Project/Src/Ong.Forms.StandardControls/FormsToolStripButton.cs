using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System;
using Ong.Friendly.FormsStandardControls.Properties;
using Ong.Friendly.FormsStandardControls.Inside;

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
    public class FormsToolStripButton : FormsToolStripItem
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
        public FormsToolStripButton(WindowsAppFriend app, AppVar appVar) : base(app, appVar) { }

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
        public FormsToolStripButton(FormsToolStripItem item) : base(item.App, item.AppVar) { }

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
            App[GetType(), "EmulateCheckInTarget"](AppVar, value);
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
            App[GetType(), "EmulateCheckInTarget", async](AppVar, value);
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
