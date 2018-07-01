using System;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsButton.
    /// </summary>
#else
    /// <summary>
    /// FormsButtonの操作コードを生成します。
    /// </summary>
#endif
    [Generator("Ong.Friendly.FormsStandardControls.FormsButton")]
    public class FormsButtonGenerator : GeneratorBase
    {
        Button _control;

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
            _control = (Button)ControlObject;
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
