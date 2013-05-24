using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがWindowControlがSystem.Windows.Forms.TextBoxのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsTextBox : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
        public FormsTextBox(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsTextBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// テキストを変更します。
        /// </summary>
        /// <param name="newText">新たなテキスト。</param>
        public void EmulateChangeText(string newText)
        {
            this["Text"](newText);
        }

        /// <summary>
        /// テキストを変更します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="newText">新たなテキスト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateChangeText(string newText, Async async)
        {
            this["Text", async](newText);
        }
    }
}