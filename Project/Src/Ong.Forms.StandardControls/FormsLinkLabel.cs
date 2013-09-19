using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;
using System.Reflection;
using System;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがSystem.Windows.Forms.LinkLabelのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsLinkLabel : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです。</param>
        public FormsLinkLabel(WindowControl src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsLinkLabel(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// クリックです。
        /// </summary>
        public void EmulateLinkClick()
        {
            App[GetType(), "EmulateLinkClickInTarget"](AppVar);
        }

        /// <summary>
        /// クリックです。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
        public void EmulateLinkClick(Async async)
        {
            App[GetType(), "EmulateLinkClickInTarget", async](AppVar);
        }

        /// <summary>
        /// クリックです。
        /// </summary>
        /// <param name="linklabel">リンクラベル。</param>
        static void EmulateLinkClickInTarget(LinkLabel linklabel)
        {
            linklabel.Focus();
            linklabel.GetType().GetMethod("OnLinkClicked", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(linklabel, new object[] { new LinkLabelLinkClickedEventArgs(new LinkLabel.Link()) });
        }
    }
}