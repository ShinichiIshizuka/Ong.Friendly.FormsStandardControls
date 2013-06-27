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
        public Cell() { }

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

        /// <summary>
        /// 等価比較。
        /// </summary>
        /// <param name="obj">オブジェクト。</param>
        /// <returns>比較結果。</returns>
        public override bool Equals(object obj)
        {
            Cell target = obj as Cell;
            if (target == null)
            {
                return false;
            }
            return (_col == target._col) && (_row == target._row);
        }

        /// <summary>
        /// ハッシュコード取得。
        /// </summary>
        /// <returns>ハッシュコード。</returns>
        public override int GetHashCode()
        {
            return _col + _row;
        }
    }
}
