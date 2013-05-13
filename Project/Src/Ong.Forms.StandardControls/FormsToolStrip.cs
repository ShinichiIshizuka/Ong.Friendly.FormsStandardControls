using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ツールストリップ
    /// </summary>
    public class FormsToolStrip : WindowControl
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
        /// <param name="index">インデックス。</param>
        /// <returns></returns>
        public FormsToolStripItem GetItem(int index)
        {
            return new FormsToolStripItem(this["Items"](index));
        }

        /// <summary>
        /// 子アイテムを取得します。
        /// </summary>
        /// <param name="key">キーとなるインデックスです。</param>
        /// <returns></returns>
        public FormsToolStripItem GetItem(string key)
        {
            return new FormsToolStripItem(this["Items"](key));
        }

        /// <summary>
        /// 表示文字列からアイテムを検索します。
        /// </summary>
        /// <param name="text">表示文字列</param>
        /// <returns>表示文字列</returns>
        public FormsToolStripItem FindItem(string text)
        {
            foreach (AppVar element in new Enumerate(this["Items"]()))
            {
                if (element["Text"]().ToString() == text)
                {
                    return new FormsToolStripItem(element);
                }
            }
            return null;
        }
    }
}
