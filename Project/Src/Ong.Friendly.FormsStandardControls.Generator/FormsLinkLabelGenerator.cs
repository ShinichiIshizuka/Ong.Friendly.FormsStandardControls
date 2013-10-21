using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsLinkLabelGenerator :GeneratorBase
    {
        LinkLabel _control;

        /// <summary>
        /// アタッチ。
        /// </summary>
        protected override void Attach()
        {
            _control = (LinkLabel)ControlObject;
            _control.LinkClicked += LinkLabelClicked;
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
        protected override void Detach()
        {
            _control.LinkClicked -= LinkLabelClicked;
        }

        /// <summary>
        /// リンククリック
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void LinkLabelClicked(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                AddSentence(new TokenName(), ".EmulateLinkClick(", new TokenAsync(CommaType.Non), ");");
            }
        }
    }
}
