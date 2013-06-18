using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsToolStripGenerator : GeneratorBase
    {
        ToolStrip _control;
        List<KeyValuePair<ToolStripItem, EventHandler>> _itemEvents = new List<KeyValuePair<ToolStripItem, EventHandler>>();

        /// <summary>
        /// アタッチ。
        /// </summary>
        /// <param name="windowHandle">ウィンドウハンドル(WPFオブジェクトの場合はIntPtr.Zero)。</param>
        /// <param name="controlObject">コントロールのオブジェクト(ネイティブウィンドウの場合はnull)。</param>
        public override void Attach(IntPtr windowHandle, object controlObject)
        {
            _control = (ToolStrip)controlObject;
            foreach (ToolStripItem element in _control.Items)
            {
                ConnectEventHandler(new string[] { element.Text }, element);
            }
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
        protected override void Detach()
        {
            foreach (KeyValuePair<ToolStripItem, EventHandler> element in _itemEvents)
            {
                element.Key.Click -= element.Value;
            }
            _itemEvents.Clear();
        }

        /// <summary>
        /// イベント
        /// </summary>
        /// <param name="from">至るまでのアイテム文字列</param>
        /// <param name="item">アイテム</param>
        private void ConnectEventHandler(string[] from, ToolStripItem item)
        {
            ToolStripDropDownItem dropDown = item as ToolStripDropDownItem;
            if (dropDown != null && 0 < dropDown.DropDownItems.Count)
            {
                foreach (ToolStripItem element in dropDown.DropDownItems)
                {
                    List<string> nextFrom = new List<string>(from);
                    nextFrom.Add(element.Text);
                    ConnectEventHandler(nextFrom.ToArray(), element);
                }
            }
            else
            {
                EventHandler click = delegate
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(".FindItem(");
                    bool first = true;
                    foreach (string element in from)
                    {
                        if (!first)
                        {
                            builder.Append(", ");
                        }
                        first = false;
                        builder.Append("\"" + element + "\"");
                    }
                    builder.Append(").EmulateClick();");
                    AddSentence(new TokenName(), builder.ToString());
                };
                item.Click += click;
                _itemEvents.Add(new KeyValuePair<ToolStripItem, EventHandler>(item, click));
            }
        }
    }
}
