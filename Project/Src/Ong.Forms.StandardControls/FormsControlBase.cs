using System;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// FormsControlBase
    /// </summary>
    public class FormsControlBase : WindowControl
    {
        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsControlBase(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
 　     /// コンストラクタです
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsControlBase(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
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
        /// 表示/非表示を切り替えます。
        /// </summary>
        public bool Visible
        {
            get { return (bool)this["Visible"]().Core; }
            set { this["Visible"](value); }
        }

        /// <summary>
        /// 活性/非活性を切り替えます。
        /// </summary>
        public bool Enabled
        {
            get { return (bool)this["Enabled"]().Core; }
            set { this["Enabled"](value); }
        }

    }
}
