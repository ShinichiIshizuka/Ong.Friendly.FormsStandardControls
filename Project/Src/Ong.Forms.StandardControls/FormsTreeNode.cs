using System;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.Friendly.Windows;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ツリーノード
    /// </summary>
    public class FormsTreeNode:AppVarWrapper
    {
        WindowsAppFriend _app;

        //@@@ FindNodeを追加
        //閉じる（Expandの逆）
        //Edit,Checkを追加

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsTreeNode(WindowsAppFriend app, AppVar appVar)
            : base(appVar)
        {
            _app = app;
        }
    
        /// <summary>
        /// ノード
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>ノード</returns>
        public FormsTreeNode GetNode(int index)
        {
            return new FormsTreeNode(_app, AppVar["Nodes"]()["[]"](index));
        }

        /// <summary>
        /// テキストを変更します
        /// </summary>
        /// <param name="newText">新たなテキスト</param>
        public void EmulateChangeText(string newText)
        {
            this["Text"](newText);
        }

        /// <summary>
        /// テキストを変更します
        /// 非同期で実行します
        /// </summary>
        /// <param name="newText">新たなテキスト</param>
        /// <param name="async">非同期実行オブジェクト</param>
        public void EmulateChangeText(string newText, Async async)
        {
            this["Text", async](newText);
        }

        /// <summary>
        /// テキストを取得します
        /// </summary>
        /// <returns>テキスト</returns>
        public String Text
        {
            get { return (String)this["Text"]().Core; }
        }

        /// <summary>
        /// 展開しているかを取得します
        /// </summary>
        /// <returns>true:展開</returns>
        public bool IsExpanded
        {
            get { return (bool)this["IsExpanded"]().Core; }
        }

        /// <summary>
        /// 展開します
        /// </summary>
        public void EmulateExpand()
        {
            this["Expand"](); 
        }

        /// <summary>
        /// 展開します
        /// 非同期で実行します
        /// </summary>
        public void EmulateExpand(Async async)
        {
            this["Expand", async]();
        }

        /// <summary>
        /// ノードを指定されたテキストで検索します
        /// </summary>
        /// <param name="nodeText">各ノードのテキスト</param>
        /// <returns>検索されたノードのアイテムハンドル。未発見時はnullが返ります</returns>
        public FormsTreeNode FindNode(string nodeText)
        {
            AppVar returnNode = (_app[GetType(), "FindNodeInTarget"](AppVar, nodeText));
            if (returnNode != null)
            {
                return new FormsTreeNode(_app, returnNode);
            }
            return null;
        }

        /// <summary>
        /// ノードを指定されたテキストで検索します（内部）
        /// </summary>
        /// <param name="treeNode">ノード</param>
        /// <param name="nodeText">検索するテキスト</param>
        /// <returns></returns>
        private static TreeNode FindNodeInTarget(TreeNode treeNode, string nodeText)
        {
            TreeNode findNode;
            if (treeNode == null)
            {
                return null;
            }
            if (treeNode.Text == nodeText)
            {
                return treeNode;
            }
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Text == nodeText)
                {
                    return node;
                }
                findNode = FindNodeInTarget(node, nodeText);
                if (findNode != null)
                {
                    return findNode;
                }
            }
            return null;
        }
    }
}
