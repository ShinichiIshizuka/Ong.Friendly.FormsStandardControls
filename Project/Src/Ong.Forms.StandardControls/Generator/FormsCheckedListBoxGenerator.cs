using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsCheckedListBoxGenerator : IDisposable
    {
        string _name;
        List<string> _code;
        CheckedListBox _control;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="handle">ウィンドウハンドル</param>
        /// <param name="name">変数名称</param>
        /// <param name="code">コード</param>
        public FormsCheckedListBoxGenerator(IntPtr handle, string name, List<string> code)
        {
            _name = name;
            _code = code;
            _control = (CheckedListBox)Control.FromHandle(handle);
            _control.ItemCheck += ItemCheck;
            _control.SelectedIndexChanged += SelectedIndexChanged;
        }

        /// <summary>
        /// 選択インデックスが変わったイベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                _code.Add(_name + ".EmulateChangeSelectedIndex(" + _control.SelectedIndex + ");");
            }
        }

        /// <summary>
        /// チェック状態変更
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_control.Focused)
            {
                _code.Add(_name + ".EmulateCheckState(" + e.Index + ", CheckState." + e.NewValue + ");");
            }
        }

        /// <summary>
		/// ファイナライザ
		/// </summary>
        ~FormsCheckedListBoxGenerator()
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
                _control.ItemCheck -= ItemCheck;
                _control.SelectedIndexChanged -= SelectedIndexChanged;
            }
		}
    }
}
