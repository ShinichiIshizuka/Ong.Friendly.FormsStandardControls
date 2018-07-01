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
    /// Provides operations on controls of type Windows.Forms.NumericUpDown.
    /// </summary>
#else
    /// <summary>
    /// TypeがWindows.Forms.NumericUpDownのウィンドウに対応した操作を提供します
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.NumericUpDown")]
    public class FormsNumericUpDown : FormsControlBase
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
        /// <param name="src">元となるウィンドウコントロールです</param>
#endif
        public FormsNumericUpDown(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsNumericUpDown(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsNumericUpDown(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsNumericUpDown(AppVar windowObject).", false)]
        public FormsNumericUpDown(WindowsAppFriend app, AppVar appVar)
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
        public FormsNumericUpDown(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the current value.
        /// </summary>
#else
        /// <summary>
        /// 値を取得
        /// </summary>
#endif
        public decimal Value { get { return (decimal)this["Value"]().Core; } }

#if ENG
        /// <summary>
        /// Returns the minimum value.
        /// </summary>
#else
        /// <summary>
        /// 最小値を取得
        /// </summary>
#endif
        public decimal Minimum { get { return (decimal)this["Minimum"]().Core; } }

#if ENG
        /// <summary>
        /// Returns the maximum value.
        /// </summary>
#else
        /// <summary>
        /// 最大値を取得
        /// </summary>
#endif
        public decimal Maximum { get { return (decimal)this["Maximum"]().Core; } }

#if ENG
        /// <summary>
        /// Sets the current value.
        /// </summary>
        /// <param name="value">Value to use.</param>
#else
        /// <summary>
        /// 値を変更します。
        /// </summary>
        /// <param name="value">値。</param>
#endif
        public void EmulateChangeValue(decimal value)
        {
            App[GetType(), "EmulateChangeValueInTarget"](AppVar, value);
        }

#if ENG
        /// <summary>
        /// Sets the current value.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="value">Value to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 値を変更します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="value">値。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateChangeValue(decimal value, Async async)
        {
            App[GetType(), "EmulateChangeValueInTarget", async](AppVar, value);
        }

        /// <summary>
        /// 値を変更します。
        /// </summary>
        /// <param name="numeric">コントロール。</param>
        /// <param name="value">値。</param>
        static void EmulateChangeValueInTarget(NumericUpDown numeric, decimal value)
        {
            numeric.Focus();
            numeric.Value = value;
        }
    }
}
