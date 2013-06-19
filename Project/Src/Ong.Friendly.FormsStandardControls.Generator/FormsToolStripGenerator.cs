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
        List<MethodInvoker> _detachHandler = new List<MethodInvoker>();

        /// <summary>
        /// アタッチ。
        /// </summary>
        /// <param name="windowHandle">ウィンドウハンドル(WPFオブジェクトの場合はIntPtr.Zero)。</param>
        /// <param name="controlObject">コントロールのオブジェクト(ネイティブウィンドウの場合はnull)。</param>
        public override void Attach(IntPtr windowHandle, object controlObject)
        {
            _control = (ToolStrip)controlObject;
            for (int i = 0; i < _control.Items.Count; i++ )
            {
                ConnectEventHandler(new int[] { i }, _control.Items[i]);
            }
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
        protected override void Detach()
        {
            foreach (MethodInvoker element in _detachHandler)
            {
                element();
            }
            _detachHandler.Clear();
        }

        /// <summary>
        /// イベント
        /// </summary>
        /// <param name="from">至るまでのアイテムインデックス</param>
        /// <param name="item">アイテム</param>
        private void ConnectEventHandler(int[] from, ToolStripItem item)
        {
            ToolStripDropDownItem dropDown = item as ToolStripDropDownItem;
            if (dropDown != null && 0 < dropDown.DropDownItems.Count)
            {
                for (int i = 0; i < dropDown.DropDownItems.Count; i++)
                {
                    List<int> nextFrom = new List<int>(from);
                    nextFrom.Add(i);
                    ConnectEventHandler(nextFrom.ToArray(), dropDown.DropDownItems[i]);
                }
            }
            else
            {
                //チェックボタン
                if (AttachCheckButton(from, item))
                {
                    return;
                }
                //コンボ
                if (AttachCombo(from, item))
                {
                    return;
                }
                //テキストボックス
                if (AttachTextBox(from, item))
                {
                    return;
                }
                //クリックするメニュー
                AttachToolStripItem(from, item);
            }
        }

        /// <summary>
        /// ToolStripItemにアッタッチ
        /// </summary>
        /// <param name="from">至るまでのインデックス</param>
        /// <param name="item">アタッチ対象アイテム</param>
        private void AttachToolStripItem(int[] from, ToolStripItem item)
        {
            EventHandler click = delegate
            {
                AddSentence(new TokenName(), GetItemPath(from) + ".EmulateClick();");
            };
            item.Click += click;
            _detachHandler.Add(delegate { item.Click -= click; });
        }

        /// <summary>
        /// テキストボックスにアタッチ
        /// </summary>
        /// <param name="from">至るまでのインデックス</param>
        /// <param name="item">アタッチ対象アイテム</param>
        /// <returns>アタッチしたか</returns>
        private bool AttachTextBox(int[] from, ToolStripItem item)
        {
            ToolStripTextBox textBox = item as ToolStripTextBox;
            if (textBox != null)
            {
                //文字列変更
                EventHandler textChanged = delegate
                {
                    AddSentence("new FormsToolStripTextBox(", new TokenName(),
                        GetItemPath(from) + ").TextBox.EmulateChangeText(" + GenerateUtility.AdjustText(textBox.Text) + ");");
                };
                textBox.TextChanged += textChanged;
                _detachHandler.Add(delegate { textBox.TextChanged -= textChanged; });
                return true;
            }
            return false;
        }

        /// <summary>
        /// コンボボックスにアタッチ
        /// </summary>
        /// <param name="from">至るまでのインデックス</param>
        /// <param name="item">アタッチ対象アイテム</param>
        /// <returns>アタッチしたか</returns>
        private bool AttachCombo(int[] from, ToolStripItem item)
        {
            ToolStripComboBox combo = item as ToolStripComboBox;
            if (combo != null)
            {
                //選択変更
                EventHandler selectedIndexChanged = delegate
                {
                    AddSentence("new FormsToolStripComboBox(", new TokenName(),
                        GetItemPath(from) + ").ComboBox.EmulateChangeSelect(" + combo.SelectedIndex + ");");
                };
                combo.SelectedIndexChanged += selectedIndexChanged;
                _detachHandler.Add(delegate { combo.SelectedIndexChanged -= selectedIndexChanged; });

                //文字列変更
                EventHandler textChanged = delegate
                {
                    if (combo.SelectedIndex != -1)
                    {
                        if (combo.SelectedItem != null && combo.SelectedItem.ToString() == combo.Text)
                        {
                            return;
                        }
                    }
                    AddSentence("new FormsToolStripComboBox(", new TokenName(),
                        GetItemPath(from) + ").ComboBox.EmulateChangeText(" + GenerateUtility.AdjustText(combo.Text) + ");");
                };
                combo.TextChanged += textChanged;
                _detachHandler.Add(delegate { combo.TextChanged -= textChanged; });
                return true;
            }
            return false;
        }

        /// <summary>
        /// チェックボタンにアタッチ
        /// </summary>
        /// <param name="from">至るまでのインデックス</param>
        /// <param name="item">アタッチ対象アイテム</param>
        /// <returns>アタッチしたか</returns>
        private bool AttachCheckButton(int[] from, ToolStripItem item)
        {
            ToolStripButton button = item as ToolStripButton;
            if (button != null && button.CheckOnClick)
            {
                EventHandler checkStateChanged = delegate
                {
                    AddSentence("new FormsToolStripButton(", new TokenName(),
                        GetItemPath(from) + ").EmulateCheck(CheckState." + button.CheckState + ");");
                };
                button.CheckStateChanged += checkStateChanged;
                _detachHandler.Add(delegate { button.CheckStateChanged -= checkStateChanged; });
                return true;
            }
            return false;
        }

        /// <summary>
        /// アイテムまでのパスを取得
        /// </summary>
        /// <param name="from">至るまでのインデックス</param>
        /// <returns>パス</returns>
        private static string GetItemPath(int[] from)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(".GetItem(");
            bool first = true;
            foreach (int element in from)
            {
                if (!first)
                {
                    builder.Append(", ");
                }
                first = false;
                builder.Append(element);
            }
            builder.Append(")");
            return builder.ToString();
        }
    }
}
