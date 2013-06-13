using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsButtonGenerator : IDisposable
    {
        string _name;
        List<string> _code;
        Button _control;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="handle">ウィンドウハンドル</param>
        /// <param name="name">変数名称</param>
        /// <param name="code">コード</param>
        public FormsButtonGenerator(IntPtr handle, string name, List<string> code)
        {
            _name = name;
            _code = code;
            _control = (Button)Control.FromHandle(handle);
            _control.Click += ButtonClick;
        }

        /// <summary>
        /// ボタン押下
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void ButtonClick(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                _code.Add(_name + ".EmulateClick();");
            }
        }     
        /// <summary>
		/// ファイナライザ
		/// </summary>
        ~FormsButtonGenerator()
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
                _control.Click -= ButtonClick;
            }
		}
    }
}
