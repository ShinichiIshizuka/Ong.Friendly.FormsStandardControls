using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;
using System;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがSystem.Windows.Forms.FormsMonthCalendarのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsMonthCalendar : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです。</param>
        public FormsMonthCalendar(WindowControl src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsMonthCalendar(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// カレンダーの左端の列に表示される曜日を取得します。
        /// </summary>
        public Day FirstDayOfWeek
        {
            get { return (Day)(this["FirstDayOfWeek"]().Core); }
        }

        /// <summary>
        /// 選択できる最大日数です。 
        /// </summary>
        public int MaxSelectionCount
        {
            get { return (int)(this["MaxSelectionCount"]().Core); }
        }

        /// <summary>
        /// 現在の選択日時です。 
        /// </summary>
        public DateTime SelectedDay
        {
            get { return (DateTime)(this["SelectionRange"]()["Start"]().Core); }
        }

        /// <summary>
        /// 今日の日付です。 
        /// </summary>
        public DateTime Today
        {
            get { return (DateTime)(this["TodayDate"]().Core); }
        }

        /// <summary>
        /// 現在の選択日付を設定します。
        /// </summary>
        /// <param name="date">日付</param>
        public void EmulateSelectDay(DateTime date)
        {
            App[GetType(), "EmulateSelectDayInTarget"](AppVar, date);
        }

        /// <summary>
        /// 現在の選択日付を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="date">日付。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateSelectDay(DateTime date, Async async)
        {
            App[GetType(), "EmulateSelectDayInTarget", async](AppVar, date);
        }

        /// <summary>
        /// 現在の選択日付を設定します。
        /// </summary>
        /// <param name="monthcalendar">MonthCalender。</param>
        /// <param name="date">日付。</param>
        static void EmulateSelectDayInTarget(MonthCalendar monthcalendar, DateTime date)
        {
            monthcalendar.SelectionRange = new SelectionRange(date, date);
        }

        /// <summary>
        /// ユーザーによって現在選択されている日付範囲を取得します。 複数選択の場合に使用します。 
        /// </summary>
        /// <param name="min">最小日付。</param>
        /// <param name="max">最大日付。</param>
        /// <returns>成否。</returns>
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