using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Reflection;
using System;
using Ong.Friendly.FormsStandardControls.Properties;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.CheckBox.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.CheckBoxのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    public class FormsCheckBox : FormsControlBase
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
        /// <param name="src">元となるウィンドウコントロールです。</param>
#endif
        public FormsCheckBox(WindowControl src)
            : base(src) { }

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
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        public FormsCheckBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Returns the control's check state.
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
        /// Sets the control's check state.
        /// </summary>
        /// <param name="value">Check state.</param>
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
        /// Sets the control's check state.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="value">Check state.</param>
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
        /// <param name="checkBox">チェックボックス。</param>
        /// <param name="value">チェック状態。</param>
        static void EmulateCheckInTarget(CheckBox checkBox, CheckState value)
        {
            checkBox.Focus();
            int tryCount = 0;
            while (checkBox.CheckState != value)
            {
                tryCount++;
                checkBox.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(checkBox, new object[] { EventArgs.Empty });
                if (tryCount == 2)
                {
                    throw new NotSupportedException(ResourcesLocal.Instance.ErrorCheckSetting);
                }
            }
        }
    }
}