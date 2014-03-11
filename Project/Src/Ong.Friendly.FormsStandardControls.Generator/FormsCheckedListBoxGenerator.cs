using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsCheckedListBoxGenerator : GeneratorBase
    {
        CheckedListBox _control;

        /// <summary>
        /// アタッチ。
        /// </summary>
        protected override void Attach()
        {
            _control = (CheckedListBox)ControlObject;
            _control.ItemCheck += ItemCheck;
            _control.SelectedIndexChanged += SelectedIndexChanged;
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
        protected override void Detach()
        {
            _control.ItemCheck -= ItemCheck;
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
                AddSentence(new TokenName(), ".EmulateChangeSelectedIndex(" + _control.SelectedIndex, new TokenAsync(CommaType.Before), ");");
            }
        }

        /// <summary>
        /// チェック状態変更
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_control.Focused)
            {
                AddSentence(new TokenName(), ".EmulateCheckState(" + e.Index + ", CheckState." + e.NewValue, new TokenAsync(CommaType.Before), ");");
            }
        }
    }
}
