using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    //@@@チェックもいるよね。

    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsTreeViewGenerator : IDisposable
    {
        string _name;
        List<string> _code;
        TreeView _control;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="handle">ウィンドウハンドル</param>
        /// <param name="name">変数名称</param>
        /// <param name="code">コード</param>
        public FormsTreeViewGenerator(IntPtr handle, string name, List<string> code)
        {
            _name = name;
            _code = code;
            _control = (TreeView)Control.FromHandle(handle);
            _control.AfterSelect += AfterSelect;
            _control.AfterExpand += AfterExpand;
            _control.AfterLabelEdit += AfterLabelEdit;
        }

        /// <summary>
        /// ラベル編集イベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            string from = GetNodePath(e.Node);
            _code.Add(_name + from + ".EmulateChangeText(\"" + e.Label + "\");"); 
        }

        /// <summary>
        /// 選択変更イベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void AfterSelect(object sender, TreeViewEventArgs e)
        {
            string from = GetNodePath(e.Node);
            _code.Add(_name + ".EmulateNodeSelect(" + _name + from + ");"); 
        }

        /// <summary>
        /// 開いたイベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void AfterExpand(object sender, TreeViewEventArgs e)
        {
            string from = GetNodePath(e.Node);
            _code.Add(_name + from + ".EmulateExpand();"); 
        }

        /// <summary>
        /// ノードへの取得パスを取得
        /// </summary>
        /// <param name="treeNode">ツリーノード</param>
        /// <returns>取得パス</returns>
        private string GetNodePath(TreeNode treeNode)
        {
            return ".FindItem(" + GetNodePathCore(treeNode) + ")";
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
		/// ファイナライザ
		/// </summary>
        ~FormsTreeViewGenerator()
		{
			Dispose(false);
		}

		/// <summary>
		/// 破棄
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// 破棄
		/// </summary>
		/// <param name="disposing">破棄フラグ</param>
		protected virtual void Dispose(bool disposing)
		{
            if (disposing)
            {
                _control.AfterSelect -= AfterSelect;
                _control.AfterExpand -= AfterExpand;
                _control.AfterLabelEdit -= AfterLabelEdit;
            }
		}
    }
}
