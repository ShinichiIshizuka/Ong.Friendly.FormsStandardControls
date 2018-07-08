using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsComboBox.
    /// </summary>
#else
    /// <summary>
    /// FormsComboBoxの操作コードを生成します。
    /// </summary>
#endif
    [Generator("Ong.Friendly.FormsStandardControls.FormsComboBox")]
    public class FormsComboBoxGenerator : GeneratorBase
    {
        ComboBox _control;

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
            _control = (ComboBox)ControlObject;
            _control.TextChanged += ComboBoxTextChanged;
            _control.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
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
            _control.TextChanged -= ComboBoxTextChanged;
            _control.SelectedIndexChanged -= ComboBoxSelectedIndexChanged;
        }

        /// <summary>
        /// 選択インデックス変更
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                AddSentence(new TokenName(), ".EmulateChangeSelect(" + _control.SelectedIndex, new TokenAsync(CommaType.Before), ");");
            }
        }

        /// <summary>
        /// テキスト変化イベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void ComboBoxTextChanged(object sender, EventArgs e)
        {
            if (_control.Focused && _control.DropDownStyle != ComboBoxStyle.DropDownList)
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
