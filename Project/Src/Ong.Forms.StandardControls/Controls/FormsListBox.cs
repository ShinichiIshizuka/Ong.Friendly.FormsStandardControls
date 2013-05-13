using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// WindowControlがSystem.Windows.Forms.ListBoxのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsListBox : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsListBox(FormsControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsListBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// 一覧のアイテム数を取得します
        /// </summary>
        public int ItemCount
        {
            get 
            {
                return (int)(this["Items"]()["Count"]().Core);
            }
        }

        /// <summary>
        /// 現在選択されているアイテムのインデックスを取得します
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return (int)(this["SelectedIndex"]().Core);
            }
        }
        
        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします
        /// </summary>
        public void EmulateChangeSelectedIndex(int Index)
        {
            this["SelectedIndex"](Index);
        }

        /// <summary>
        /// 指定されたインデックスに該当するアイテムを選択状態にします
        /// 非同期に実行します
        /// </summary>
        /// <param name="Index">インデックス</param>
        /// <param name="async">非同期実行オブジェクト</param>
        public void EmulateChangeSelectedIndex(int Index, Async async)
        {
            this["SelectedIndex", async](Index);
        }

        /// <summary>
        /// アイテムを指定されたテキストで検索します
        /// </summary>
        /// <param name="ItemText">各ノードのテキスト</param>
        /// <returns>検索されたノードのアイテムハンドル。未発見時はnullが返ります</returns>
        public int FindListIndex(string ItemText)
        {
            return (int)(this["FindString"](ItemText).Core);
        }
    }
}
