using System;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.Friendly.Windows;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// リストアイテムです。
    /// </summary>
    public class FormsListViewItem : AppVarWrapper
    {
        AppVar _listView;

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="listView">リストビュー。</param>
        /// <param name="item">アイテム。</param>
        public FormsListViewItem(WindowsAppFriend app, AppVar listView, AppVar item)
            : base(app, item)
        {
            _listView = listView;
        }
    
        /// <summary>
        /// テキストを取得します。
        /// </summary>
        /// <returns>テキスト。</returns>
        public String Text
        {
            get { return (String)this["Text"]().Core; }
        }

        /// <summary>
        /// アイテムインデックスを取得します。
        /// </summary>
        /// <returns>行番号。</returns>
        public int ItemIndex
        {
            get { return (int)this["Index"]().Core; }
        }

        /// <summary>
        /// チェック状態を取得します。
        /// </summary>
        public bool Checked
        {
            get { return (bool)this["Checked"]().Core; }
        }

        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="value">チェック状態。</param>
        public void EmulateCheck(bool value)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, value);
        }

        /// <summary>
        /// チェック状態を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="value">チェック状態。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateCheck(bool value, Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar, value);
        }

        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="listviewitem">リストビューアイテム。</param>
        /// <param name="value">チェック状態。</param>
        static void EmulateCheckInTarget(ListViewItem listviewitem, bool value)
        {
            listviewitem.Checked = value;
        }

        /// <summary>
        /// テキストを編集します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        public void EmulateEditLabel(string text)
        {
            App[GetType(), "EmulateEditLabelInTarget"](_listView, AppVar, text);
        }

        /// <summary>
        /// テキストを編集します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateEditLabel(string text, Async async)
        {
            App[GetType(), "EmulateEditLabelInTarget", async](_listView, AppVar, text);
        }

        /// <summary>
        /// テキストを編集します。
        /// </summary>
        /// <param name="listView">リストビュー。</param>
        /// <param name="item">アイテム。</param>
        /// <param name="text">テキスト。</param>
        static void EmulateEditLabelInTarget(ListView listView, ListViewItem item, string text)
        {
            listView.Focus();

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
            EnumChildWindows(listView.Handle, proc, IntPtr.Zero);
            GC.KeepAlive(proc);

            //テキスト設定
            SetWindowText(edit, text);

            //フォーカスをリストビューに戻し編集完了
            listView.Focus();
        }

        /// <summary>
        /// サブアイテムを取得します。
        /// </summary>
        /// <param name="subitemindex">サブアイテムインデックス。</param>
        /// <returns></returns>
        public FormsListViewSubItem GetSubItem(int subitemindex)
        {
            return new FormsListViewSubItem(App, App[GetType(), "GetSubItemInTarget"](AppVar, subitemindex));
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
        /// ウィンドウ検索プロック。
        /// </summary>
        /// <param name="hWnd">ウィンドウハンドル。</param>
        /// <param name="lParam">パラメータ。</param>
        /// <returns>検索を続けるか。</returns>
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

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
        public static extern bool SetWindowText(IntPtr hWnd, String lpString);
    }
}
