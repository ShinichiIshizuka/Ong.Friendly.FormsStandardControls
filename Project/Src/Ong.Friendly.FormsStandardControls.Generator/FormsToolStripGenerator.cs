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
                ConnectEventHandler(new string[] { _control.Items[i].Text }, new int[] { i }, _control.Items[i]);
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
        /// <param name="fromIndex">至るまでのアイテムインデックス</param>
        /// <param name="item">アイテム</param>
        private void ConnectEventHandler(string[] fromText, int[] fromIndex, ToolStripItem item)
        {
            ToolStripDropDownItem dropDown = item as ToolStripDropDownItem;
            if (dropDown != null && 0 < dropDown.DropDownItems.Count)
            {
                for (int i = 0; i < dropDown.DropDownItems.Count; i++)
                {
                    List<string> nextFromText = new List<string>(fromText);
                    nextFromText.Add(dropDown.DropDownItems[i].Text);
                    List<int> nextFromIndex = new List<int>(fromIndex);
                    nextFromIndex.Add(i);
                    ConnectEventHandler(nextFromText.ToArray(), nextFromIndex.ToArray(), dropDown.DropDownItems[i]);
                }
            }
            else
            {
                //チェックボタン
                if (AttachCheckButton(fromText, fromIndex, item))
                {
                    return;
                }
                //コンボ
                if (AttachCombo(fromText, fromIndex, item))
                {
                    return;
                }
                //テキストボックス
                if (AttachTextBox(fromText, fromIndex, item))
                {
                    return;
                }
                //クリックするメニュー
                AttachToolStripItem(fromText, fromIndex, item);
            }
        }

        /// <summary>
        /// ToolStripItemにアッタッチ
        /// </summary>
        /// <param name="fromText">至るまでのテキスト</param>
        /// <param name="fromIndex">至るまでのインデックス</param>
        /// <param name="item">アタッチ対象アイテム</param>
        private void AttachToolStripItem(string[] fromText, int[] fromIndex, ToolStripItem item)
        {
            EventHandler click = delegate
            {
                AddSentence(new TokenName(), GetItemPath(fromText, fromIndex) + ".EmulateClick(", new TokenAsync(CommaType.Non), ");");
            };
            item.Click += click;
            _detachHandler.Add(delegate { item.Click -= click; });
        }

        /// <summary>
        /// テキストボックスにアタッチ
        /// </summary>
        /// <param name="fromText">至るまでのテキスト</param>
        /// <param name="fromIndex">至るまでのインデックス</param>
        /// <param name="item">アタッチ対象アイテム</param>
        /// <returns>アタッチしたか</returns>
        private bool AttachTextBox(string[] fromText, int[] fromIndex, ToolStripItem item)
        {
            ToolStripTextBox textBox = item as ToolStripTextBox;
            if (textBox != null)
            {
                //文字列変更
                EventHandler textChanged = delegate
                {
                    AddSentence("new FormsToolStripTextBox(", new TokenName(),
                        GetItemPath(fromText, fromIndex) + ").TextBox.EmulateChangeText(" + GenerateUtility.AdjustText(textBox.Text), new TokenAsync(CommaType.Before), ");");
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
        /// <param name="fromText">至るまでのテキスト</param>
        /// <param name="fromIndex">至るまでのインデックス</param>
        /// <param name="item">アタッチ対象アイテム</param>
        /// <returns>アタッチしたか</returns>
        private bool AttachCombo(string[] fromText, int[] fromIndex, ToolStripItem item)
        {
            ToolStripComboBox combo = item as ToolStripComboBox;
            if (combo != null)
            {
                //選択変更
                EventHandler selectedIndexChanged = delegate
                {
                    AddSentence("new FormsToolStripComboBox(", new TokenName(),
                        GetItemPath(fromText, fromIndex) + ").ComboBox.EmulateChangeSelect(" + combo.SelectedIndex, new TokenAsync(CommaType.Before), ");");
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
                        GetItemPath(fromText, fromIndex) + ").ComboBox.EmulateChangeText(" + GenerateUtility.AdjustText(combo.Text), new TokenAsync(CommaType.Before), ");");
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
        /// <param name="fromText">至るまでのテキスト</param>
        /// <param name="fromIndex">至るまでのインデックス</param>
        /// <param name="item">アタッチ対象アイテム</param>
        /// <returns>アタッチしたか</returns>
        private bool AttachCheckButton(string[] fromText, int[] fromIndex, ToolStripItem item)
        {
            ToolStripButton button = item as ToolStripButton;
            if (button != null && button.CheckOnClick)
            {
                EventHandler checkStateChanged = delegate
                {
                    AddSentence("new FormsToolStripButton(", new TokenName(),
                        GetItemPath(fromText, fromIndex) + ").EmulateCheck(CheckState." + button.CheckState, new TokenAsync(CommaType.Before), ");");
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
        /// <param name="fromText">至るまでのテキスト</param>
        /// <param name="fromIndex">至るまでのインデックス</param>
        /// <returns>パス</returns>
        private static string GetItemPath(string[] fromText, int[] fromIndex)
        {
            bool textMode = true;
            foreach (string element in fromText)
            {
                if (string.IsNullOrEmpty(element))
                {
                    textMode = false;
                    break;
                }
            }
            return (textMode) ? GetItemPathText(fromText) : GetItemPathIndex(fromIndex);
        }

        /// <summary>
        /// アイテムまでのパスを取得
        /// </summary>
        /// <param name="fromText">至るまでのテキスト</param>
        /// <returns>パス</returns>
        private static string GetItemPathText(string[] fromText)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(".FindItem(");
            bool first = true;
            foreach (string element in fromText)
            {
                if (!first)
                {
                    builder.Append(", ");
                }
                first = false;
                builder.Append(GenerateUtility.AdjustText(element));
            }
            builder.Append(")");
            return builder.ToString();
        }

        /// <summary>
        /// アイテムまでのパスを取得
        /// </summary>
        /// <param name="fromIndex">至るまでのインデックス</param>
        /// <returns>パス</returns>
        private static string GetItemPathIndex(int[] fromIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(".GetItem(");
            bool first = true;
            foreach (int element in fromIndex)
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
