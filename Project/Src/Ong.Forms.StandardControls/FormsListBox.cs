using System.Windows.Forms;
using System.Collections.Generic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがSystem.Windows.Forms.ListBoxのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsListBox : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
        public FormsListBox(WindowControl src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsListBox(WindowsAppFriend app, AppVar appVar)
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
        public int SelectedIndex
        {
            get { return (int)(this["SelectedIndex"]().Core); }
        }

        /// <summary>
        /// 選択モードを取得します。
        /// </summary>
        public SelectionMode SelectionMode
        {
            get { return (SelectionMode)(this["SelectionMode"]().Core); }
        }

        /// <summary>
        /// 選択状態のリスト項目一覧を取得します。
        /// </summary>
        public int[] SelectedIndexes
        {
            get { return (int[])(App[GetType(), "GetSelectedIndexesInTarget"](AppVar).Core); }
        }

        /// <summary>
        /// アイテムを指定されたテキストで検索します。
        /// </summary>
        /// <param name="ItemText">各ノードのテキスト</param>
        /// <returns>検索されたノードのアイテムハンドル。未発見時はnullが返ります。</returns>
        public int FindListIndex(string ItemText)
        {
            return (int)(this["FindString"](ItemText).Core);
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
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
        public void EmulateChangeSelectedState(int index, bool isSelect)
        {
            this["Focus"]();
            App[GetType(), "EmulateChangeSelectedStateInTarget"](AppVar, index, isSelect);
        }

        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
        /// <param name="async">非同期オブジェクト</param>
        public void EmulateChangeSelectedState(int index, bool isSelect, Async async)
        {
            this["Focus", new Async()]();
            App[GetType(), "EmulateChangeSelectedStateInTarget", async](AppVar, index, isSelect);
        }

        /// <summary>
        /// リストアイテムを選択します（内部）。
        /// </summary>
        /// <param name="listbox">リストボックス</param>
        private static int[] GetSelectedIndexesInTarget(ListBox listbox)
        {
            List<int> list = new List<int>();
            ListBox.SelectedIndexCollection collection = listbox.SelectedIndices;
            for (int itemIndex = 0; itemIndex < collection.Count; itemIndex++)
            {
                list.Add(collection[itemIndex]);
            }
            return list.ToArray();
        }

        /// <summary>
        /// リストアイテムを選択します（内部）。
        /// </summary>
        /// <param name="listbox">ListBox。</param>
        /// <param name="index">インデックス。</param>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
        private static void EmulateChangeSelectedStateInTarget(ListBox listbox, int index, bool isSelect)
        {
            listbox.SetSelected(index, isSelect);
        }
    }
}
