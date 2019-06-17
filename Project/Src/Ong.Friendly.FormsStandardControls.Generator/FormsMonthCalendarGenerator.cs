using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsMonthCalendar.
    /// </summary>
#else
    /// <summary>
    /// FormsMonthCalendarの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsMonthCalendar")]
    public class FormsMonthCalendarGenerator :CaptureCodeGeneratorBase
    {
        MonthCalendar _control;

#if ENG
        /// <summary>
        /// Attach.
        /// </summary>
#else
        /// <summary>
        /// アタッチ。
        /// </summary>
#endif
        protected override void Attach()
        {
            _control = (MonthCalendar)ControlObject;
            _control.DateChanged += MonthCalendarDateChanged;
        }

#if ENG
        /// <summary>
        /// Detach.
        /// </summary>
#else
        /// <summary>
        /// ディタッチ。
        /// </summary>
#endif
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
                DateTime selectionStart = _control.SelectionStart;
                DateTime selectionEnd = _control.SelectionEnd;
                AddUsingNamespace(typeof(DateTime).Namespace);
                if (selectionStart == selectionEnd)
                {
                    AddSentence(new TokenName(), ".EmulateSelectDay(new DateTime(",
                        selectionStart.Year, ", ",
                        selectionStart.Month, ", ",
                        selectionStart.Day, ")",
                        new TokenAsync(CommaType.Before), ");");
                }
                else
                {
                    AddSentence(new TokenName(), ".EmulateSelectDay(new DateTime(",
                        selectionStart.Year, ", ",
                        selectionStart.Month, ", ",
                        selectionStart.Day, "), new DateTime(",
                        selectionEnd.Year, ", ",
                        selectionEnd.Month, ", ",
                        selectionEnd.Day, ")",
                        new TokenAsync(CommaType.Before), ");");
                }
            }
        }
    }
}
