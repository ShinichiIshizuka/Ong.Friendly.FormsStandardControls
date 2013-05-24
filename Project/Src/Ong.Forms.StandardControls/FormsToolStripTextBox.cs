﻿using Codeer.Friendly;
using Codeer.Friendly.Windows;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ツールストリップアイテム操作クラスです。
    /// </summary>
    public class FormsToolStripTextBox : FormsToolStripItem
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">対象アプリ操作クラス。</param>
        /// <param name="appVar">対象アプリケーション内変数操作クラス。</param>
        public FormsToolStripTextBox(WindowsAppFriend app, AppVar appVar) : base(app, appVar) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="item">ToolStripItem操作クラス</param>
        public FormsToolStripTextBox(FormsToolStripItem item) : base(item.App, item.AppVar) { }
 
        /// <summary>
        /// テキストボックス取得です。
        /// </summary>
        public FormsTextBox ComboBox { get { return new FormsTextBox(App, this["TextBox"]()); } }
    }
}
