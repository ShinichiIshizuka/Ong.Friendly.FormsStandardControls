using System;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Contains information about cell selection.
    /// </summary>
#else
    /// <summary>
    /// セル選択情報です。
    /// </summary>
#endif
    [Serializable]
    public class CellSelectedInfo
    {
        int _col;
        int _row;
        bool _selected;

#if ENG
        /// <summary>
        /// Returns the column number.
        /// </summary>
#else
        /// <summary>
        /// 列です。
        /// </summary>
#endif
        public int Col { get { return _col; } set { _col = value; } }

#if ENG
        /// <summary>
        /// Returns the row number.
        /// </summary>
#else
        /// <summary>
        /// 行です。
        /// </summary>
#endif
        public int Row { get { return _row; } set { _row = value; } }

#if ENG
        /// <summary>
        /// Returns the selection state.
        /// </summary>
#else
        /// <summary>
        /// 選択状態を取得します。
        /// </summary>
#endif
        public bool Selected { get { return _selected; } set { _selected = value; } }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
#endif
        public CellSelectedInfo() { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="col">Column number.</param>
        /// <param name="row">Row number.</param>
        /// <param name="selected">Selection state.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="col">行。</param>
        /// <param name="row">列。</param>
        /// <param name="selected">選択状態。</param>
#endif
        public CellSelectedInfo(int col, int row, bool selected)
        {
            _col = col;
            _row = row;
            _selected = selected;
        }
    }
}
