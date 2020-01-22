using Codeer.Friendly;
using Codeer.Friendly.Windows.Grasp;
using System.Drawing;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on DataGridViewCell.
    /// </summary>
#else
    /// <summary>
    /// セルです。
    /// </summary>
#endif
    public class FormsDataGridViewCell : AppVarWrapper, IUIObject
    {
        FormsDataGridView _grid;

#if ENG
        /// <summary>
        /// Returns the cell's column number.
        /// </summary>
#else
        /// <summary>
        /// 列です。
        /// </summary>
#endif
        public int Col { get; }

#if ENG
        /// <summary>
        /// Returns the cell's row number.
        /// </summary>
#else
        /// <summary>
        /// 行です。
        /// </summary>
#endif
        public int Row { get; }

#if ENG
        /// <summary>
        /// Returns the node's text.
        /// </summary>
#else
        /// <summary>
        /// テキストを取得します。
        /// </summary>
#endif
        public string Text => _grid.GetText(Col, Row);

#if ENG
        /// <summary>
        /// Returns the size of IUIObject.
        /// </summary>
#else
        /// <summary>
        /// IUIObjectのサイズを取得します。
        /// </summary>
#endif
        public Size Size => ((Rectangle)_grid["GetCellDisplayRectangle"](Col, Row, true).Core).Size;

        internal FormsDataGridViewCell(FormsDataGridView grid, AppVar appVar) : base(appVar)
        {
            _grid = grid;
            Row = (int)appVar["RowIndex"]().Core;
            Col = (int)appVar["ColumnIndex"]().Core;
        }

#if ENG
        /// <summary>
        /// Convert IUIObject's client coordinates to screen coordinates.
        /// </summary>
        /// <param name="clientPoint">client coordinates.</param>
        /// <returns>screen coordinates.</returns>
#else
        /// <summary>
        /// IUIObjectのクライアント座標からスクリーン座標に変換します。
        /// </summary>
        /// <param name="clientPoint">クライアント座標</param>
        /// <returns>スクリーン座標</returns>
#endif
        public Point PointToScreen(Point clientPoint)
        {
            var rc = (Rectangle)_grid["GetCellDisplayRectangle"](Col, Row, true).Core;
            var screen = (Point)_grid["PointToScreen"](clientPoint).Core;
            return new Point(rc.X + screen.X, rc.Y + screen.Y);
        }

#if ENG
        /// <summary>
        /// Make it active.
        /// </summary>
#else
        /// <summary>
        /// アクティブな状態にします。
        /// </summary>
#endif
        public void Activate()
        {
            _grid.Activate();
            _grid.EmulateChangeCurrentCell(Col, Row);
        }
    }
}
