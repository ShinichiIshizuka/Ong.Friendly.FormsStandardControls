using System;
using System.Collections.Generic;
using System.Text;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// WindowControlがSystem.Windows.Forms.MenuStripのウィンドウに対応した操作を提供します
    /// </summary>
    public class FormsMenuStrip : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです</param>
        public FormsMenuStrip(FormsControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
 　     /// コンストラクタです
        /// </summary>
        /// <param name="app">アプリケーション操作クラス</param>
        /// <param name="appVar">アプリケーション内変数</param>
        public FormsMenuStrip(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// 表示文字列からアイテムを検索します。
        /// </summary>
        /// <param name="text">表示文字列</param>
        /// <returns>表示文字列</returns>
        public FormsToolStripMenuItem FindItem(string text)
        {
            foreach (AppVar element in new Enumerate(this["Items"]()))
            {
                if (element["Text"]().ToString() == text)
                {
                    return new FormsToolStripMenuItem(element);
                }
            }
            return null;
        }
    }
}