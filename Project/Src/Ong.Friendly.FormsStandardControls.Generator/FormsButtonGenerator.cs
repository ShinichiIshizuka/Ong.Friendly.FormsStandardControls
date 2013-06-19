using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    //@@@全体的にasync

    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsButtonGenerator : GeneratorBase
    {
        Button _control;

        /// <summary>
        /// アタッチ。
        /// </summary>
        /// <param name="windowHandle">ウィンドウハンドル(WPFオブジェクトの場合はIntPtr.Zero)。</param>
        /// <param name="controlObject">コントロールのオブジェクト(ネイティブウィンドウの場合はnull)。</param>
        public override void Attach(IntPtr windowHandle, object controlObject)
        {
            _control = (Button)controlObject;
            _control.Click += ButtonClick;
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
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
            if (_control.Focused)
            {
                AddSentence(new TokenName(), ".EmulateClick(", new TokenAsync(CommaType.Non), ");");
            }
        }
    }
}
