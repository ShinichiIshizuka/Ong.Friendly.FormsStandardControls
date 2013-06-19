﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsRadioButtonGenerator : GeneratorBase
    {
        RadioButton _control;

        /// <summary>
        /// アタッチ。
        /// </summary>
        /// <param name="windowHandle">ウィンドウハンドル(WPFオブジェクトの場合はIntPtr.Zero)。</param>
        /// <param name="controlObject">コントロールのオブジェクト(ネイティブウィンドウの場合はnull)。</param>
        public override void Attach(IntPtr windowHandle, object controlObject)
        {
            _control = (RadioButton)controlObject;
            _control.CheckedChanged += CheckedChanged;
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
        protected override void Detach()
        {
            _control.CheckedChanged -= CheckedChanged;
        }

        /// <summary>
        /// チェック状態が変わったときのイベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void CheckedChanged(object sender, EventArgs e)
        {
            if (_control.Focused && _control.Checked)
            {
                AddSentence(new TokenName(), ".EmulateCheck();");
            }
        }
    }
}