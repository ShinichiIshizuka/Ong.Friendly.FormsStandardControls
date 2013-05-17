using System;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// 行選択情報
    /// </summary>
    [Serializable]
    public class RowSelectedInfo
    {
        int _row;
        bool _selected;

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
        /// <param name="row">列</param>
        /// <param name="selected">選択状態であるか</param>
        public RowSelectedInfo(int row, bool selected)
        {
            _row = row;
            _selected = selected;
        }
    }
}
