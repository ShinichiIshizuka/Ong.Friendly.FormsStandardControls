using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Globalization;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsTreeViewGenerator : GeneratorBase
    {
        TreeView _control;

        /// <summary>
        /// アタッチ。
        /// </summary>
        /// <param name="windowHandle">ウィンドウハンドル(WPFオブジェクトの場合はIntPtr.Zero)。</param>
        /// <param name="controlObject">コントロールのオブジェクト(ネイティブウィンドウの場合はnull)。</param>
        public override void Attach(IntPtr windowHandle, object controlObject)
        {
            _control = (TreeView)controlObject;
            _control.AfterSelect += AfterSelect;
            _control.AfterExpand += AfterExpand;
            _control.AfterLabelEdit += AfterLabelEdit;
            _control.AfterCheck += AfterCheck;
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
        protected override void Detach()
        {
            _control.AfterSelect -= AfterSelect;
            _control.AfterExpand -= AfterExpand;
            _control.AfterLabelEdit -= AfterLabelEdit;
            _control.AfterCheck -= AfterCheck;
        }

        /// <summary>
        /// ラベル編集イベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            string from = GetNodePath(e.Node);
            AddSentence(new TokenName(), from + ".EmulateEditLabel(" + GenerateUtility.AdjustText(e.Label), new TokenAsync(CommaType.Before), ");");
        }

        /// <summary>
        /// 選択変更イベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_control.Focused)
            {
                string from = GetNodePath(e.Node);
                AddSentence(new TokenName(), ".EmulateNodeSelect(", new TokenName(), from, new TokenAsync(CommaType.Before), ");");
            }
        }

        /// <summary>
        /// 開いたイベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (_control.Focused)
            {
                string from = GetNodePath(e.Node);
                AddSentence(new TokenName(), from + ".EmulateExpand(", new TokenAsync(CommaType.Non), ");");
            }
        }

        /// <summary>
        /// チェックイベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (_control.Focused)
            {
                string from = GetNodePath(e.Node);
                AddSentence(new TokenName(), from + ".EmulateCheck(" + 
                    e.Node.Checked.ToString(CultureInfo.CurrentCulture).ToLower(CultureInfo.CurrentCulture),
                    new TokenAsync(CommaType.Non), ");");
            }
        }

        /// <summary>
        /// ノードへの取得パスを取得
        /// </summary>
        /// <param name="treeNode">ツリーノード</param>
        /// <returns>取得パス</returns>
        private string GetNodePath(TreeNode treeNode)
        {
            return ".FindItem(" + GetNodePathCore(treeNode) +  ")";
        }

        /// <summary>
        /// ノードへの取得パスを取得
        /// </summary>
        /// <param name="treeNode">ツリーノード</param>
        /// <returns>取得パス</returns>
        private string GetNodePathCore(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return string.Empty;
            }
            string front = GetNodePathCore(treeNode.Parent);
            if (!string.IsNullOrEmpty(front))
            {
                front += ", ";
            }
            return front + "\"" + treeNode.Text + "\"";
        }

        /// <summary>
        /// コードの最適化。
        /// </summary>
        /// <param name="list">コードリスト。</param>
        public override void Optimize(List<Sentence> code)
        {
            GenerateUtility.RemoveDuplicationFunction(this, code, "EmulateNodeSelect");
        }
    }
}
