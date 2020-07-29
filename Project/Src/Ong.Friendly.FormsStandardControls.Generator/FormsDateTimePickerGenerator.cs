using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsDateTimePicker.
    /// </summary>
#else
    /// <summary>
    /// FormsDateTimePickerの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsDateTimePicker")]
    public class FormsDateTimePickerGenerator : CaptureCodeGeneratorBase
    {
        DateTimePicker _control;

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
            _control = (DateTimePicker)ControlObject;
            _control.ValueChanged += DateTimeValueChanged;
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
            _control.ValueChanged -= DateTimeValueChanged;
        }

        /// <summary>
        /// 日付変更
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void DateTimeValueChanged(object sender, EventArgs e)
        {
            AddUsingNamespace(typeof(DateTime).Namespace);
            AddSentence(new TokenName(), ".EmulateSelectDay(new DateTime(", _control.Value.Year , ", " , _control.Value.Month , ", " ,_control.Value.Day , ")", new TokenAsync(CommaType.Before),");");
        }

#if ENG
        /// <summary>
        /// Optimize the code.
        /// </summary>
        /// <param name="code">code.</param>
#else
        /// <summary>
        /// コードの最適化。
        /// </summary>
        /// <param name="code">コードリスト。</param>
#endif
        public override void Optimize(List<Sentence> code)
        {
            GenerateUtility.RemoveDuplicationFunction(this, code, "EmulateSelectDay");
        }
    }
}