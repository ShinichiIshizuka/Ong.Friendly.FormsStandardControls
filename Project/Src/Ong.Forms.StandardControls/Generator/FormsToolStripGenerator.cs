using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsToolStripGenerator : IDisposable
    {
        string _name;
        List<string> _code;
        ToolStrip _control;
        List<KeyValuePair<ToolStripItem, EventHandler>> _itemEvents = new List<KeyValuePair<ToolStripItem, EventHandler>>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="handle">ウィンドウハンドル</param>
        /// <param name="name">変数名称</param>
        /// <param name="code">コード</param>
        public FormsToolStripGenerator(IntPtr handle, string name, List<string> code)
        {
            _name = name;
            _code = code;
            _control = (ToolStrip)Control.FromHandle(handle);
            foreach (ToolStripItem element in _control.Items)
            {
                ConnectEventHandler(new string[] { element.Text }, element);
            }
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
                    builder.Append(_name + ".FindItem(");
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
                    _code.Add(builder.ToString());
                };
                item.Click += click;
                _itemEvents.Add(new KeyValuePair<ToolStripItem, EventHandler>(item, click));
            }
        }

        /// <summary>
        /// ファイナライザ
        /// </summary>
        ~FormsToolStripGenerator()
        {
            Dispose(false);
        }

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 破棄
        /// </summary>
        /// <param name="disposing">破棄フラグ</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (KeyValuePair<ToolStripItem, EventHandler> element in _itemEvents)
                {
                    element.Key.Click -= element.Value;
                }
                _itemEvents.Clear();
            }
        }
    }
}
