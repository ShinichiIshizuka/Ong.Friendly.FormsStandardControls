using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;
using System.Reflection;
using System;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.LinkLabel.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.LinkLabelのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    public class FormsLinkLabel : FormsControlBase
    {
#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="src">WindowControl object for the underlying control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです。</param>
#endif
        public FormsLinkLabel(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        public FormsLinkLabel(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Performs a click.
        /// </summary>
#else
        /// <summary>
        /// クリックです。
        /// </summary>
#endif
        public void EmulateLinkClick()
        {
            App[GetType(), "EmulateLinkClickInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Performs a click.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// クリックです。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
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