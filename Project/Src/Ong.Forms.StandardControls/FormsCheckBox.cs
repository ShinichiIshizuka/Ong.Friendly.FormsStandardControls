using System;
using System.Windows.Forms;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Reflection;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがSystem.Windows.Forms.CheckBoxのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsCheckBox : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsCheckBox(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsCheckBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// チェック状態を設定します
        /// </summary>
        /// <param name="value">チェック状態</param>
        public void EmulateCheck(CheckState value)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, value);
        }

        /// <summary>
        /// チェック状態を設定します
        /// 非同期で実行します
        /// </summary>
        /// <param name="value">チェック状態</param>
        /// <param name="async">非同期実行オブジェクト</param>
        public void EmulateCheck(CheckState value, Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar, value);
        }

        /// <summary>
        /// チェック状態を設定します
        /// </summary>
        /// <param name="checkBox">チェックボックス</param>
        /// <param name="value">チェック状態</param>
        static void EmulateCheckInTarget(CheckBox checkBox, CheckState value)
        {
            while (checkBox.CheckState != value)
            {
                checkBox.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(checkBox, new object[] { EventArgs.Empty });
            }
        }

        /// <summary>
        /// チェック状態を取得します
        /// </summary>
        /// <returns>チェック状態</returns>
        public CheckState CheckState
        {
            get { return (CheckState)(this["CheckState"]().Core); }
        }
    }
}