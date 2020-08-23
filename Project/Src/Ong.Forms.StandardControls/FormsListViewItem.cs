using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls.Properties;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Drawing;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Represtnts a list item.
    /// </summary>
#else
    /// <summary>
    /// リストアイテムです。
    /// </summary>
#endif
    public class FormsListViewItem : AppVarWrapper, IUIObject
    {
#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsListViewItem(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsListViewItem(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsListViewItem(AppVar windowObject).", false)]
        public FormsListViewItem(WindowsAppFriend app, AppVar appVar)
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
        public FormsListViewItem(AppVar appVar)
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
        /// Returns the item's text.
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
        /// Returns the item's index.
        /// </summary>
#else
        /// <summary>
        /// アイテムインデックスを取得します。
        /// </summary>
#endif
        public int ItemIndex
        {
            get { return (int)this["Index"]().Core; }
        }

#if ENG
        /// <summary>
        /// Returns the item's check state.
        /// </summary>
#else
        /// <summary>
        /// チェック状態を取得します。
        /// </summary>
#endif
        public bool Checked
        {
            get { return (bool)this["Checked"]().Core; }
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
            var screen = (Point)AppVar["ListView"]()["PointToScreen"](clientPoint).Core;
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
            var w = new WindowControl(AppVar["ListView"]());
            w.Activate();
        }

#if ENG
        /// <summary>
        /// Retrieves a sub item.
        /// </summary>
        /// <param name="subitemindex">Index of the sub-item to retrieve.</param>
        /// <returns>The indicated item.</returns>
#else
        /// <summary>
        /// サブアイテムを取得します。
        /// </summary>
        /// <param name="subitemindex">サブアイテムインデックス。</param>
        /// <returns>サブアイテム。</returns>
#endif
        public FormsListViewSubItem GetSubItem(int subitemindex)
        {
            return new FormsListViewSubItem(App[typeof(FormsListViewItem), "GetSubItemInTarget"](AppVar, subitemindex));
        }

#if ENG
        /// <summary>
        /// Sets the item's checked state.
        /// </summary>
        /// <param name="value">Check state to use.</param>
#else
        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="value">チェック状態。</param>
#endif
        public void EmulateCheck(bool value)
        {
            App[typeof(FormsListViewItem), "EmulateCheckInTarget"](AppVar, value);
        }

#if ENG
        /// <summary>
        /// Sets the item's checked state.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="value">Check state to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// チェック状態を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="value">チェック状態。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateCheck(bool value, Async async)
        {
            App[typeof(FormsListViewItem), "EmulateCheckInTarget", async](AppVar, value);
        }

#if ENG
        /// <summary>
        /// Sets the item's text.
        /// </summary>
        /// <param name="text">Text to use.</param>
#else
        /// <summary>
        /// テキストを編集します。
        /// </summary>
        /// <param name="text">テキスト。</param>
#endif
        public void EmulateEditLabel(string text)
        {
            App[typeof(FormsListViewItem), "EmulateEditLabelInTarget"](AppVar, text);
        }

#if ENG
        /// <summary>
        /// Sets the item's text.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="text">Text to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// テキストを編集します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateEditLabel(string text, Async async)
        {
            App[typeof(FormsListViewItem), "EmulateEditLabelInTarget", async](AppVar, text);
        }

        /// <summary>
        /// サブアイテムを取得します(内部)。
        /// </summary>
        /// <param name="listviewitem">リストビューアイテム。</param>
        /// <param name="subitemindex">リストビューサブアイテムインデックス。</param>
        /// <returns>FormsListViewSubItem</returns>
        static ListViewItem.ListViewSubItem GetSubItemInTarget(ListViewItem listviewitem, int subitemindex)
        {
            return listviewitem.SubItems[subitemindex];
        }

        /// <summary>
        /// テキストを編集します。
        /// </summary>
        /// <param name="item">アイテム。</param>
        /// <param name="text">テキスト。</param>
        static void EmulateEditLabelInTarget(ListViewItem item, string text)
        {
            if (item.ListView == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetListView);
            }

            item.ListView.Focus();

            //編集開始
            item.BeginEdit();

            //エディタを探す
            IntPtr edit = IntPtr.Zero;
            EnumWindowsProc proc = delegate(IntPtr hWnd, IntPtr lParam)
            {
                StringBuilder build = new StringBuilder(256 + 8);
                GetClassName(hWnd, build, 256);
                if (build.ToString().ToLower() == "edit")
                {
                    edit = hWnd;
                    return false;
                }
                return true;
            };
            EnumChildWindows(item.ListView.Handle, proc, IntPtr.Zero);
            GC.KeepAlive(proc);

            //テキスト設定
            SetWindowText(edit, text);

            //フォーカスをリストビューに戻し編集完了
            item.ListView.Focus();
        }

        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="item">リストビューアイテム。</param>
        /// <param name="value">チェック状態。</param>
        static void EmulateCheckInTarget(ListViewItem item, bool value)
        {
            if (item.ListView == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetListView);
            }
            item.ListView.Focus();
            item.Checked = value;
        }

        /// <summary>
        /// ウィンドウ検索プロック。
        /// </summary>
        /// <param name="hWnd">ウィンドウハンドル。</param>
        /// <param name="lParam">パラメータ。</param>
        /// <returns>検索を続けるか。</returns>
        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary>
        /// 子ウィンドウ検索。
        /// </summary>
        /// <param name="parent">親ウィンドウハンドル。</param>
        /// <param name="lpEnumFunc">検索プロック。</param>
        /// <param name="lParam">パラメータ。</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumChildWindows(IntPtr parent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// ウィンドウクラス名称取得。
        /// </summary>
        /// <param name="hWnd">ウィンドウハンドル。</param>
        /// <param name="lpClassName">クラス名称格納バッファ。</param>
        /// <param name="nMaxCount">最大数。</param>
        /// <returns>文字数。</returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// テキストの設定。
        /// </summary>
        /// <param name="hWnd">ウィンドウハンドル。</param>
        /// <param name="lpString">テキスト。</param>
        /// <returns>成否。</returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool SetWindowText(IntPtr hWnd, string lpString);
    }
}
