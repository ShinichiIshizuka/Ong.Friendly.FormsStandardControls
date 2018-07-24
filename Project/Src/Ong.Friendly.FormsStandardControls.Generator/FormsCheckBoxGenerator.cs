using System;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsCheckBox.
    /// </summary>
#else
    /// <summary>
    /// FormsCheckBoxの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsCheckBox")]
    public class FormsCheckBoxGenerator : CaptureCodeGeneratorBase
    {
        CheckBox _control;

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
            _control = (CheckBox)ControlObject;
            _control.CheckStateChanged += CheckStateChanged;
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
            _control.CheckStateChanged -= CheckStateChanged;
        }

        /// <summary>
        /// チェック状態が変わったときのイベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void CheckStateChanged(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                AddSentence(new TokenName(), ".EmulateCheck(CheckState." + _control.CheckState, new TokenAsync(CommaType.Before), ");");
            }
        }
    }
}
