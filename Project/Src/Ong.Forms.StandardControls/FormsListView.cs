using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがSystem.Windows.Forms.ListViewのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsListView : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsListView(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsListView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// アイテム＋サブアイテム数を取得します。
        /// </summary>
        public int SubItemCount
        {
            get
            {
                return (int)(this["Columns"]()["Count"]().Core);
            }
        }

        /// <summary>
        /// アイテム数を取得します。
        /// </summary>
        public int ItemCount
        {
            get
            {
                return (int)(this["Items"]()["Count"]().Core);
            }
        }

        /// <summary>
        /// 選択している最初のリストアイテムを取得します
        /// </summary>
        public FormsListViewItem SelectItem
        {
            get
            {
                AppVar returnItem = (App[GetType(), "SelectItemInTarget"](AppVar));
                return new FormsListViewItem(App, returnItem);
            }
        }

        /// <summary>
        /// 選択リストアイテム（内部）
        /// </summary>
        /// <param name="listview">リストビュー</param>
        /// <returns>選択されたリストアイテム</returns>
        private static ListViewItem SelectItemInTarget(ListView listview)
        {
            for (int itemIndex = 0; itemIndex < listview.Items.Count; itemIndex++)
            {
                if (listview.Items[itemIndex].Selected == true)
                {
                    return listview.Items[itemIndex];
                }
            }
            return null;
        }

        /// <summary>
        /// 行を選択します
        /// </summary>
        /// <param name="itemIndex">行番号</param>
        public void EmulateItemSelect(int itemIndex)
        {
            App[GetType(), "ItemSelectInTarget"](AppVar, itemIndex);
        }

        /// <summary>
        /// リストアイテム（行）を選択します
        /// 非同期で実行します
        /// </summary>
        /// <param name="itemIndex">ノード</param>
        /// <param name="async">非同期オブジェクト</param>
        public void EmulateItemSelect(int itemIndex, Async async)
        {
            App[GetType(), "ItemSelectInTarget", async](AppVar, itemIndex);
        }

        /// <summary>
        /// リストアイテム選択（内部）
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="itemIndex"></param>
        private static void ItemSelectInTarget(ListView listview, int itemIndex)
        {
            listview.Items[itemIndex].Selected = true;
        }

        /// <summary>
        /// リストアイテムを指定されたテキストで検索します
        /// </summary>
        /// <param name="itemText">テキスト</param>
        /// <returns>検索されたアイテムのアイテムハンドル。未発見時はnullが返ります</returns>
        public FormsListViewItem FindItem(string itemText)
        {
            AppVar returnItem = this["FindItemWithText"](itemText, true, 0);
            if (returnItem != null)
            {
                return new FormsListViewItem(App, returnItem);
            }
            return null;
        }

        /// <summary>
        /// Viewスタイルを取得します
        /// </summary>
        public View GetView
        {
            get { return (View)(this["View"]().Core); } 
        }
    }
}