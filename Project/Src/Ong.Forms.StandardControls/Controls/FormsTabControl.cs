using System;
using System.Collections.Generic;
using System.Text;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// WindowControlがSystem.Windows.Forms.TabControlのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsTabControl : WindowControlBase
    {
        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsTabControl(WindowControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
 　     /// コンストラクタです
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsTabControl(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// タブ数を取得します
        /// </summary>
        /// <returns>タブ数</returns>
        public int TabCount
        {
            get { return (int)this["TabCount"]().Core; }
        }

        /// <summary>
        /// 選択されたタブインデックスを取得します
        /// </summary>
        /// <returns>タブインデックス</returns>
        public int SelectedIndex
        {
            get { return (int)this["SelectedIndex"]().Core; }
        }

        /// <summary>
        /// タブを選択します
        /// </summary>
        /// <param name="index">タブインデックス（０始まり）</param>
        public void EmulateTabSelect(int index)
        {
            this["SelectedIndex"](index);
        }

        /// <summary>
        /// タブを選択します
        /// </summary>
        /// <param name="index">タブインデックス（０始まり）</param>
        /// <param name="async">非同期オブジェクト</param>
        public void EmulateTabSelect(int index,Async async)
        {
            this["SelectedIndex", async](index);
        }
    }
}