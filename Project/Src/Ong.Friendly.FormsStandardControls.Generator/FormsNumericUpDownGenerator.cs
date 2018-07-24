using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsNumericUpDown.
    /// </summary>
#else
    /// <summary>
    /// FormsNumericUpDownの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsNumericUpDown")]
    public class FormsNumericUpDownGenerator : CaptureCodeGeneratorBase
    {
        NumericUpDown _control;

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
            _control = (NumericUpDown)ControlObject;
            _control.TextChanged += TextChanged;
            _control.ValueChanged += ValueChanged;
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
            _control.TextChanged -= TextChanged;
            _control.ValueChanged -= ValueChanged;
        }

        private void TextChanged(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                if (decimal.TryParse(_control.Text, out var d))
                {
                    AddSentence(new TokenName(), ".EmulateChangeValue(" + _control.Text + "", new TokenAsync(CommaType.Before), ");");
                }
            }
        }


        /// <summary>
        /// 値変更イベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void ValueChanged(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                AddSentence(new TokenName(), ".EmulateChangeValue(" + _control.Value + "", new TokenAsync(CommaType.Before), ");");
            }
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
            GenerateUtility.RemoveDuplicationFunction(this, code, "EmulateChangeValue");
        }
    }
}
