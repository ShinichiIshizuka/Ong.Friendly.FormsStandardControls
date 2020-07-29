using Codeer.Friendly;
using Codeer.Friendly.Windows;
using System.Windows.Forms;
using System;
using Ong.Friendly.FormsStandardControls.Properties;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Collections.Generic;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on tool strip items.
    /// </summary>
#else
    /// <summary>
    /// ツールストリップアイテム操作クラスです。
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.ToolStripItem", DriverMappingEnabled = false)]
    public class FormsToolStripItem : AppVarWrapper
    {
#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsToolStripItem(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsToolStripItem(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsToolStripItem(AppVar windowObject).", false)]
        public FormsToolStripItem(WindowsAppFriend app, AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        public FormsToolStripItem(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the item's text.
        /// </summary>
#else
        /// <summary>
        /// テキスト
        /// </summary>
#endif
        public string Text { get { return (string)this["Text"]().Core; } }

#if ENG
        /// <summary>
        /// Returns true if the item is visible.
        /// </summary>
#else
        /// <summary>
        /// 可視状態か
        /// </summary>
#endif
        public bool Visible { get { return (bool)this["Visible"]().Core; } }

#if ENG
        /// <summary>
        /// Returns true if the control is enabled.
        /// </summary>
#else
        /// <summary>
        /// 有効であるか
        /// </summary>
#endif
        public bool Enabled { get { return (bool)this["Enabled"]().Core; } }

#if ENG
        /// <summary>
        /// Performs a click on the item.
        /// </summary>
#else
        /// <summary>
        /// クリックです。
        /// </summary>
#endif
        public void EmulateClick()
        {
            EmulateShow();
            App[typeof(FormsToolStripItem), "EmulateClickInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Performs a click on the item.
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
        public void EmulateClick(Async async)
        {
            EmulateShow();
            App[typeof(FormsToolStripItem), "EmulateClickInTarget", async](AppVar);
        }

#if ENG
        /// <summary>
        /// Show item.
        /// </summary>
#else
        /// <summary>
        /// 指定のアイテムを表示します
        /// </summary>
#endif
        public void EmulateShow()
        {
            App[typeof(FormsToolStripItem), "Show"](AppVar);
        }

#if ENG
        /// <summary>
        /// Hide item.
        /// </summary>
#else
        /// <summary>
        /// 指定のアイテムを非表示にします。
        /// </summary>
#endif
        public void EmulateHide()
        {
            App[typeof(FormsToolStripItem), "Hide"](AppVar);
        }

        /// <summary>
        /// クリックです。
        /// </summary>
        /// <param name="item">アイテム。</param>
        static void EmulateClickInTarget(ToolStripItem item)
        {
            if (item.Owner == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetToolStrip);
            }
            item.Owner.Focus();
            item.PerformClick();
        }

        static void Show(ToolStripMenuItem target)
        {
            var show = new List<MethodInvoker>();
            var hide = new List<MethodInvoker>();
            GetOpenClose(target, show, hide);
            foreach (var e in show)
            {
                e();
            }
        }

        static void Hide(ToolStripMenuItem target)
        {
            var show = new List<MethodInvoker>();
            var hide = new List<MethodInvoker>();
            GetOpenClose(target, show, hide);
            foreach (var e in hide)
            {
                e();
            }
        }


        static void GetOpenClose(ToolStripMenuItem target, List<MethodInvoker> show, List<MethodInvoker> hide)
        {
            var current = target;
            while (true)
            {
                if (current.OwnerItem != null && current.OwnerItem is ToolStripMenuItem i)
                {
                    show.Add(() => i.ShowDropDown());
                    hide.Add(() => i.HideDropDown());
                    current = i;
                }
                else
                {
                    if (current.Owner is ContextMenuStrip m)
                    {
                        show.Add(() => m.Show());
                        hide.Add(() => m.Hide());
                    }
                    break;
                }
            }
            show.Reverse();
        }
    }
}
