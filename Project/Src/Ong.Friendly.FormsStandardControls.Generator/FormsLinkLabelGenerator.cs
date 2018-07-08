using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsLinkLabel.
    /// </summary>
#else
    /// <summary>
    /// FormsLinkLabelの操作コードを生成します。
    /// </summary>
#endif
    [Generator("Ong.Friendly.FormsStandardControls.FormsLinkLabel")]
    public class FormsLinkLabelGenerator :GeneratorBase
    {
        LinkLabel _control;

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
            _control = (LinkLabel)ControlObject;
            _control.LinkClicked += LinkLabelClicked;
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
