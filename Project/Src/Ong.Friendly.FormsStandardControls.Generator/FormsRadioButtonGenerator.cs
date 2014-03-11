using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsRadioButtonGenerator : GeneratorBase
    {
        RadioButton _control;

        /// <summary>
        /// アタッチ。
        /// </summary>
        protected override void Attach()
        {
            _control = (RadioButton)ControlObject;
            _control.CheckedChanged += CheckedChanged;
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
        protected override void Detach()
        {
            _control.CheckedChanged -= CheckedChanged;
        }

        /// <summary>
        /// チェック状態が変わったときのイベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void CheckedChanged(object sender, EventArgs e)
        {
            if (_control.Focused && _control.Checked)
            {
                AddSentence(new TokenName(), ".EmulateCheck(", new TokenAsync(CommaType.Non), ");");
            }
        }
    }
}
