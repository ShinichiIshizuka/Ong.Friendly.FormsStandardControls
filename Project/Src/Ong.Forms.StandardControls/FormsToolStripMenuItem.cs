using Codeer.Friendly;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ツールストリップアイテム操作クラス
    /// </summary>
    public class FormsToolStripMenuItem : FormsToolStripItem
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="appVar">対象アプリケーション内変数操作クラス</param>
        public FormsToolStripMenuItem(AppVar appVar) : base(appVar) { }

        /// <summary>
        /// 子アイテムを取得します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <returns></returns>
        public FormsToolStripItem GetItem(int index)
        {
            return new FormsToolStripItem(this["DropDownItems"](index));
        }

        /// <summary>
        /// 子アイテムを取得します。
        /// </summary>
        /// <param name="key">キーとなるインデックスです。</param>
        /// <returns></returns>
        public FormsToolStripMenuItem GetItem(string key)
        {
            return new FormsToolStripMenuItem(this["DropDownItems"](key));
        }

        /// <summary>
        /// 表示文字列からアイテムを検索します。
        /// </summary>
        /// <param name="text">表示文字列</param>
        /// <returns>表示文字列</returns>
        public FormsToolStripMenuItem FindItem(string text)
        {
            foreach (AppVar element in new Enumerate(this["DropDownItems"]()))
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
