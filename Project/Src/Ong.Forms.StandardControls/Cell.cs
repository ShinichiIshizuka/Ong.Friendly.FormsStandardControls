using System;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides information about a table cell.
    /// </summary>
#else
    /// <summary>
    /// セル情報です。
    /// </summary>
#endif
    [Serializable]
    public class Cell
    {
        int _col;
        int _row;

#if ENG
        /// <summary>
        /// Returns the cell's column number.
        /// </summary>
#else
        /// <summary>
        /// 列です。
        /// </summary>
#endif
        public int Col { get { return _col; } set { _col = value; } }

#if ENG
        /// <summary>
        /// Returns the cell's row number.
        /// </summary>
#else
        /// <summary>
        /// 行です。
        /// </summary>
#endif
        public int Row { get { return _row; } set { _row = value; } }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
#endif
        public Cell() { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="col">Column number.</param>
        /// <param name="row">Row number.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="col">行。</param>
        /// <param name="row">列。</param>
#endif
        public Cell(int col, int row)
        {
            _col = col;
            _row = row;
        }

#if ENG
        /// <summary>
        /// Determines whether this is equal to another object.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns>Comparison result.</returns>
#else
        /// <summary>
        /// 等価比較。
        /// </summary>
        /// <param name="obj">オブジェクト。</param>
        /// <returns>比較結果。</returns>
#endif
        public override bool Equals(object obj)
        {
            Cell target = obj as Cell;
            if (target == null)
            {
                return false;
            }
            return (_col == target._col) && (_row == target._row);
        }

#if ENG
        /// <summary>
        /// Returns a hash code for this cell.
        /// </summary>
        /// <returns>The hash code.</returns>
#else
        /// <summary>
        /// ハッシュコード取得。
        /// </summary>
        /// <returns>ハッシュコード。</returns>
#endif
        public override int GetHashCode()
        {
            return _col + _row;
        }
    }
}
