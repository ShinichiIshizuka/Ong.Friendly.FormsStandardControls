using System;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// 行選択情報です。
    /// </summary>
    [Serializable]
    public class RowSelectedInfo
    {
        int _row;
        bool _selected;

        /// <summary>
        /// 行です。
        /// </summary>
        public int Row { get { return _row; } set { _row = value; } }

        /// <summary>
        /// 選択状態を取得／設定します。
        /// </summary>
        public bool Selected { get { return _selected; } set { _selected = value; } }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        public RowSelectedInfo() { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="row">列</param>
        /// <param name="selected">選択状態</param>
        public RowSelectedInfo(int row, bool selected)
        {
            _row = row;
            _selected = selected;
        }
    }
}
