using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Drawing;

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
    public class FormsListBoxItem : IUIObject
    {
        FormsListBox _parent;
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
        public bool IsSelected => _parent.SelectedIndex == _index;

#if ENG
        /// <summary>
        /// Text.
        /// </summary>
#else
        /// <summary>
        /// テキスト
        /// </summary>
#endif
        public string Text => _parent.GetItemText(_index);

        internal FormsListBoxItem(FormsListBox parent, int index)
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
        /// I want to select an item state corresponding to the specified index.
        /// </summary>
        /// <param name="isSelect">Set true to the selected state.</param>
#else
        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// </summary>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
#endif
        public void EmulateChangeSelectedState(bool isSelect)
            => _parent.EmulateChangeSelectedState(_index, isSelect);

#if ENG
        /// <summary>
        /// I want to select an item state corresponding to the specified index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="isSelect">Set true to the selected state.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// 非同期に実行します。
        /// </summary>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
        /// <param name="async">非同期オブジェクト</param>
#endif
        public void EmulateChangeSelectedState(bool isSelect, Async async)
            => _parent.EmulateChangeSelectedState(_index, isSelect, async);
    }
}
