using System;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsToolStripItem.
    /// </summary>
#else
    /// <summary>
    /// FormsToolStripItemの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsToolStripItem")]
    public class FormsToolStripItemGenerator : CaptureCodeGeneratorBase
    {
        ToolStripItem _control;

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
            _control = (ToolStripItem)ControlObject;
            _control.Click += ButtonClick;
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
            _control.Click -= ButtonClick;
        }

        /// <summary>
        /// ボタン押下
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void ButtonClick(object sender, EventArgs e)
        {
            AddSentence(new TokenName(), ".EmulateClick(", new TokenAsync(CommaType.Non), ");");
        }
    }
}
