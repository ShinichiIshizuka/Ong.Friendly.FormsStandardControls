using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コンボボックスのコード生成
    /// </summary>
    public class FormsComboBoxGenerator : IDisposable
    {
        string _name;
        List<string> _code;
        ComboBox _control;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="handle">ウィンドウハンドル</param>
        /// <param name="name">変数名称</param>
        /// <param name="code">コード</param>
        public FormsComboBoxGenerator(IntPtr handle, string name, List<string> code)
        {
            _name = name;
            _code = code;
            _control = (ComboBox)Control.FromHandle(handle);
            _control.TextChanged += ComboBoxTextChanged;
            _control.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
        }

        /// <summary>
        /// 選択インデックス変更
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                _code.Add(_name + ".EmulateChangeSelect(" + _control.SelectedIndex + ");");
            }
        }

        /// <summary>
        /// テキスト変化イベント
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void ComboBoxTextChanged(object sender, EventArgs e)
        {
            if (_control.Focused && _control.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                _code.Add(_name + ".EmulateChangeText(\"" +  GenerateUtility.AdjustText(_control.Text) + "\");");
            }
        }
        
        /// <summary>
		/// ファイナライザ
		/// </summary>
        ~FormsComboBoxGenerator()
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
                _control.TextChanged -= ComboBoxTextChanged;
                _control.SelectedIndexChanged -= ComboBoxSelectedIndexChanged;
            }
		}

        /// <summary>
        /// コードの最適化。
        /// </summary>
        /// <param name="list">コードリスト。</param>
        public void optimize_generated_code(List<string> list)
        {
            GenerateUtility.RemoveDuplicationFunction(_name, list, "EmulateChangeText");
        }
    }
}
