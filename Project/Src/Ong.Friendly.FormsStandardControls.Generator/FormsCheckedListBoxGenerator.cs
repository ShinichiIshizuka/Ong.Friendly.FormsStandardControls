using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsCheckedListBox.
    /// </summary>
#else
    /// <summary>
    /// FormsCheckedListBoxの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsCheckedListBox")]
    public class FormsCheckedListBoxGenerator : CaptureCodeGeneratorBase
    {
        CheckedListBox _control;

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
            _control = (CheckedListBox)ControlObject;
            _control.ItemCheck += ItemCheck;
            _control.SelectedIndexChanged += SelectedIndexChanged;
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
            _control.ItemCheck -= ItemCheck;
            _control.SelectedIndexChanged -= SelectedIndexChanged;
        }

        /// <summary>
        /// Convert from parent client coordinates to child client coordinates.
        /// </summary>
        /// <param name="clientPoint">Client coordinates.Convert to child client coordinates.</param>
        /// <param name="childUIObject">A child object that is the origin of client coordinates. If not, set null or empty character.</param>
        /// <returns>Returns true if converted to child client coordinates.</returns>
        public override bool ConvertChildClientPoint(ref Point clientPoint, out string childUIObject)
        {
            childUIObject = string.Empty;
            var index = _control.IndexFromPoint(clientPoint);
            if (index == -1) return false;

            childUIObject = $".GetItem({index})";
            var rect = _control.GetItemRectangle(index);
            clientPoint = new Point(clientPoint.X - rect.X, clientPoint.Y - rect.Y);
            return true;
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
