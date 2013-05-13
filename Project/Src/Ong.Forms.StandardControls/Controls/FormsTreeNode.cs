using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ツリーノード
    /// </summary>
    public class FormsTreeNode:AppVarWrapper
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsTreeNode(AppVar appVar)
            : base(appVar)
        {
        }
    
        /// <summary>
        /// ノード
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>ノード</returns>
        public FormsTreeNode GetNode(int index)
        {
            return new FormsTreeNode(AppVar["Nodes"]()["[]"](index));
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
    }
}
