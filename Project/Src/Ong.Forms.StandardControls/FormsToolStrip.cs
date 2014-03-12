using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.ToolStrip.
    /// </summary>
#else
    /// <summary>
    /// ツールストリップです。
    /// </summary>
#endif
    public class FormsToolStrip : FormsControlBase
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
        public FormsToolStrip(WindowControl src)
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
        public FormsToolStrip(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Retrieves the item matching the specified series of key indices values.
        /// </summary>
        /// <param name="indexes">Series of indices leading to the item to retrieve.</param>
        /// <returns>Found child item.</returns>
#else
        /// <summary>
        /// 子アイテムを取得します。
        /// </summary>
        /// <param name="indexes">インデックス。</param>
        /// <returns>子アイテム</returns>
#endif
        public FormsToolStripItem GetItem(params int[] indexes)
        {
            return new FormsToolStripItem(App, App[GetType(), "GetItemInTarget"](AppVar, indexes));
        }

#if ENG
        /// <summary>
        /// Retrieves the item matching the specified series of key values.
        /// </summary>
        /// <param name="keys">Key values.</param>
        /// <returns>Found child item.</returns>
#else
        /// <summary>
        /// 子アイテムを取得します。
        /// </summary>
        /// <param name="keys">キーとなる文字列です。</param>
        /// <returns>子アイテム。</returns>
#endif
        public FormsToolStripItem GetItem(params string[] keys)
        {
            return new FormsToolStripItem(App, App[GetType(), "GetItemInTarget"](AppVar, keys));
        }

#if ENG
        /// <summary>
        /// Retrieves the item matching the specified series of display values.
        /// </summary>
        /// <param name="texts">Display values.</param>
        /// <returns>Found child item.</returns>
#else
        /// <summary>
        /// 表示文字列からアイテムを検索します。
        /// </summary>
        /// <param name="texts">表示文字列。</param>
        /// <returns>表示文字列。</returns>
#endif
        public FormsToolStripItem FindItem(params string[] texts)
        {
            return new FormsToolStripItem(App, App[GetType(), "FindItemInTarget"](AppVar, texts));
        }

        /// <summary>
        /// アイテムを取得します。
        /// </summary>
        /// <param name="toolStrip">ツールストリップ。</param>
        /// <param name="indexes">インデックス。</param>
        /// <returns>アイテム。</returns>
        static ToolStripItem GetItemInTarget(ToolStrip toolStrip, params int[] indexes)
        {
            int currentIndex = 0;
            ToolStripItemCollection items = toolStrip.Items;
            while (true)
            {
                ToolStripItem current = items[indexes[currentIndex]];
                if (indexes.Length - 1 == currentIndex)
                {
                    return current;
                }
                else
                {
                    currentIndex++;
                }
                ToolStripDropDownItem dropDown = current as ToolStripDropDownItem;
                if (dropDown == null)
                {
                    return null;
                }
                items = dropDown.DropDownItems;
            }
        }

        /// <summary>
        /// アイテムを取得します。
        /// </summary>
        /// <param name="toolStrip">ツールストリップ。</param>
        /// <param name="keys">インデックス。</param>
        /// <returns>アイテム。</returns>
        static ToolStripItem GetItemInTarget(ToolStrip toolStrip, params string[] keys)
        {
            int currentIndex = 0;
            ToolStripItemCollection items = toolStrip.Items;
            while (true)
            {
                ToolStripItem current = items[keys[currentIndex]];
                if (keys.Length - 1 == currentIndex)
                {
                    return current;
                }
                else
                {
                    currentIndex++;
                }
                ToolStripDropDownItem dropDown = current as ToolStripDropDownItem;
                if (dropDown == null)
                {
                    return null;
                }
                items = dropDown.DropDownItems;
            }
        }

        /// <summary>
        /// 表示文字列からアイテムを検索します。
        /// </summary>
        /// <param name="toolStrip">ツールストリップ。</param>
        /// <param name="texts">表示文字列。</param>
        /// <returns>アイテム。</returns>
        static ToolStripItem FindItemInTarget(ToolStrip toolStrip, string[] texts)
        {
            int currentIndex = 0;
            ToolStripItemCollection items = toolStrip.Items;
            while (true)
            {
                ToolStripItem current = null;
                foreach (ToolStripItem element in items)
                {
                    if (element.Text == texts[currentIndex])
                    {
                        if (texts.Length - 1 == currentIndex)
                        {
                            return element;
                        }
                        else
                        {
                            current = element;
                            currentIndex++;
                            break;
                        }
                    }
                }
                ToolStripDropDownItem dropDown = current as ToolStripDropDownItem;
                if (dropDown == null)
                {
                    return null;
                }
                items = dropDown.DropDownItems;
            }
        }
    }
}
