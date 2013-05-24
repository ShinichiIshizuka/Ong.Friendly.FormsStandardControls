using System;
using System.Collections.Generic;
using System.Text;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;

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
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsNumericUpDown(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }
        /// <summary>
        /// △をクリックします。
        /// </summary>
        public void EmulateUpClick()
        {
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)1));
            this["upDownButtons"]()["OnUpDown"](args);
        }

        /// <summary>
        /// △をクリックします。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateUpClick(Async async)
        {
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)1));
            this["upDownButtons"]()["OnUpDown", async](args);
        }

        /// <summary>
        /// ▽をクリックします。
        /// </summary>
        public void EmulateDownClick()
        {
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)2));
            this["upDownButtons"]()["OnUpDown"](args);
        }

        /// <summary>
        /// ▽をクリックします。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateDownClick(Async async)
        {
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)2));
            this["upDownButtons"]()["OnUpDown", async](args);
        }

        /// <summary>
        /// テキストを変更します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        public void EmulateChangeText(string text)
        {
            this["Text"](text);
        }

        /// <summary>
        /// テキストを変更します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateChangeText(string text, Async async)
        {
            this["Text", async](text);
        }
    }
}
