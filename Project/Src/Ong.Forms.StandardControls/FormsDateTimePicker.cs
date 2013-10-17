using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;
using System;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがSystem.Windows.Forms.DateTimePickerのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsDateTimePicker : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです。</param>
        public FormsDateTimePicker(WindowControl src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsDateTimePicker(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// 現在時間を取得します。
        /// </summary>
        public DateTime SelectedDay
        {
            get { return (DateTime)(this["Value"]().Core); }
        }

        /// <summary>
        /// 現在時間を設定します。
        /// </summary>
        public void EmulateSelectDay(DateTime day)
        {
            App[GetType(), "EmulateSelectDayInTarget"](AppVar,day);
        }

        /// <summary>
        /// 現在時間を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="day">非同期実行オブジェクト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateSelectDay(DateTime day, Async async)
        {
            App[GetType(), "EmulateSelectDayInTarget", async](AppVar, day);
        }

        /// <summary>
        /// 現在時間を設定します。
        /// </summary>
        /// <param name="datetimepicker">DateTimePicker</param>
        static void EmulateSelectDayInTarget(DateTimePicker datetimepicker,DateTime day)
        {
            datetimepicker.Value = day;
        }
    }
}