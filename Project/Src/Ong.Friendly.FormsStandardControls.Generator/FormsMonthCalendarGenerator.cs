using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsMonthCalendarGenerator :GeneratorBase
    {
        MonthCalendar _control;

        /// <summary>
        /// アタッチ。
        /// </summary>
        protected override void Attach()
        {
            _control = (MonthCalendar)ControlObject;
            _control.DateChanged += MonthCalendarDateChanged;
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
        protected override void Detach()
        {
            _control.DateChanged -= MonthCalendarDateChanged;
        }

        /// <summary>
        /// 日付変更
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void MonthCalendarDateChanged(object sender, EventArgs e)
        {
            if(_control.Focused)
            {
                DateTime selection = _control.SelectionStart;
                AddSentence(new TokenName(), ".EmulateSelectDay(new DateTime(", selection.Year, ", ", selection.Month, ", ", selection.Day, ")", new TokenAsync(CommaType.Before), ");");
            }
        }
    }
}
