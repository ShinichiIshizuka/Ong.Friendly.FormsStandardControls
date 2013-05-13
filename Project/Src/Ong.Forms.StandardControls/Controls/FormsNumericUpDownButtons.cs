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
    /// Windows.Forms.NumericUpDownButtonsのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsNumericUpDownButtons : WindowControlBase
    {
        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsNumericUpDownButtons(WindowControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
 　     /// コンストラクタです
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsNumericUpDownButtons(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// △をクリックします
        /// </summary>
        public void EmulateUpClick()
        {
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)1));
            this["upDownButtons"]()["OnUpDown"](args);
        }

        /// <summary>
        /// △をクリックします
        /// 非同期で実行します
        /// </summary>
        /// <param name="async">非同期実行オブジェクト</param>
        public void EmulateUpClick(Async async)
        {
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)1));
            this["upDownButtons"]()["OnUpDown", async](args);
        }

        /// <summary>
        /// ▽をクリックします
        /// </summary>
        public void EmulateDownClick()
        {
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)2));
            this["upDownButtons"]()["OnUpDown"](args);
        }

        /// <summary>
        /// ▽をクリックします
        /// 非同期で実行します
        /// </summary>
        /// <param name="async">非同期実行オブジェクト</param>
        public void EmulateDownClick(Async async)
        {
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)2));
            this["upDownButtons"]()["OnUpDown", async](args);
        }
    }
}