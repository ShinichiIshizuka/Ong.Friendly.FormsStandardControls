using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;
using System;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.MonthCalendar.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.FormsMonthCalendarのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.MonthCalendar")]
    public class FormsMonthCalendar : FormsControlBase
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
        public FormsMonthCalendar(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsMonthCalendar(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsMonthCalendar(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsMonthCalendar(AppVar windowObject).", false)]
        public FormsMonthCalendar(WindowsAppFriend app, AppVar appVar)
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
        public FormsMonthCalendar(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Gets the first day of the week as displayed in the month calendar.
        /// </summary>
#else
        /// <summary>
        /// カレンダーの左端の列に表示される曜日を取得します。
        /// </summary>
#endif
        public Day FirstDayOfWeek
        {
            get { return (Day)(this["FirstDayOfWeek"]().Core); }
        }

#if ENG
        /// <summary>
        /// Max of selection count.
        /// </summary>
#else
        /// <summary>
        /// 選択できる最大日数です。 
        /// </summary>
#endif
        public int MaxSelectionCount
        {
            get { return (int)(this["MaxSelectionCount"]().Core); }
        }

#if ENG
        /// <summary>
        /// Gets the maximum number of days that can be selected in a month calendar control.
        /// </summary>
#else
        /// <summary>
        /// 現在の選択日時です。 
        /// </summary>
#endif
        public DateTime SelectedDay
        {
            get { return (DateTime)(this["SelectionRange"]()["Start"]().Core); }
        }

#if ENG
        /// <summary>
        /// Today. 
        /// </summary>
#else
        /// <summary>
        /// 今日の日付です。 
        /// </summary>
#endif
        public DateTime Today
        {
            get { return (DateTime)(this["TodayDate"]().Core); }
        }

#if ENG
        /// <summary>
        /// Sets selected day.
        /// </summary>
        /// <param name="date">day.</param>
#else
        /// <summary>
        /// 現在の選択日付を設定します。
        /// </summary>
        /// <param name="date">日付。</param>
#endif
        public void EmulateSelectDay(DateTime date)
        {
            App[typeof(FormsMonthCalendar), "EmulateSelectDayInTarget"](AppVar, date);
        }

#if ENG
        /// <summary>
        /// Sets selected day.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="date">day.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 現在の選択日付を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="date">日付。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateSelectDay(DateTime date, Async async)
        {
            App[typeof(FormsMonthCalendar), "EmulateSelectDayInTarget", async](AppVar, date);
        }

        /// <summary>
        /// 現在の選択日付を設定します。
        /// </summary>
        /// <param name="monthcalendar">MonthCalender。</param>
        /// <param name="date">日付。</param>
        static void EmulateSelectDayInTarget(MonthCalendar monthcalendar, DateTime date)
        {
            monthcalendar.Focus();
            monthcalendar.SelectionRange = new SelectionRange(date, date);
        }

#if ENG
        /// <summary>
        /// Sets selected day range.
        /// </summary>
        /// <param name="min">maximum.</param>
        /// <param name="max">minimum.</param>
#else
        /// <summary>
        /// 現在の選択日付(範囲)を設定します。
        /// </summary>
        /// <param name="min">最小日付。</param>
        /// <param name="max">最大日付。</param>
#endif
        public void EmulateSelectDay(DateTime min, DateTime max)
        {
            App[typeof(FormsMonthCalendar), "EmulateSelectDaysInTarget"](AppVar, min, max);
        }

#if ENG
        /// <summary>
        /// Sets selected day range.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="min">maximum.</param>
        /// <param name="max">minimum.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 現在の選択日付(範囲)を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="min">最小日付。</param>
        /// <param name="max">最大日付。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateSelectDay(DateTime min, DateTime max, Async async)
        {
            App[typeof(FormsMonthCalendar), "EmulateSelectDaysInTarget", async](AppVar, min, max);
        }

        /// <summary>
        /// 現在の選択日付(範囲)を設定します。
        /// </summary>
        /// <param name="monthcalendar">MonthCalender。</param>
        /// <param name="min">最小日付。</param>
        /// <param name="max">最大日付。</param>
        static void EmulateSelectDaysInTarget(MonthCalendar monthcalendar, DateTime min, DateTime max)
        {
            monthcalendar.Focus();
            monthcalendar.SelectionRange = new SelectionRange(min, max);
        }

#if ENG
        /// <summary>
        /// Gets selected day range.
        /// </summary>
        /// <param name="min">maximum.</param>
        /// <param name="max">minimum.</param>
        /// <returns>Success or failure.</returns>
#else
        /// <summary>
        /// ユーザーによって現在選択されている日付範囲を取得します。 複数選択の場合に使用します。 
        /// </summary>
        /// <param name="min">最小日付。</param>
        /// <param name="max">最大日付。</param>
        /// <returns>成否。</returns>
#endif
        public bool GetSelectionRange(ref DateTime min, ref DateTime max)
        {
            bool ret = true;
            try
            {
                min = (DateTime)(this["SelectionRange"]()["Start"]().Core);
                max = (DateTime)(this["SelectionRange"]()["End"]().Core);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
    }
}