using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// WindowControl��System.Windows.Forms.DataGridView�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsDataGridView : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsDataGridView(FormsControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsDataGridView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �񐔂��擾���܂��B
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return (int)(this["ColumnCount"]().Core);
            }
        }

        /// <summary>
        /// �s�����擾���܂��B
        /// </summary>
        public int RowCount
        {
            get
            {
                return (int)(this["RowCount"]().Core);
            }
        }

        /// <summary>
        /// �s��Ŏw�肵���Z���̃e�L�X�g���擾���܂�
        /// </summary>
        /// <param name="row">�s</param>
        /// <param name="col">��</param>
        /// <returns>�e�L�X�g</returns>
        public string GetText(int row, int col)
        {
            return (string)(App[GetType(), "GetTextInTarget"](AppVar, row, col).Core);
        }

        /// <summary>
        /// �s��Ŏw�肵���Z���̃e�L�X�g���擾���܂�(����)
        /// </summary>
        /// <param name="datagridview">�f�[�^�O���b�h�r���[</param>
        /// <param name="row">�s</param>
        /// <param name="col">��</param>
        /// <returns>�e�L�X�g</returns>
        private static string GetTextInTarget(DataGridView datagridview, int row, int col)
        {
            return (string)(datagridview.Rows[row].Cells[col].Value);
        }

        /// <summary>
        /// �w�肵���s��̃e�L�X�g��ύX���܂�
        /// </summary>
        /// <param name="row">�s</param>
        /// <param name="col">��</param>
        /// <param name="text">�e�L�X�g</param>
        public void EmulateChangeText(int row, int col, string text)
        {
            App[GetType(), "EmulateChangeTextInTarget"](AppVar, row, col, text);
        }

        /// <summary>
        /// �w�肵���s��̃e�L�X�g��ύX���܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="row">�s</param>
        /// <param name="col">��</param>
        /// <param name="text">�e�L�X�g</param>
        /// <param name="async">�񓯊�����I�u�W�F�N�g</param>
        public void EmulateChangeText(int row, int col, string text, Async async)
        {
            App[GetType(), "EmulateChangeTextInTarget", async](AppVar, row, col, text);
        }

        /// <summary>
        /// �w�肵���s��̃e�L�X�g��ύX���܂�(����)
        /// </summary>
        /// <param name="datagridview">�f�[�^�O���b�h�r���[</param>
        /// <param name="row">�s</param>
        /// <param name="col">��</param>
        /// <param name="text">�e�L�X�g</param>
        private static void EmulateChangeTextInTarget(DataGridView datagridview, int row, int col, string text)
        {
            datagridview.Rows[row].Cells[col].Value = text;
        }
    }
}