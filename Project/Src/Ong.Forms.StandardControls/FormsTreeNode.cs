using System;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Ong.Friendly.FormsStandardControls.Properties;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.Friendly.Windows.Grasp;
using System.Drawing;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on tree nodes.
    /// </summary>
#else
    /// <summary>
    /// ツリーノードです。
    /// </summary>
#endif
    public class FormsTreeNode : AppVarWrapper, IUIObject
    {
#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsTreeNode(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsTreeNode(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsTreeNode(AppVar windowObject).", false)]
        public FormsTreeNode(WindowsAppFriend app, AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        public FormsTreeNode(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the node's text.
        /// </summary>
#else
        /// <summary>
        /// テキストを取得します。
        /// </summary>
#endif
        public string Text
        {
            get { return (string)this["Text"]().Core; }
        }

#if ENG
        /// <summary>
        /// Returns true if the node is expanded.
        /// </summary>
#else
        /// <summary>
        /// 展開しているかを取得します。
        /// </summary>
#endif
        public bool IsExpanded
        {
            get { return (bool)this["IsExpanded"]().Core; }
        }

#if ENG
        /// <summary>
        /// Returns true if the node is currently checked.
        /// </summary>
#else
        /// <summary>
        /// チェック状態を取得します。
        /// </summary>
#endif
        public bool Checked
        {
            get { return (bool)(this["Checked"]().Core); }
        }

#if ENG
        /// <summary>
        /// Returns the size of IUIObject.
        /// </summary>
#else
        /// <summary>
        /// IUIObjectのサイズを取得します。
        /// </summary>
#endif
        public Size Size => (Size)AppVar["Bounds"]()["Size"]().Core;

#if ENG
        /// <summary>
        /// Expands the node.
        /// </summary>
#else
        /// <summary>
        /// 展開します。
        /// </summary>
#endif
        public void EmulateExpand()
        {
            App[typeof(FormsTreeNode), "EmulateExpandInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Expands the node.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 展開します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateExpand(Async async)
        {
            App[typeof(FormsTreeNode), "EmulateExpandInTarget", async](AppVar);
        }

#if ENG
        /// <summary>
        /// Collapses the node.
        /// </summary>
#else
        /// <summary>
        /// 展開を閉じます。
        /// </summary>
#endif
        public void EmulateCollapse()
        {
            App[typeof(FormsTreeNode), "EmulateCollapseInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Collapses the node.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 展開を閉じます。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateCollapse(Async async)
        {
            App[typeof(FormsTreeNode), "EmulateCollapseInTarget", async](AppVar);
        }

#if ENG
        /// <summary>
        /// Modifies the node's text.
        /// </summary>
        /// <param name="nodeText">New text to use.</param>
#else
        /// <summary>
        /// ノード名を編集します。
        /// </summary>
        /// <param name="nodeText">テキスト。</param>
#endif
        public void EmulateEditLabel(string nodeText)
        {
            App[typeof(FormsTreeNode), "EmulateEditLabelInTarget"](AppVar, nodeText);
        }

#if ENG
        /// <summary>
        /// Modifies the node's text.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="nodeText">New text to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// ノード名を編集します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="nodeText">テキスト。</param>
        /// <param name="async">非同期オブジェクト。</param>
#endif
        public void EmulateEditLabel(string nodeText, Async async)
        {
            App[typeof(FormsTreeNode), "EmulateEditLabelInTarget", async](AppVar, nodeText);
        }

#if ENG
        /// <summary>
        /// Sets the node's checked state.
        /// </summary>
        /// <param name="check">true to set the node as checked.</param>
#else
        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="check">true:チェック</param>
#endif
        public void EmulateCheck(bool check)
        {
            App[typeof(FormsTreeNode), "EmulateCheckInTarget"](AppVar, check);
        }

#if ENG
        /// <summary>
        /// Sets the node's checked state.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="check">true to set the node as checked.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// チェック状態を設定します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="check">true:チェック</param>
        /// <param name="async">非同期オブジェクト</param>
#endif
        public void EmulateCheck(bool check, Async async)
        {
            App[typeof(FormsTreeNode), "EmulateCheckInTarget", async](AppVar, check);
        }

#if ENG
        /// <summary>
        /// Selects a certain node.
        /// </summary>
#else
        /// <summary>
        /// ノードを選択します。
        /// </summary>
#endif
        public void EmulateSelect()
        {
            App[typeof(FormsTreeNode), "EmulateSelectInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Selects a certain node.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// ノードを選択します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期オブジェクト。</param>
#endif
        public void EmulateSelect(Async async)
        {
            App[typeof(FormsTreeNode), "EmulateSelectInTarget", async](AppVar);
        }

        /// <summary>
        /// ノードを選択します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="node">ノード。</param>
        static void EmulateSelectInTarget(TreeNode node)
        {
            var tree = node.TreeView;
            tree.Focus();
            tree.SelectedNode = node;
        }

        /// <summary>
        /// 展開します。
        /// </summary>
        /// <param name="treeNode">ノード。</param>
        private static void EmulateExpandInTarget(TreeNode treeNode)
        {
            if (treeNode.TreeView == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetTreeView);
            }
            treeNode.TreeView.Focus();
            treeNode.Expand();
        }

        /// <summary>
        /// 展開をとじます。
        /// </summary>
        /// <param name="treeNode">ノード。</param>
        private static void EmulateCollapseInTarget(TreeNode treeNode)
        {
            if (treeNode.TreeView == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetTreeView);
            }
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
            if (treeNode.TreeView == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetTreeView);
            }
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
            if (treeNode.TreeView == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetTreeView);
            }
            treeNode.TreeView.Focus();
            treeNode.BeginEdit();
            treeNode.Text = nodeText;
            treeNode.EndEdit(false);
        }

#if ENG
        /// <summary>
        /// Convert IUIObject's client coordinates to screen coordinates.
        /// </summary>
        /// <param name="clientPoint">client coordinates.</param>
        /// <returns>screen coordinates.</returns>
#else
        /// <summary>
        /// IUIObjectのクライアント座標からスクリーン座標に変換します。
        /// </summary>
        /// <param name="clientPoint">クライアント座標</param>
        /// <returns>スクリーン座標</returns>
#endif
        public Point PointToScreen(Point clientPoint)
        {
            var rect = (Rectangle)AppVar["Bounds"]().Core;
            var screen = (Point)AppVar["TreeView"]()["PointToScreen"](clientPoint).Core;
            return new Point(screen.X + rect.X, screen.Y + rect.Y);
        }

#if ENG
        /// <summary>
        /// Make it active.
        /// </summary>
#else
        /// <summary>
        /// アクティブな状態にします。
        /// </summary>
#endif
        public void Activate()
        {
            var w = new WindowControl(AppVar["TreeView"]());
            w.Activate();
        }
    }
}
