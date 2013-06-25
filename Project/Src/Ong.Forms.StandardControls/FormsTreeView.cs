using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがWindowControlがSystem.Windows.Forms.TreeViewのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsTreeView : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
        public FormsTreeView(WindowControl src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsTreeView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// 選択しているノードを取得します。
        /// </summary>
        public FormsTreeNode SelectNode
        {
            get { return new FormsTreeNode(App, this["SelectedNode"]()); }
        }

        /// <summary>
        /// 子アイテムを取得します。
        /// </summary>
        /// <param name="indexs">インデックス。</param>
        /// <returns>子アイテム。</returns>
        public FormsTreeNode GetItem(params int[] indexs)
        {
            return new FormsTreeNode(App, App[GetType(), "GetItemInTarget"](AppVar, indexs));
        }

        /// <summary>
        /// 子アイテムを取得します。
        /// </summary>
        /// <param name="keys">キーとなるインデックスです。</param>
        /// <returns>子アイテム。</returns>
        public FormsTreeNode GetItem(params string[] keys)
        {
            return new FormsTreeNode(App, App[GetType(), "GetItemInTarget"](AppVar, keys));
        }

        /// <summary>
        /// 表示文字列からアイテムを検索します。
        /// </summary>
        /// <param name="texts">表示文字列。</param>
        /// <returns>表示文字列。</returns>
        public FormsTreeNode FindItem(params string[] texts)
        {
            return new FormsTreeNode(App, App[GetType(), "FindItemInTarget"](AppVar, texts));
        }

        /// <summary>
        /// ノードを選択します。
        /// </summary>
        /// <param name="node">ノード。</param>
        public void EmulateNodeSelect(FormsTreeNode node)
        {
            this["SelectedNode"](node.AppVar);
        }

        /// <summary>
        /// ノードを選択します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="node">ノード。</param>
        /// <param name="async">非同期オブジェクト。</param>
        public void EmulateNodeSelect(FormsTreeNode node, Async async)
        {
            this["SelectedNode", async](node.AppVar);
        }

        /// <summary>
        /// アイテムを取得します。
        /// </summary>
        /// <param name="trerview">ツリービュー。</param>
        /// <param name="indexs">インデックス。</param>
        /// <returns>アイテム</returns>
        private static TreeNode GetItemInTarget(TreeView trerview, params int[] indexs)
        {
            int currentIndex = 0;
            TreeNodeCollection items = trerview.Nodes;
            while (true)
            {
                TreeNode current = items[indexs[currentIndex]];
                if (indexs.Length - 1 == currentIndex)
                {
                    return current;
                }
                else
                {
                    currentIndex++;
                }
                TreeNode treenode = current as TreeNode;
                if (treenode == null)
                {
                    return null;
                }
                items = treenode.Nodes;
            }
        }

        /// <summary>
        /// アイテムを取得します。
        /// </summary>
        /// <param name="trerview">ツリービュー。</param>
        /// <param name="keys">インデックス。</param>
        /// <returns>アイテム</returns>
        private static TreeNode GetItemInTarget(TreeView trerview, params string[] keys)
        {
            int currentIndex = 0;
            TreeNodeCollection items = trerview.Nodes;
            while (true)
            {
                TreeNode current = items[keys[currentIndex]];
                if (keys.Length - 1 == currentIndex)
                {
                    return current;
                }
                else
                {
                    currentIndex++;
                }
                TreeNode treenode = current as TreeNode;
                if (treenode == null)
                {
                    return null;
                }
                items = treenode.Nodes;
            }
        }

        /// <summary>
        /// 表示文字列からアイテムを検索します。
        /// </summary>
        /// <param name="trerview">ツリービュー。</param>
        /// <param name="texts">表示文字列。</param>
        /// <returns>アイテム。</returns>
        private static TreeNode FindItemInTarget(TreeView trerview, string[] texts)
        {
            int currentIndex = 0;
            TreeNodeCollection items = trerview.Nodes;
            while (true)
            {
                TreeNode current = null;
                foreach (TreeNode element in items)
                {
                    if (element.Text == texts[currentIndex])
                    {
                        if (texts.Length - 1 == currentIndex)
                        {
                            return element;
                        }
                        else
                        {
                            current = element;
                            currentIndex++;
                            break;
                        }
                    }
                }
                TreeNode treenode = current as TreeNode;
                if (treenode == null)
                {
                    return null;
                }
                items = treenode.Nodes;
            }
        }
    }
}