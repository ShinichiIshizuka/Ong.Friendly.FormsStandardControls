using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsListBoxGenerator : IDisposable
    {
        string _name;
        List<string> _code;
        ListBox _control;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="handle">ウィンドウハンドル</param>
        /// <param name="name">変数名称</param>
        /// <param name="code">コード</param>
        public FormsListBoxGenerator(IntPtr handle, string name, List<string> code)
        {
            _name = name;
            _code = code;
            _control = (ListBox)Control.FromHandle(handle);
            _control.SelectedIndexChanged += SelectedIndexChanged;
        }

        /// <summary>
        /// 選択インデックスが変化した
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
		/// ファイナライザ
		/// </summary>
        ~FormsListBoxGenerator()
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
                _control.SelectedIndexChanged -= SelectedIndexChanged;
            }
		}
    }
}
