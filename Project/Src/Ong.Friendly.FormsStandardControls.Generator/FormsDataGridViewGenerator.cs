using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Text;
using System.Globalization;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsDataGridViewGenerator : GeneratorBase
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

        /// <summary>
        /// アタッチ。
        /// </summary>
        /// <param name="windowHandle">ウィンドウハンドル(WPFオブジェクトの場合はIntPtr.Zero)。</param>
        /// <param name="controlObject">コントロールのオブジェクト(ネイティブウィンドウの場合はnull)。</param>
        public override void Attach(IntPtr windowHandle, object controlObject)
        {
            _control = (DataGridView)controlObject;
            _control.SelectionChanged += SelectionChanged;
            _control.CellEndEdit += CellEndEdit;
            _control.CellContentClick += CellContentClick;
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
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
                AddSentence(new TokenName(), ".EmulateClickCellContent(" + e.ColumnIndex + "," + e.RowIndex, new TokenAsync(CommaType.Before) + ");");
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
                AddSentence(new TokenName(), ".EmulateChangeCellText(" + e.ColumnIndex + "," + e.RowIndex + ", " + value, new TokenAsync(CommaType.Before) + ");");
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
                    AddSentence(new TokenName(), ".EmulateChangeCellComboSelect(" + e.ColumnIndex + "," + e.RowIndex + ", " + index, new TokenAsync(CommaType.Before) + ");");
                }
                return;
            }
            DataGridViewCheckBoxCell checkBox = _control[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell;
            if (checkBox != null)
            {
                object obj = _control[e.ColumnIndex, e.RowIndex].Value;
                bool value = (obj != null && obj is bool) ? (bool)obj : false;
                AddSentence(new TokenName(), ".EmulateCellCheck(" +
                    e.ColumnIndex + "," + e.RowIndex + ", " + value.ToString(CultureInfo.CurrentCulture).ToLower(CultureInfo.CurrentCulture),
                    new TokenAsync(CommaType.Before) + ");");
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
                AddSentence(new TokenName(), ".EmulateClearSelection(", new TokenAsync(CommaType.Non), ");");
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
            AddSentence(new TokenName(), ".EmulateChangeCellSelected(", new TokenAsync(CommaType.After) ,args + ");");
        }

        /// <summary>
        /// 選択インデックス
        /// </summary>
        /// <param name="selectedIndices">選択インデックス</param>
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
        /// コードの最適化。
        /// </summary>
        /// <param name="list">コードリスト。</param>
        public override void Optimize(List<Sentence> code)
        {
            GenerateUtility.RemoveDuplicationFunction(this, code, "EmulateChangeCurrentCell");
        }
    }
}
