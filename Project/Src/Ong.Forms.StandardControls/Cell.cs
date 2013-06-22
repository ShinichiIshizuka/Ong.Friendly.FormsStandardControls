using System;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// セル情報です。
    /// </summary>
    [Serializable]
    public class Cell
    {
        int _col;
        int _row;

        /// <summary>
        /// 列です。
        /// </summary>
        public int Col { get { return _col; } set { _col = value; } }

        /// <summary>
        /// 行です。
        /// </summary>
        public int Row { get { return _row; } set { _row = value; } }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="col">行。</param>
        /// <param name="row">列。</param>
        public Cell(int col, int row)
        {
            _col = col;
            _row = row;
        }
    }
}
