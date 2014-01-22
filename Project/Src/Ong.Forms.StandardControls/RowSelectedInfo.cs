using System;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// TContains information about row selection.
    /// </summary>
#else
    /// <summary>
    /// 行選択情報です。
    /// </summary>
#endif
    [Serializable]
    public class RowSelectedInfo
    {
        int _row;
        bool _selected;

#if ENG
        /// <summary>
        /// Gets or sets the row number.
        /// </summary>
#else
        /// <summary>
        /// 行です。
        /// </summary>
#endif
        public int Row { get { return _row; } set { _row = value; } }

#if ENG
        /// <summary>
        /// Gets or sets the selection state.
        /// </summary>
#else
        /// <summary>
        /// 選択状態を取得／設定します。
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
        public RowSelectedInfo() { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="row">Row number.</param>
        /// <param name="selected">Selection state.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="row">列</param>
        /// <param name="selected">選択状態</param>
#endif
        public RowSelectedInfo(int row, bool selected)
        {
            _row = row;
            _selected = selected;
        }
    }
}
