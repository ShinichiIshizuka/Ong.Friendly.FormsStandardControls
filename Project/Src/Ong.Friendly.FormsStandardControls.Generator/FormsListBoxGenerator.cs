using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsListBoxGenerator : GeneratorBase
    {
        ListBox _control;
        List<int> _selectedIndices = new List<int>();

        /// <summary>
        /// アタッチ。
        /// </summary>
        /// <param name="windowHandle">ウィンドウハンドル(WPFオブジェクトの場合はIntPtr.Zero)。</param>
        /// <param name="controlObject">コントロールのオブジェクト(ネイティブウィンドウの場合はnull)。</param>
        public override void Attach(IntPtr windowHandle, object controlObject)
        {
            _control = (ListBox)controlObject;
            _control.SelectedIndexChanged += SelectedIndexChanged;
            GetSelectedIndices(_selectedIndices);
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
        protected override void Detach()
        {
            _control.SelectedIndexChanged -= SelectedIndexChanged;
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
                        break;
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
                    AddSentence(new TokenName(), ".EmulateChangeSelectedState(" + index + ", false", new TokenAsync(CommaType.Before), ");");
                }
            }
            //currentで選択が増えているものをtrueにする
            foreach (int index in current)
            {
                if (old.IndexOf(index) == -1)
                {
                    AddSentence(new TokenName(), ".EmulateChangeSelectedState(" + index + ", true", new TokenAsync(CommaType.Before), ");");
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

        /// <summary>
        /// コードの最適化。
        /// </summary>
        /// <param name="list">コードリスト。</param>
        public override void Optimize(List<Sentence> code)
        {
            GenerateUtility.RemoveDuplicationFunction(this, code, "EmulateChangeSelectedIndex");
        }
    }
}
