using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsNumericUpDownGenerator : GeneratorBase
    {
        NumericUpDown _control;

        /// <summary>
        /// アタッチ。
        /// </summary>
        protected override void Attach()
        {
            _control = (NumericUpDown)ControlObject;
            _control.TextChanged += TextChanged;
            _control.ValueChanged += ValueChanged;
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
        protected override void Detach()
        {
            _control.TextChanged += TextChanged;
            _control.ValueChanged += ValueChanged;
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

        /// <summary>
        /// コードの最適化。
        /// </summary>
        /// <param name="list">コードリスト。</param>
        public override void Optimize(List<Sentence> code)
        {
            GenerateUtility.RemoveDuplicationFunction(this, code, "EmulateChangeValue");
        }
    }
}
