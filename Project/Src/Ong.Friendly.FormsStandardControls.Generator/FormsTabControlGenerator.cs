using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsTabControlGenerator : GeneratorBase
    {
        TabControl _control;

        /// <summary>
        /// アタッチ。
        /// </summary>
        protected override void Attach()
        {
            _control = (TabControl)ControlObject;
            _control.SelectedIndexChanged += SelectedIndexChanged;
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
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
