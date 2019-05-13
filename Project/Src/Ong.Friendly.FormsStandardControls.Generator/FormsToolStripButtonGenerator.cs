using System;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsToolStripButton.
    /// </summary>
#else
    /// <summary>
    /// FormsToolStripButtonの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsToolStripButton")]
    public class FormsToolStripButtonGenerator : CaptureCodeGeneratorBase
    {
        ToolStripButton _control;

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
            _control = (ToolStripButton)ControlObject;
            _control.Click += ButtonClick;
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
            if (_control == null) return;
            _control.Click -= ButtonClick;
            _control.Click -= CheckedChanged;
        }

        /// <summary>
        /// ボタン押下
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void ButtonClick(object sender, EventArgs e)
        {
            AddSentence(new TokenName(), ".EmulateShow();");
            AddSentence(new TokenName(), ".EmulateClick(", new TokenAsync(CommaType.Non), ");");
        }

        /// <summary>
        /// チェック変更
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void CheckedChanged(object sender, EventArgs e)
        {
            AddSentence(new TokenName(), ".EmulateShow();");
            AddSentence(new TokenName(), ".EmulateCheck(CheckState." + _control.CheckState, new TokenAsync(CommaType.Before), ");");
        }

    }
}
