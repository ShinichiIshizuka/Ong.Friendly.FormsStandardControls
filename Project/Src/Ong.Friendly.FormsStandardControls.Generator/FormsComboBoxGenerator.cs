using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コンボボックスのコード生成
    /// </summary>
    public class FormsComboBoxGenerator : GeneratorBase
    {
        ComboBox _control;

        /// <summary>
        /// アタッチ。
        /// </summary>
        protected override void Attach()
        {
            _control = (ComboBox)ControlObject;
            _control.TextChanged += ComboBoxTextChanged;
            _control.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
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
        
        /// <summary>
        /// コードの最適化。
        /// </summary>
        /// <param name="list">コードリスト。</param>
        public override void Optimize(List<Sentence> code)
        {
            GenerateUtility.RemoveDuplicationFunction(this, code, "EmulateChangeText");
        }
    }
}
