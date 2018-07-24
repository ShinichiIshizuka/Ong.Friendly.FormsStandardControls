using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Globalization;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsTreeView.
    /// </summary>
#else
    /// <summary>
    /// FormsTreeViewの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsTreeView")]
    public class FormsTreeViewGenerator : CaptureCodeGeneratorBase
    {
        TreeView _control;

#if ENG
        /// <summary>
        /// Attach.
        /// </summary>
#else
        /// <summary>
        /// アタッチ。
        /// </summary>
#endif
        protected override void Attach()
        {
            _control = (TreeView)ControlObject;
            _control.AfterSelect += AfterSelect;
            _control.AfterExpand += AfterExpand;
            _control.AfterCollapse += AfterCollapse;
            _control.AfterLabelEdit += AfterLabelEdit;
            _control.AfterCheck += AfterCheck;
        }

#if ENG
        /// <summary>
        /// Detach.
        /// </summary>
#else
        /// <summary>
        /// ディタッチ。
        /// </summary>
#endif
        protected override void Detach()
        {
            _control.AfterSelect -= AfterSelect;
            _control.AfterExpand -= AfterExpand;
            _control.AfterCollapse -= AfterCollapse;
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
        /// 閉じたイベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (_control.Focused)
            {
                string from = GetNodePath(e.Node);
                AddSentence(new TokenName(), from + ".EmulateCollapse(", new TokenAsync(CommaType.Non), ");");
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
                    new TokenAsync(CommaType.Before), ");");
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
    }
}
