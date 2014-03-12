using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.TreeView.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.TreeViewのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    public class FormsTreeView : FormsControlBase
    {
#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="src">WindowControl object for the underlying control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
#endif
        public FormsTreeView(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        public FormsTreeView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Returns the currently selected node.
        /// </summary>
#else
        /// <summary>
        /// 選択しているノードを取得します。
        /// </summary>
#endif
        public FormsTreeNode SelectNode
        {
            get { return new FormsTreeNode(App, this["SelectedNode"]()); }
        }

#if ENG
        /// <summary>
        /// I get the child items.
        /// </summary>
        /// <param name="indexes">Index.</param>
        /// <returns>Child items.</returns>
#else
        /// <summary>
        /// 子アイテムを取得します。
        /// </summary>
        /// <param name="indexes">インデックス。</param>
        /// <returns>子アイテム。</returns>
#endif
        public FormsTreeNode GetItem(params int[] indexes)
        {
            return new FormsTreeNode(App, App[GetType(), "GetItemInTarget"](AppVar, indexes));
        }

#if ENG
        /// <summary>
        /// I get the child items.
        /// </summary>
        /// <param name="keys">A string of the key.</param>
        /// <returns>Child items.</returns>
#else
        /// <summary>
        /// 子アイテムを取得します。
        /// </summary>
        /// <param name="keys">キーとなるインデックスです。</param>
        /// <returns>子アイテム。</returns>
#endif
        public FormsTreeNode GetItem(params string[] keys)
        {
            return new FormsTreeNode(App, App[GetType(), "GetItemInTarget"](AppVar, keys));
        }

#if ENG
        /// <summary>
        /// Searches for items with the indicated display strings.
        /// </summary>
        /// <param name="texts">Display strings.</param>
        /// <returns>Child items.</returns>
#else
        /// <summary>
        /// 表示文字列からアイテムを検索します。
        /// </summary>
        /// <param name="texts">表示文字列。</param>
        /// <returns>子アイテム。</returns>
#endif
        public FormsTreeNode FindItem(params string[] texts)
        {
            return new FormsTreeNode(App, App[GetType(), "FindItemInTarget"](AppVar, texts));
        }

#if ENG
        /// <summary>
        /// Selects a certain node.
        /// </summary>
        /// <param name="node">Node to select.</param>
#else
        /// <summary>
        /// ノードを選択します。
        /// </summary>
        /// <param name="node">ノード。</param>
#endif
        public void EmulateNodeSelect(FormsTreeNode node)
        {
            App[GetType(), "EmulateNodeSelectInTarget"](AppVar, node.AppVar);
        }

#if ENG
        /// <summary>
        /// Selects a certain node.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="node">Node to select.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// ノードを選択します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="node">ノード。</param>
        /// <param name="async">非同期オブジェクト。</param>
#endif
        public void EmulateNodeSelect(FormsTreeNode node, Async async)
        {
            App[GetType(), "EmulateNodeSelectInTarget", async](AppVar, node.AppVar);
        }

        /// <summary>
        /// ノードを選択します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="tree">ツリー。</param>
        /// <param name="node">ノード。</param>
        static void EmulateNodeSelectInTarget(TreeView tree, TreeNode node)
        {
            tree.Focus();
            tree.SelectedNode = node;
        }

        /// <summary>
        /// アイテムを取得します。
        /// </summary>
        /// <param name="trerview">ツリービュー。</param>
        /// <param name="indexes">インデックス。</param>
        /// <returns>アイテム</returns>
        static TreeNode GetItemInTarget(TreeView trerview, params int[] indexes)
        {
            int currentIndex = 0;
            TreeNodeCollection items = trerview.Nodes;
            while (true)
            {
                TreeNode current = items[indexes[currentIndex]];
                if (indexes.Length - 1 == currentIndex)
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
        static TreeNode GetItemInTarget(TreeView trerview, params string[] keys)
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
        static TreeNode FindItemInTarget(TreeView trerview, string[] texts)
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