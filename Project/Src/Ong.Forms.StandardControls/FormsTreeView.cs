using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがWindowControlがSystem.Windows.Forms.TreeViewのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsTreeView : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsTreeView(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsTreeView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// 選択しているノードを取得します
        /// </summary>
        public FormsTreeNode SelectNode
        {
            get
            {
                return new FormsTreeNode(App, this["SelectedNode"]());
            }
        }

        /// <summary>
        /// ノードを選択します
        /// </summary>
        /// <param name="node">ノード</param>
        public void EmulateNodeSelect(FormsTreeNode node)
        {
            this["SelectedNode"](node.AppVar);
        }

        /// <summary>
        /// ノードを選択します
        /// 非同期で実行します
        /// </summary>
        /// <param name="node">ノード</param>
        /// <param name="async">非同期オブジェクト</param>
        public void EmulateNodeSelect(FormsTreeNode node, Async async)
        {
            this["SelectedNode", async](node.AppVar);
        }

        /// <summary>
        /// ノードを指定されたテキストで検索します
        /// </summary>
        /// <param name="nodeText">各ノードのテキスト</param>
        /// <returns>検索されたノードのアイテムハンドル。未発見時はnullが返ります</returns>
        public FormsTreeNode FindNode(string nodeText)
        {
            AppVar returnNode = (App[GetType(), "FindNodeInTarget"](AppVar, nodeText));
            if (returnNode != null)
            {
                return new FormsTreeNode(App, returnNode);
            }
            return null;
        }

        /// <summary>
        /// ノードを指定されたテキストで検索します（内部）
        /// </summary>
        /// <param name="treeview">ツリービュー</param>
        /// <param name="nodeText">検索するテキスト</param>
        /// <returns>テキストと一致するノードを返却します。存在しない場合はnull,複数見つかった場合は最初のノードを返却します</returns>
        private static TreeNode FindNodeInTarget(TreeView treeview,string nodeText)
        {
            if (treeview.Nodes.Count > 0)
            {
                TreeNode treeNode = FindNodeInTargetCore(treeview.Nodes[0], nodeText);
                if (treeNode != null)
                {
                    return treeNode;
                }
            }
            return null;
        }

        /// <summary>
        /// ノードを指定されたテキストで検索します（内部）
        /// </summary>
        /// <param name="treeNode">ノード</param>
        /// <param name="nodeText">検索するテキスト</param>
        /// <returns></returns>
        private static TreeNode FindNodeInTargetCore(TreeNode treeNode,string nodeText)
        {
            TreeNode findNode;
            if(treeNode == null)
            {
                return null;
            }
            if(treeNode.Text == nodeText)
            {
                return treeNode;
            }
            foreach(TreeNode node in treeNode.Nodes)
            {
                if(node.Text == nodeText)
                {
                    return node;
                }
                findNode = FindNodeInTargetCore(node, nodeText);
                if(findNode != null)
                {   
                    return findNode;
                }
            }
            return null;
        }
    }
}