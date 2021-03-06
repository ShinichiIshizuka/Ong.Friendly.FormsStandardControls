﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Globalization;
using System.Drawing;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsListView.
    /// </summary>
#else
    /// <summary>
    /// FormsListViewの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsListView")]
    public class FormsListViewGenerator : CaptureCodeGeneratorBase
    {
        ListView _control;
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
            _control = (ListView)ControlObject;
            _control.ItemCheck += ItemCheck;
            _control.SelectedIndexChanged += SelectedIndexChanged;
            _control.AfterLabelEdit += AfterLabelEdit;
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
            _control.ItemCheck -= ItemCheck;
            _control.SelectedIndexChanged -= SelectedIndexChanged;
            _control.AfterLabelEdit -= AfterLabelEdit;
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
            var info = _control.HitTest(clientPoint.X, clientPoint.Y);
            if (info == null) return false;
            if (info.Item == null) return false;

            if (info.SubItem != null)
            {
                childUIObject = $".GetListViewItem({info.Item.Index}).GetSubItem({info.Item.SubItems.IndexOf(info.SubItem)})";
                clientPoint = new Point(clientPoint.X - info.SubItem.Bounds.X, clientPoint.Y - info.SubItem.Bounds.Y);
            }
            else
            {
                childUIObject = $".GetListViewItem({info.Item.Index})";
                clientPoint = new Point(clientPoint.X - info.Item.Bounds.X, clientPoint.Y - info.Item.Bounds.Y);
            }
            return true;
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
            if (!_control.Focused) return;

            if (_control.MultiSelect)
            {
                List<int> current = new List<int>();
                GetSelectedIndices(current);
                DiffSelect(current, _selectedIndices);
                _selectedIndices = current;
                return;
            }

            List<int> list = new List<int>();
            for (int itemIndex = 0; itemIndex < _control.Items.Count; itemIndex++)
            {
                if (_control.Items[itemIndex].Selected == true)
                {
                    AddSentence(new TokenName(), ".EmulateChangeSelectedIndex(" + itemIndex, new TokenAsync(CommaType.Before), ");");
                    return;
                }
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
