using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがSystem.Windows.Forms.CheckdListBoxのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsCheckedListBox : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
        public FormsCheckedListBox(FormsControlBase src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsCheckedListBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// 一覧のアイテム数を取得します。
        /// </summary>
        public int ItemCount
        {
            get { return (int)(this["Items"]()["Count"]().Core); }
        }

        /// <summary>
        /// 現在選択されているアイテムのインデックスを取得します。
        /// </summary>
        public int SelectedItemIndex
        {
            get { return (int)(this["SelectedIndex"]().Core); }
        }

        /// <summary>
        /// 現在チェックされているアイテムのインデックスを配列で取得します。
        /// </summary>
        public int[] CheckedIndices
        {
            get { return (int[])(App[GetType(), "CheckedIndicsInTarget"](AppVar).Core); }
        }

        /// <summary>
        /// チェック状態を取得します。
        /// </summary>
        /// <returns>チェック状態</returns>
        public CheckState GetCheckState(int index)
        {
            return (CheckState)(this["GetItemCheckState"](index).Core);
        }

        /// <summary>
        /// アイテムを指定されたテキストで検索します。
        /// </summary>
        /// <param name="ItemText">各ノードのテキスト。</param>
        /// <returns>検索されたノードのアイテムハンドル。未発見時はnullが返ります。</returns>
        public int FindListIndex(string ItemText)
        {
            return (int)(this["FindString"](ItemText).Core);
        }

        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="value">チェック状態。</param>
        public void EmulateCheckState(int index, CheckState value)
        {
            this["Focus"]();
            this["SetItemCheckState"](index, value);
        }

        /// <summary>
        /// チェック状態を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="value">チェック状態。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateCheckState(int index ,CheckState value, Async async)
        {
            this["Focus", new Async()]();
            this["SetItemCheckState", async](index, value);
        }

        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// </summary>
        public void EmulateChangeSelectedIndex(int Index)
        {
            this["Focus"]();
            this["SelectedIndex"](Index);
        }

        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// 非同期に実行します。
        /// </summary>
        /// <param name="Index">インデックス。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateChangeSelectedIndex(int Index, Async async)
        {
            this["Focus", new Async()]();
            this["SelectedIndex", async](Index);
        }

        /// <summary>
        /// 現在チェックされているアイテムのインデックスを配列で取得します(内部)。
        /// </summary>
        /// <param name="checkedListBox">対象のチェックリストボックス。</param>
        /// <returns></returns>
        private static int[] CheckedIndicsInTarget(CheckedListBox checkedListBox)
        {
            List<int> checkedlist = new List<int>();
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    checkedlist.Add(i);
                }
            }
            return checkedlist.ToArray();
        }
    }
}
