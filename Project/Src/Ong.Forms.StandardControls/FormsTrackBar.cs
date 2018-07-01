using Codeer.Friendly;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{

#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.TrackBar.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.TrackBarのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.TrackBar")]
    public class FormsTrackBar : FormsControlBase
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
        public FormsTrackBar(WindowControl src)
            : base(src)
        { }

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
        public FormsTrackBar(AppVar appVar)
            : base(appVar)
        { }

#if ENG
        /// <summary>
        /// Minimum.
        /// </summary>
#else
        /// <summary>
        /// 最小値です。
        /// </summary>
#endif
        public int Minimum
        {
            get { return (int)this["Minimum"]().Core; }
        }

#if ENG
        /// <summary>
        /// Maximum.
        /// </summary>
#else
        /// <summary>
        /// 最大値です。 
        /// </summary>
#endif
        public int Maximum
        {
            get { return (int)this["Maximum"]().Core; }
        }

#if ENG
        /// <summary>
        /// Current value.
        /// </summary>
#else
        /// <summary>
        /// 現在位置です。  
        /// </summary>
#endif
        public int Value
        {
            get { return (int)this["Value"]().Core; }
        }

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
        public void EmulateChangeValue(int value)
        {
            App[GetType(), "EmulateChangeValue"](AppVar, value);
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
        public void EmulateChangeValue(int value, Async async)
        {
            App[GetType(), "EmulateChangeValue", async](AppVar, value);
        }

        /// <summary>
        /// 値を変更します。
        /// </summary>
        /// <param name="trackBar">コントロール。</param>
        /// <param name="value">値。</param>
        static void EmulateChangeValue(TrackBar trackBar, int value)
        {
            trackBar.Focus();
            trackBar.Value = value;
        }
    }
}