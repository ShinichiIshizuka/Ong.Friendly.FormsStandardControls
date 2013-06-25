using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがWindows.Forms.NumericUpDownのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsNumericUpDown : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsNumericUpDown(WindowControl src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsNumericUpDown(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// △をクリックします。
        /// </summary>
        public void EmulateUp()
        {
            this["Focus"]();
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)1));
            this["upDownButtons"]()["OnUpDown"](args);
        }

        /// <summary>
        /// △をクリックします。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateUp(Async async)
        {
            this["Focus", new Async()]();
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)1));
            this["upDownButtons"]()["OnUpDown", async](args);
        }

        /// <summary>
        /// ▽をクリックします。
        /// </summary>
        public void EmulateDown()
        {
            this["Focus"]();
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)2));
            this["upDownButtons"]()["OnUpDown"](args);
        }

        /// <summary>
        /// ▽をクリックします。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateDown(Async async)
        {
            this["Focus", new Async()]();
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)2));
            this["upDownButtons"]()["OnUpDown", async](args);
        }

        /// <summary>
        /// テキストを変更します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        public void EmulateChangeText(string text)
        {
            this["Focus"]();
            this["Text"](text);
        }

        /// <summary>
        /// テキストを変更します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateChangeText(string text, Async async)
        {
            this["Focus", new Async()]();
            this["Text", async](text);
        }
    }
}
