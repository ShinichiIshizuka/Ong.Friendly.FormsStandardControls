using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsTabControl.
    /// </summary>
#else
    /// <summary>
    /// FormsTabControlの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsTabControl")]
    public class FormsTabControlGenerator : CaptureCodeGeneratorBase
    {
        TabControl _control;

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
            _control = (TabControl)ControlObject;
            _control.SelectedIndexChanged += SelectedIndexChanged;
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
            _control.SelectedIndexChanged -= SelectedIndexChanged;
        }

        /// <summary>
        /// 選択インデックスが変わったイベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                AddSentence(new TokenName(), ".EmulateTabSelect(" + _control.SelectedIndex, new TokenAsync(CommaType.Before), ");");
            }
        }
    }
}
