﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Text;
using System.Globalization;
using System.Drawing;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsDataGridView.
    /// </summary>
#else
    /// <summary>
    /// FormsDataGridViewの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsDataGridView")]
    public class FormsDataGridViewGenerator : CaptureCodeGeneratorBase
    {
        /// <summary>
        /// 列行情報
        /// </summary>
        class ColRow
        {
            int _col;
            int _row;
            
            /// <summary>
            /// 列
            /// </summary>
            public int Col { get { return _col; } set { _col = value; } }
            
            /// <summary>
            /// 行
            /// </summary>
            public int Row { get { return _row; } set { _row = value; } }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="col">列</param>
            /// <param name="row">行</param>
            public ColRow(int col, int row)
            {
                _col = col;
                _row = row;
            }

            /// <summary>
            /// 等価比較
            /// </summary>
            /// <param name="obj">オブジェクト</param>
            /// <returns>比較結果</returns>
            public override bool Equals(object obj)
            {
                ColRow target = obj as ColRow;
                if (target == null)
                {
                    return false;
                }
                return _col == target.Col && _row == target.Row;
            }

            /// <summary>
            /// ハッシュコード取得
            /// </summary>
            /// <returns>ハッシュコード</returns>
            public override int GetHashCode()
            {
                return _col + _row;
            }
        }

        DataGridView _control;

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
            _control = (DataGridView)ControlObject;
            _control.SelectionChanged += SelectionChanged;
            _control.CellEndEdit += CellEndEdit;
            _control.CellContentClick += CellContentClick;
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
            _control.SelectionChanged -= SelectionChanged;
            _control.CellEndEdit -= CellEndEdit;
            _control.CellContentClick -= CellContentClick;
        }

        /// <summary>
        /// セルコンテントのクリック
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((_control[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell) ||
                (_control[e.ColumnIndex, e.RowIndex] is DataGridViewLinkCell))
            {
                AddSentence(new TokenName(), ".EmulateClickCellContent(" + e.ColumnIndex + ", " + e.RowIndex, new TokenAsync(CommaType.Before), ");");
            }
        }

        /// <summary>
        /// セル編集イベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell textBox = _control[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
            if (textBox != null)
            {
                object obj = _control[e.ColumnIndex, e.RowIndex].Value;
                string value = (obj == null) ? string.Empty : obj.ToString();
                AddSentence(new TokenName(), ".EmulateChangeCellText(" + e.ColumnIndex + ", " + e.RowIndex + ", " +
                    GenerateUtility.AdjustText(value), new TokenAsync(CommaType.Before), ");");
                return;
            }
            DataGridViewComboBoxCell comboBox = _control[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
            if (comboBox != null)
            {
                object obj = _control[e.ColumnIndex, e.RowIndex].Value;
                string value = (obj == null) ? string.Empty : obj.ToString();
                int index = -1;
                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    string item = (comboBox.Items[i] == null) ? string.Empty : comboBox.Items[i].ToString();
                    if (item == value)
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                {
                    AddSentence(new TokenName(), ".EmulateChangeCellComboSelect(" + e.ColumnIndex + ", " + e.RowIndex + ", " + index, new TokenAsync(CommaType.Before), ");");
                }
                return;
            }
            DataGridViewCheckBoxCell checkBox = _control[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell;
            if (checkBox != null)
            {
                object obj = _control[e.ColumnIndex, e.RowIndex].Value;
                bool value = (obj != null && obj is bool) ? (bool)obj : false;
                AddSentence(new TokenName(), ".EmulateCellCheck(" +
                    e.ColumnIndex + ", " + e.RowIndex + ", " + value.ToString(CultureInfo.CurrentCulture).ToLower(CultureInfo.CurrentCulture),
                    new TokenAsync(CommaType.Before), ");");
                return;
            }
        }

        /// <summary>
        /// 選択インデックスが変化した
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void SelectionChanged(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                //現在のセルの設定
                if (_control.CurrentCell != null)
                {
                    AddSentence(new TokenName(), ".EmulateChangeCurrentCell(" +
                        _control.CurrentCell.ColumnIndex + ", " + _control.CurrentCell.RowIndex, new TokenAsync(CommaType.Before), ");");
                }

                //行選択
                List<int> currentRows = new List<int>();
                GetSelectedRows(currentRows);
                SelectRows(currentRows);

                //セル選択
                if (_control.MultiSelect)
                {
                    List<ColRow> currentCells = new List<ColRow>();
                    GetSelectedIndices(currentCells);
                    bool isSelectCell = false;
                    foreach (ColRow element in currentCells)
                    {
                        if (currentRows.IndexOf(element.Row) == -1)
                        {
                            isSelectCell = true;
                            break;
                        }
                    }
                    if (_control.CurrentCell != null && currentCells.Count == 1 &&
                        _control.CurrentCell.RowIndex == currentCells[0].Row &&
                        _control.CurrentCell.ColumnIndex == currentCells[0].Col)
                    {
                        isSelectCell = false;
                    }
                    if (isSelectCell)
                    {
                        SelectCells(currentCells);
                    }
                }
           }
        }

        /// <summary>
        /// セル選択
        /// </summary>
        /// <param name="current">現在状態</param>
        private void SelectCells(List<ColRow> current)
        {
            StringBuilder args = new StringBuilder();
            foreach (ColRow index in current)
            {
                if (0 < args.Length)
                {
                    args.Append(", ");
                }
                args.Append("new CellSelectedInfo(" + index.Col + ", " + index.Row + ", true)");
            }
            if (args.Length == 0)
            {
                return;
            }
            AddSentence(new TokenName(), ".EmulateChangeCellSelected(", new TokenAsync(CommaType.After), args + ");");
        }

        /// <summary>
        /// 選択インデックス
        /// </summary>
        /// <param name="list">選択インデックス</param>
        private void GetSelectedIndices(List<ColRow> list)
        {
            list.Clear();
            int col = _control.CurrentCell.ColumnIndex;
            int row = _control.CurrentCell.RowIndex;
            foreach (DataGridViewCell cell in _control.SelectedCells)
            {
                list.Add(new ColRow(cell.ColumnIndex, cell.RowIndex));
            }
        }

        /// <summary>
        /// 行選択
        /// </summary>
        /// <param name="current">現在状態</param>
        private void SelectRows(List<int> current)
        {
            StringBuilder args = new StringBuilder();
            foreach (int index in current)
            {
                if (0 < args.Length)
                {
                    args.Append(", ");
                }
                args.Append("new RowSelectedInfo(" + index + ", true)");
            }
            if (args.Length == 0)
            {
                return;
            }
            AddSentence(new TokenName(), ".EmulateChangeRowSelected(", new TokenAsync(CommaType.After), args + ");");
        }

        /// <summary>
        /// 選択行インデックス取得
        /// </summary>
        /// <param name="selectedRows">選択行インデックス</param>
        private void GetSelectedRows(List<int> selectedRows)
        {
            selectedRows.Clear();
            foreach (DataGridViewRow sel in _control.SelectedRows)
            {
                selectedRows.Add(sel.Index);
            }
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
            if (info.RowIndex < 0 || _control.RowCount <= info.RowIndex) return false;
            if (info.ColumnIndex < 0 || _control.ColumnCount <= info.ColumnIndex) return false;

            childUIObject = $".GetCell({info.ColumnIndex}, {info.RowIndex})";

            var rc = _control.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
            clientPoint = new Point(clientPoint.X - rc.X, clientPoint.Y - rc.Y);
            return true;
        }
    }
}
