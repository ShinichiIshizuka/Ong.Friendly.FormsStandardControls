﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsTextBox.
    /// </summary>
#else
    /// <summary>
    /// FormsTextBoxの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsTextBox")]
    public class FormsTextBoxGenerator : CaptureCodeGeneratorBase
    {
        TextBox _control;

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
            _control = (TextBox)ControlObject;
            _control.TextChanged += TextChanged;
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
        }

        /// <summary>
        /// テキスト変更
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void TextChanged(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                AddSentence(new TokenName(), ".EmulateChangeText(" + GenerateUtility.AdjustText(_control.Text), new TokenAsync(CommaType.Before), ");");
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
            GenerateUtility.RemoveDuplicationFunction(this, code, "EmulateChangeText");
        }
    }
}
