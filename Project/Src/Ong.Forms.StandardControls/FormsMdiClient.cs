using Codeer.Friendly;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.MdiClient.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.MdiClientのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.MdiClient")]
    public class FormsMdiClient : FormsControlBase
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
        public FormsMdiClient(WindowControl src)
            : base(src) { }
        
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
        public FormsMdiClient(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Activate MdiChild with specified text.
        /// </summary>
        /// <param name="text">Text to use.</param>
#else
        /// <summary>
        /// 指定のテキストを持つMdiChildをアクティブにします
        /// </summary>
        /// <param name="text">テキスト。</param>
#endif
        public void EmulateChangeActiveMdiChild(string text)
            => App[GetType(), "EmulateChangeActiveMdiChild"](this, text);

#if ENG
        /// <summary>
        /// Activate MdiChild with specified text.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="text">Text to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 指定のテキストを持つMdiChildをアクティブにします。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateChangeActiveMdiChild(string text, Async async)
            => App[GetType(), "EmulateChangeActiveMdiChild"](this, text, async);

#if ENG
        /// <summary>
        /// Activate MdiChild with the specified index.
        /// </summary>
        /// <param name="index">Item index.</param>
#else
        /// <summary>
        /// 指定のインデックスのMdiChildをアクティブにします。
        /// </summary>
        /// <param name="index">インデックス。</param>
#endif
        public void EmulateChangeActiveMdiChild(int index)
            => App[GetType(), "EmulateChangeActiveMdiChild"](this, index);

#if ENG
        /// <summary>
        /// Activate MdiChild with the specified index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Item index.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 指定のインデックスのMdiChildをアクティブにします。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateChangeActiveMdiChild(int index, Async async)
            => App[GetType(), "EmulateChangeActiveMdiChild"](this, index, async);

        static void EmulateChangeActiveMdiChild(MdiClient client, string text)
        {
            foreach (var f in GetParentForm(client).MdiChildren)
            {
                if (f.Text == text)
                {
                    f.Activate();
                    return;
                }
            }
        }

        static void EmulateChangeActiveMdiChild(MdiClient client, int index)
            => GetParentForm(client).MdiChildren[index].Activate();

        static Form GetParentForm(Control c)
        {
            while (c != null && !(c is Form)) c = c.Parent;
            return c as Form;
        }
    }
}
