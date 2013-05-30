using System;
using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Reflection;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがSystem.Windows.Forms.RadioButtonのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsRadioButton : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
        public FormsRadioButton(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsRadioButton(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// チェックします。
        /// </summary>
        public void EmulateCheck()
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar);
        }

        /// <summary>
        /// チェックします。
        /// 非同期で実行します
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateCheck(Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar);
        }

        /// <summary>
        /// チェック状態にします。
        /// </summary>
        /// <param name="radioButton">ラジオボタン。</param>
        static void EmulateCheckInTarget(RadioButton radioButton)
        {
            int tryCount = 0;
            while (radioButton.Checked != true)
            {
                tryCount++;
                radioButton.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(radioButton, new object[] { EventArgs.Empty });
                if (tryCount == 2)
                {
                    throw new NotSupportedException(Properties.Resources.ErrorCheckSetting);
                }
            }
        }

        /// <summary>
        /// チェック状態を取得します。
        /// </summary>
        /// <returns>チェック状態。</returns>
        public bool Checked
        {
            get { return (bool)(this["Checked"]().Core); }
        }
    }
}
