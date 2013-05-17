using System;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// セル選択情報
    /// </summary>
    [Serializable]
    public class CellSelectedInfo
    {
        int _col;
        int _row;
        bool _selected;

        /// <summary>
        /// 列
        /// </summary>
        public int Col { get { return _col; } set { _col = value; } }

        /// <summary>
        /// 行
        /// </summary>
        public int Row { get { return _row; } set { _row = value; } }

        /// <summary>
        /// 選択状態であるか
        /// </summary>
        public bool Selected { get { return _selected; } set { _selected = value; } }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="col">行</param>
        /// <param name="row">列</param>
        /// <param name="selected">選択状態であるか</param>
        public CellSelectedInfo(int col, int row, bool selected)
        {
            _col = col;
            _row = row;
            _selected = selected;
        }
    }
}
