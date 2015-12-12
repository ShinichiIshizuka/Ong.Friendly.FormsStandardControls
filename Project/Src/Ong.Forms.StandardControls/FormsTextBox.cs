using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.TextBox.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.TextBoxのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    public class FormsTextBox : FormsControlBase
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
        public FormsTextBox(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsTextBox(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsTextBox(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsTextBox(AppVar windowObject).", false)]
        public FormsTextBox(WindowsAppFriend app, AppVar appVar)
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
        public FormsTextBox(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Sets the control's text.
        /// </summary>
        /// <param name="text">Text to use.</param>
#else
        /// <summary>
        /// テキストを変更します。
        /// </summary>
        /// <param name="text">テキスト。</param>
#endif
        public void EmulateChangeText(string text)
        {
            App[GetType(), "EmulateChangeTextInTarget"](AppVar, text);
        }

#if ENG
        /// <summary>
        /// Sets the control's text.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="text">Text to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// テキストを変更します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateChangeText(string text, Async async)
        {
            App[GetType(), "EmulateChangeTextInTarget", async](AppVar, text);
        }

        /// <summary>
        /// テキストを変更します。
        /// </summary>
        /// <param name="textBox">リッチテキストボックス。</param>
        /// <param name="text">テキスト。</param>
        static void EmulateChangeTextInTarget(TextBox textBox, string text)
        {
            textBox.Focus();
            textBox.Text = text;
        }
    }
}