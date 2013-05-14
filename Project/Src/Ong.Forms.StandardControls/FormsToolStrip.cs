using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ツールストリップ
    /// </summary>
    public class FormsToolStrip : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロールです。</param>
        public FormsToolStrip(WindowControl src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
		/// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="windowHandle">ウィンドウハンドル。</param>
        public FormsToolStrip(WindowsAppFriend app, AppVar windowHandle)
            : base(app, windowHandle) { }

        /// <summary>
        /// 子アイテムを取得します。
        /// </summary>
        /// <param name="indexs">インデックス。</param>
        /// <returns>子アイテム</returns>
        public FormsToolStripItem GetItem(params int[] indexs)
        {
            return new FormsToolStripItem(App, App[GetType(), "GetItemInTarget"](AppVar, indexs));
        }

        /// <summary>
        /// 子アイテムを取得します。
        /// </summary>
        /// <param name="keys">キーとなるインデックスです。</param>
        /// <returns>子アイテム</returns>
        public FormsToolStripItem GetItem(params string[] keys)
        {
            return new FormsToolStripItem(App, App[GetType(), "GetItemInTarget"](AppVar, keys));
        }

        /// <summary>
        /// 表示文字列からアイテムを検索します。
        /// </summary>
        /// <param name="texts">表示文字列。</param>
        /// <returns>表示文字列。</returns>
        public FormsToolStripItem FindItem(params string[] texts)
        {
            return new FormsToolStripItem(App, App[GetType(), "FindItemInTarget"](AppVar, texts));
        }

        /// <summary>
        /// アイテムを取得します。
        /// </summary>
        /// <param name="toolStrip">ツールストリップ。</param>
        /// <param name="indexs">インデックス。</param>
        /// <returns>アイテム。</returns>
        static ToolStripItem GetItemInTarget(ToolStrip toolStrip, params int[] indexs)
        {
            int currentIndex = 0;
            ToolStripItemCollection items = toolStrip.Items;
            while (true)
            {
                ToolStripItem current = items[indexs[currentIndex]];
                if (indexs.Length - 1 == currentIndex)
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
