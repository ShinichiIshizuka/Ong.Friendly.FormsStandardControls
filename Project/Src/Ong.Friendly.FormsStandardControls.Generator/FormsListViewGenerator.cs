using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Globalization;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsListViewGenerator : GeneratorBase
    {
        ListView _control;
        List<int> _selectedIndices = new List<int>();

        /// <summary>
        /// アタッチ。
        /// </summary>
        protected override void Attach()
        {
            _control = (ListView)ControlObject;
            _control.ItemCheck += ItemCheck;
            _control.SelectedIndexChanged += SelectedIndexChanged;
            _control.AfterLabelEdit += AfterLabelEdit;
            GetSelectedIndices(_selectedIndices);
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
        protected override void Detach()
        {
            _control.ItemCheck -= ItemCheck;
            _control.SelectedIndexChanged -= SelectedIndexChanged;
            _control.AfterLabelEdit -= AfterLabelEdit;
        }

        /// <summary>
        /// ラベルが編集された。
        /// </summary>
        /// <param name="sender">イベント送信元。</param>
        /// <param name="e">イベント内容。</param>
        void AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            AddSentence(new TokenName(),
                    ".GetListViewItem(" + e.Item + ").EmulateEditLabel(" + GenerateUtility.AdjustText(e.Label), 
                    new TokenAsync(CommaType.Before), ");");
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
                List<int> current = new List<int>();
                GetSelectedIndices(current);
                DiffSelect(current, _selectedIndices);
                _selectedIndices = current;
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
                AddSentence(new TokenName(), 
                    ".GetListViewItem(" + e.Index + ").EmulateCheck(" +
                    (e.NewValue == CheckState.Checked).ToString(CultureInfo.CurrentCulture).ToLower(CultureInfo.CurrentCulture), 
                    new TokenAsync(CommaType.Before), ");");
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
    }
}
