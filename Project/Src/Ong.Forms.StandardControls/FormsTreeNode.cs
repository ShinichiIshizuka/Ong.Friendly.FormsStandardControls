using System;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ツリーノードです。
    /// </summary>
    public class FormsTreeNode : AppVarWrapper
    {
        WindowsAppFriend _app;

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsTreeNode(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            _app = app;
        }

        /// <summary>
        /// テキストを取得します。
        /// </summary>
        /// <returns>テキスト。</returns>
        public string Text
        {
            get { return (string)this["Text"]().Core; }
        }

        /// <summary>
        /// 展開しているかを取得します。
        /// </summary>
        /// <returns>true:展開。</returns>
        public bool IsExpanded
        {
            get { return (bool)this["IsExpanded"]().Core; }
        }

        /// <summary>
        /// チェック状態を取得します。
        /// </summary>
        public bool Checked
        {
            get { return (bool)(this["Checked"]().Core); }
        }

        /// <summary>
        /// 展開します。
        /// </summary>
        public void EmulateExpand()
        {
            App[GetType(), "EmulateExpandInTarget"](AppVar);
        }

        /// <summary>
        /// 展開します。
        /// 非同期で実行します。
        /// </summary>
        public void EmulateExpand(Async async)
        {
            App[GetType(), "EmulateExpandInTarget", async](AppVar);
        }

        /// <summary>
        /// 展開を閉じます。
        /// </summary>
        public void EmulateCollapse()
        {
            App[GetType(), "EmulateCollapseInTarget"](AppVar);
        }

        /// <summary>
        /// 展開を閉じます。
        /// 非同期で実行します。
        /// </summary>
        public void EmulateCollapse(Async async)
        {
            App[GetType(), "EmulateCollapseInTarget", async](AppVar);
        }

        /// <summary>
        /// ノード名を編集します。
        /// </summary>
        /// <param name="nodeText">テキスト。</param>
        public void EmulateEditLabel(string nodeText)
        {
            App[GetType(), "EmulateEditLabelInTarget"](AppVar, nodeText);
        }

        /// <summary>
        /// ノード名を編集します(非同期)。
        /// </summary>
        /// <param name="nodeText">テキスト。</param>
        /// <param name="async">非同期オブジェクト。</param>
        public void EmulateEditLabel(string nodeText, Async async)
        {
            App[GetType(), "EmulateEditLabelInTarget", async](AppVar, nodeText);
        }

        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="check">true:チェック</param>
        public void EmulateCheck(bool check)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, check);
        }

        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="check">true:チェック</param>
        /// <param name="async">非同期オブジェクト</param>
        public void EmulateCheck(bool check, Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar, check);
        }

        /// <summary>
        /// 展開します。
        /// </summary>
        /// <param name="treeNode">ノード。</param>
        private static void EmulateExpandInTarget(TreeNode treeNode)
        {
            treeNode.TreeView.Focus();
            treeNode.Expand();
        }

        /// <summary>
        /// 展開をとじます。
        /// </summary>
        /// <param name="treeNode">ノード。</param>
        private static void EmulateCollapseInTarget(TreeNode treeNode)
        {
            treeNode.TreeView.Focus();
            treeNode.Collapse();
        }

        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="treeNode">ノード。</param>
        /// <param name="check">true:チェック</param>
        private static void EmulateCheckInTarget(TreeNode treeNode, bool check)
        {
            treeNode.TreeView.Focus();
            treeNode.Checked = check;
        }

        /// <summary>
        /// ノード名を編集します（内部）。
        /// </summary>
        /// <param name="treeNode">ノード。</param>
        /// <param name="nodeText">テキスト。</param>
        private static void EmulateEditLabelInTarget(TreeNode treeNode, string nodeText)
        {
            treeNode.TreeView.Focus();
            treeNode.BeginEdit();
            treeNode.Text = nodeText;
            treeNode.EndEdit(false);
        }
    }
}
