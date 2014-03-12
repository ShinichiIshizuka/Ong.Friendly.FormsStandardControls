using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;
using System;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.DateTimePicker.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.DateTimePickerのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    public class FormsDateTimePicker : FormsControlBase
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
        public FormsDateTimePicker(WindowControl src)
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
        public FormsDateTimePicker(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Get current selected DateTime.
        /// </summary>
#else
        /// <summary>
        /// 現在日時を取得します。
        /// </summary>
#endif
        public DateTime SelectedDay
        {
            get { return (DateTime)(this["Value"]().Core); }
        }

#if ENG
        /// <summary>
        /// Set current selected DateTime.
        /// </summary>
        /// <param name="datetime">DateTime.</param>
#else
        /// <summary>
        /// 現在日時を設定します。
        /// </summary>
        /// <param name="datetime">日時。</param>
#endif
        public void EmulateSelectDay(DateTime datetime)
        {
            App[GetType(), "EmulateSelectDayInTarget"](AppVar, datetime);
        }

#if ENG
        /// <summary>
        /// Set current selected DateTime.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="datetime">DateTime.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 現在日時を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="datetime">日時。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateSelectDay(DateTime datetime, Async async)
        {
            App[GetType(), "EmulateSelectDayInTarget", async](AppVar, datetime);
        }

        /// <summary>
        /// 現在時間を設定します。
        /// </summary>
        /// <param name="datetimepicker">DateTimePicker。</param>
        /// <param name="datetime">時間。</param>
        static void EmulateSelectDayInTarget(DateTimePicker datetimepicker, DateTime datetime)
        {
            datetimepicker.Focus();
            datetimepicker.Value = datetime;
        }
    }
}