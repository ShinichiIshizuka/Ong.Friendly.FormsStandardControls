using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがWindowControlがSystem.Windows.Forms.TextBoxのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsProgressBar : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
        public FormsProgressBar(WindowControl src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsProgressBar(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// 最小値です。
        /// </summary>
        public int Min
        {
            get { return (int)this["Minimum"]().Core; }
        }

        /// <summary>
        /// 最大値です。 
        /// </summary>
        public int Max
        {
            get { return (int)this["Maximum"]().Core; }
        }

        /// <summary>
        /// 現在位置です。  
        /// </summary>
        public int Pos
        {
            get { return (int)this["Value"]().Core; }
        }
    }
}