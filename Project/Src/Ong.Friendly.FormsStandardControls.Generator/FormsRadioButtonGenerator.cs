using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsRadioButton.
    /// </summary>
#else
    /// <summary>
    /// FormsRadioButtonの操作コードを生成します。
    /// </summary>
#endif
    [Generator("Ong.Friendly.FormsStandardControls.FormsRadioButton")]
    public class FormsRadioButtonGenerator : GeneratorBase
    {
        RadioButton _control;

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
            _control = (RadioButton)ControlObject;
            _control.CheckedChanged += CheckedChanged;
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
