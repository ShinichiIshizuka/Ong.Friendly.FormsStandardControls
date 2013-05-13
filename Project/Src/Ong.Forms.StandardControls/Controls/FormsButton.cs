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
    /// WindowControlがSystem.Windows.Forms.Buttonのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsButton : WindowControlBase
    {
        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsButton(WindowControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
 　     /// コンストラクタです
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsButton(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// クリックします
        /// </summary>
        public void EmulateClick()
        {
            this["PerformClick"]();
        }

        /// <summary>
        /// クリックします
        /// 非同期で実行します
        /// </summary>
        /// <param name="async">非同期実行オブジェクト</param>
        public void EmulateClick(Async async)
        {
            this["PerformClick", async]();
        }
    }
}