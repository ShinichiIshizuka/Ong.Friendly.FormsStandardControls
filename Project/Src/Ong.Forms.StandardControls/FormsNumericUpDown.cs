using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがWindows.Forms.NumericUpDownのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsNumericUpDown : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsNumericUpDown(WindowControl src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsNumericUpDown(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// 値を取得
        /// </summary>
        public decimal Value { get { return (decimal)this["Value"]().Core; } }

        /// <summary>
        /// 最小値を取得
        /// </summary>
        public decimal Minimum { get { return (decimal)this["Minimum"]().Core; } }

        /// <summary>
        /// 最大値を取得
        /// </summary>
        public decimal Maximum { get { return (decimal)this["Maximum"]().Core; } }

        /// <summary>
        /// 値を変更します。
        /// </summary>
        /// <param name="value">値。</param>
        public void EmulateChangeValue(decimal value)
        {
            App[GetType(), "EmulateChangeValueInTarget"](AppVar, value);
        }

        /// <summary>
        /// 値を変更します。
        /// </summary>
        /// <param name="value">値。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
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
