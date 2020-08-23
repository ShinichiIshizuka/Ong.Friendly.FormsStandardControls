using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Drawing;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Represtnts a ListBox item.
    /// </summary>
#else
    /// <summary>
    /// リストボックスのアイテムです。
    /// </summary>
#endif
    public class FormsCheckedListBoxItem : IUIObject
    {
        FormsCheckedListBox _parent;
        int _index;

#if ENG
        /// <summary>
        /// Application manipulation object.
        /// </summary>
#else
        /// <summary>
        /// アプリケーション操作クラスです。
        /// </summary>
#endif
        public WindowsAppFriend App => _parent.App;

#if ENG
        /// <summary>
        /// Returns the size of IUIObject.
        /// </summary>
#else
        /// <summary>
        /// IUIObjectのサイズを取得します。
        /// </summary>
#endif
        public Size Size => ((Rectangle)_parent["GetItemRectangle"](_index).Core).Size;

#if ENG
        /// <summary>
        /// Is ListBox's SelectedIndex.
        /// </summary>
#else
        /// <summary>
        /// ListBoxのSelectedIndexのアイテムであるか
        /// </summary>
#endif
        public bool IsSelected => _parent.SelectedItemIndex == _index;

#if ENG
        /// <summary>
        /// Returns the control's check state.
        /// </summary>
#else
        /// <summary>
        /// チェック状態を取得します。
        /// </summary>
#endif
        public CheckState CheckState => _parent.GetCheckState(_index);

        internal FormsCheckedListBoxItem(FormsCheckedListBox parent, int index)
        {
            _parent = parent;
            _index = index;
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
        public void Activate() => _parent.Activate();

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
            var rect = (Rectangle)_parent["GetItemRectangle"](_index).Core;
            var screen = _parent.PointToScreen(clientPoint);
            return new Point(screen.X + rect.X, screen.Y + rect.Y);
        }

#if ENG
        /// <summary>
        /// I want to select an item state corresponding to the specified index.
        /// </summary>
#else
        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// </summary>
#endif
        public void EmulateSelect()
            => _parent.EmulateChangeSelectedIndex(_index);

#if ENG
        /// <summary>
        /// I want to select an item state corresponding to the specified index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// 非同期に実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateSelect(Async async)
            => _parent.EmulateChangeSelectedIndex(_index, async);

#if ENG
        /// <summary>
        /// Sets the check state of a certain item.
        /// </summary>
        /// <param name="value">Check state.</param>
#else
        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="value">チェック状態。</param>
#endif
        public void EmulateCheckState(CheckState value)
            => _parent.EmulateCheckState(_index, value);

#if ENG
        /// <summary>
        /// Sets the check state of a certain item.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="value">Check state.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// チェック状態を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="value">チェック状態。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateCheckState(CheckState value, Async async)
            => _parent.EmulateCheckState(_index, value, async);
    }
}
