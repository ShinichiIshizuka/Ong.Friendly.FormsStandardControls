using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsListBox.
    /// </summary>
#else
    /// <summary>
    /// FormsListBoxの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsListBox")]
    public class FormsListBoxGenerator : CaptureCodeGeneratorBase
    {
        ListBox _control;
        List<int> _selectedIndices = new List<int>();

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
            _control = (ListBox)ControlObject;
            _control.SelectedIndexChanged += SelectedIndexChanged;
            GetSelectedIndices(_selectedIndices);
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
        /// 選択インデックスが変化した
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                switch (_control.SelectionMode)
                {
                    case SelectionMode.MultiExtended:
                    case SelectionMode.MultiSimple:
                        {
                            List<int> current = new List<int>();
                            GetSelectedIndices(current);
                            DiffSelect(current, _selectedIndices);
                            _selectedIndices = current;
                        }
                        return;
                }
                AddSentence(new TokenName(), ".EmulateChangeSelectedIndex(" + _control.SelectedIndex, new TokenAsync(CommaType.Before), ");");
            }
        }

        /// <summary>
        /// 差分チェック
        /// </summary>
        /// <param name="current">現在状態</param>
        /// <param name="old">前の選択状態</param>
        private void DiffSelect(List<int> current, List<int> old)
        {
            //oldで選択が消えているものをfalseにする
            foreach (int index in old)
            {
                if (current.IndexOf(index) == -1)
                {
                    AddSentence(new TokenName(), ".EmulateChangeSelectedState(" + index + ", false);");
                }
            }
            //currentで選択が増えているものをtrueにする
            foreach (int index in current)
            {
                if (old.IndexOf(index) == -1)
                {
                    AddSentence(new TokenName(), ".EmulateChangeSelectedState(" + index + ", true);");
                }
            }
        }

        /// <summary>
        /// 選択インデックス
        /// </summary>
        /// <param name="selectedIndices">選択インデックス</param>
        private void GetSelectedIndices(List<int> selectedIndices)
        {
            selectedIndices.Clear();
            foreach (int sel in _control.SelectedIndices)
            {
                selectedIndices.Add(sel);
            }
        }
    }
}
