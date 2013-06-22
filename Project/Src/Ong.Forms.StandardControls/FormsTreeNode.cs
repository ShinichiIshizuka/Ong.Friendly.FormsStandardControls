using System;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.Friendly.Windows;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ツリーノードです。
    /// </summary>
    public class FormsTreeNode:AppVarWrapper
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
        public String Text
        {
            get { return (String)this["Text"]().Core; }
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
        /// 展開します。
        /// </summary>
        public void EmulateExpand()
        {
            this["Expand"]();
        }

        /// <summary>
        /// 展開します。
        /// 非同期で実行します。
        /// </summary>
        public void EmulateExpand(Async async)
        {
            this["Expand", async]();
        }

        /// <summary>
        /// 展開を閉じます。
        /// </summary>
        public void EmulateCollapse()
        {
            this["Collapse"]();
        }

        /// <summary>
        /// 展開を閉じます。
        /// 非同期で実行します。
        /// </summary>
        public void EmulateCollapse(Async async)
        {
            this["Collapse", async]();
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
        /// ノード名を編集します（内部）。
        /// </summary>
        /// <param name="treeNode">ノード。</param>
        /// <param name="nodeText">テキスト。</param>
        private static void EmulateEditLabelInTarget(TreeNode treeNode, string nodeText)
        {
            treeNode.BeginEdit();
            treeNode.Text = nodeText;
            treeNode.EndEdit(false);
        }

        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="check">true:チェック</param>
        public void EmulateCheck(bool check)
        {
            this["Checked"](check);
        }

        /// <summary>
        /// チェック状態を設定します。
        /// </summary>
        /// <param name="check">true:チェック</param>
        /// <param name="async">非同期オブジェクト</param>
        public void EmulateCheck(bool check, Async async)
        {
            this["Checked", async](check);
        }

        /// <summary>
        /// チェック状態を取得します。
        /// </summary>
        public bool Checked
        { 
            get { return (bool)(this["Checked"]().Core); }
        }
    }
}
