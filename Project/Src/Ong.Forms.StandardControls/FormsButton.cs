using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.Button.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.Buttonのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    public class FormsButton : FormsControlBase
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
        public FormsButton(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsButton(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsButton(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsButton(AppVar windowObject).", false)]
        public FormsButton(WindowsAppFriend app, AppVar appVar)
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
        public FormsButton(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Performs a click.
        /// </summary>
#else
        /// <summary>
        /// クリックです。
        /// </summary>
#endif
        public void EmulateClick()
        {
            App[GetType(), "EmulateClickInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Performs a click.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// クリックです。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateClick(Async async)
        {
            App[GetType(), "EmulateClickInTarget", async](AppVar);
        }

        /// <summary>
        /// クリックです。
        /// </summary>
        /// <param name="button">ボタン。</param>
        static void EmulateClickInTarget(Button button)
        {
            button.Focus();
            button.PerformClick();
        }
    }
}