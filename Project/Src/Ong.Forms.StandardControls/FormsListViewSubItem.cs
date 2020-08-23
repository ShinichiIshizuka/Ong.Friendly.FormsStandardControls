using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System;
using System.Drawing;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Represents a sub-item in a list view.
    /// </summary>
#else
    /// <summary>
    /// リストビューサブアイテムです。
    /// </summary>
#endif
    public class FormsListViewSubItem : AppVarWrapper, IUIObject
    {
#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsListViewSubItem(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsListViewSubItem(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsListViewSubItem(AppVar windowObject).", false)]
        public FormsListViewSubItem(WindowsAppFriend app, AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        public FormsListViewSubItem(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the size of IUIObject.
        /// </summary>
#else
        /// <summary>
        /// IUIObjectのサイズを取得します。
        /// </summary>
#endif
        public Size Size => (Size)AppVar["Bounds"]()["Size"]().Core;

#if ENG
        /// <summary>
        /// Returns the sub-item's text.
        /// </summary>
#else
        /// <summary>
        /// テキストを取得します。
        /// </summary>
#endif
        public string Text
        {
            get { return (string)this["Text"]().Core; }
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
            var rect = (Rectangle)AppVar["Bounds"]().Core;
            var screen = (Point)AppVar["owner"]()["ListView"]()["PointToScreen"](clientPoint).Core;
            return new Point(screen.X + rect.X, screen.Y + rect.Y);
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
            var w = new WindowControl(AppVar["owner"]()["ListView"]());
            w.Activate();
        }
    }
}
