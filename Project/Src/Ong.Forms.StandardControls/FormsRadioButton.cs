using System;
using System.Windows.Forms;
using System.Reflection;
using Ong.Friendly.FormsStandardControls.Properties;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.RadioButton.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.RadioButtonのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.RadioButton")]
    public class FormsRadioButton : FormsControlBase
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
        public FormsRadioButton(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsRadioButton(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsRadioButton(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsRadioButton(AppVar windowObject).", false)]
        public FormsRadioButton(WindowsAppFriend app, AppVar appVar)
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
        public FormsRadioButton(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the checked state state.
        /// </summary>
#else
        /// <summary>
        /// チェック状態を取得します。
        /// </summary>
#endif
        public bool Checked
        {
            get { return (bool)(this["Checked"]().Core); }
        }

#if ENG
        /// <summary>
        /// Checks this control.
        /// </summary>
#else
        /// <summary>
        /// チェックします。
        /// </summary>
#endif
        public void EmulateCheck()
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Checks this control.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// チェックします。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateCheck(Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar);
        }

        /// <summary>
        /// チェック状態にします。
        /// </summary>
        /// <param name="radioButton">ラジオボタン。</param>
        static void EmulateCheckInTarget(RadioButton radioButton)
        {
            radioButton.Focus();
            int tryCount = 0;
            while (radioButton.Checked != true)
            {
                tryCount++;
                radioButton.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(radioButton, new object[] { EventArgs.Empty });
                if (tryCount == 2)
                {
                    throw new NotSupportedException(ResourcesLocal.Instance.ErrorCheckSetting);
                }
            }
        }
    }
}
