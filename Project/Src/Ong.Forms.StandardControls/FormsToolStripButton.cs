using Codeer.Friendly;
using System.Windows.Forms;
using Codeer.Friendly.Windows;
using System.Reflection;
using System;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ツールストリップボタン操作クラス
    /// </summary>
    public class FormsToolStripButton : FormsToolStripItem
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
       /// <param name="app">対象アプリ操作クラス</param>
        /// <param name="appVar">対象アプリケーション内変数操作クラス</param>
        public FormsToolStripButton(WindowsAppFriend app, AppVar appVar) : base(app, appVar) { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="item">ToolStripItem操作クラス</param>
        public FormsToolStripButton(FormsToolStripItem item) : base(item.App, item.AppVar) { }

        /// <summary>
        /// チェック状態を取得します
        /// </summary>
        /// <returns>チェック状態</returns>
        public CheckState CheckState
        {
            get { return (CheckState)(this["CheckState"]().Core); }
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
        /// <param name="checkButton">チェックボックス</param>
        /// <param name="value">チェック状態</param>
        static void EmulateCheckInTarget(ToolStripButton checkButton, CheckState value)
        {
            while (checkButton.CheckState != value)
            {
                checkButton.PerformClick();
            }
        }
    }
}
