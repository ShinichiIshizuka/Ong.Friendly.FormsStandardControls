using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Drawing;
using System.Reflection;
using System;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��System.Windows.Forms.DataGridView�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsDataGridView : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsDataGridView(WindowControl src)
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
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        /// <returns>�e�L�X�g</returns>
        public string GetText(int col, int row)
        {
            return (string)(App[GetType(), "GetTextInTarget"](AppVar, col, row).Core);
        }

        /// <summary>
        /// �s��Ŏw�肵���Z���̃e�L�X�g���擾���܂�(����)
        /// </summary>
        /// <param name="datagridview">�f�[�^�O���b�h�r���[</param>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        /// <returns>�e�L�X�g</returns>
        private static string GetTextInTarget(DataGridView datagridview, int col, int row)
        {
            object obj = datagridview.Rows[row].Cells[col].Value;
            return obj != null ? obj.ToString() : string.Empty;
        }

        /// <summary>
        /// �Z���̃`�F�b�N��Ԃ����ɕύX����
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        public void EmulateToggleCellCheck(int col, int row)
        {
            EmulateChangeCurrentCell(col, row);
            this["OnKeyDown"](App.Dim(new NewInfo<KeyEventArgs>(Keys.Space)));
            this["OnKeyUp"](App.Dim(new NewInfo<KeyEventArgs>(Keys.Space)));
        }

        /// <summary>
        /// �Z���̃`�F�b�N��Ԃ����ɕύX����
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateToggleCellCheck(int col, int row, Async async)
        {
            EmulateChangeCurrentCell(col, row, new Async());
            this["OnKeyDown", new Async()](App.Dim(new NewInfo<KeyEventArgs>(Keys.Space)));
            this["OnKeyUp", async](App.Dim(new NewInfo<KeyEventArgs>(Keys.Space)));
        }

        /// <summary>
        /// �Z���̃e�L�X�g�ύX
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        /// <param name="text">�e�L�X�g</param>
        public void EmulateChangeCellText(int col, int row, string text)
        {
            App[GetType(), "EmulateChangeCellTextInTarget"](AppVar, col, row, text);
        }

        /// <summary>
        /// �Z���̃e�L�X�g�ύX
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        /// <param name="text">�e�L�X�g</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateChangeCellText(int col, int row, string text, Async async)
        {
            App[GetType(), "EmulateChangeCellTextInTarget", async](AppVar, col, row, text);
        }

        /// <summary>
        /// �Z���̃e�L�X�g�ύX
        /// </summary>
        /// <param name="grid">�O���b�h</param>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        /// <param name="text">�e�L�X�g</param>
        static void EmulateChangeCellTextInTarget(DataGridView grid, int col, int row, string text)
        {
            EmulateChangeCurrentCellInTarget(grid, col, row);
            grid.BeginEdit(false);
            grid.EditingControl.Text = text;
            grid.EndEdit();
        }

        /// <summary>
        /// �Z���R���{�I��ύX
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        /// <param name="index">�C���f�b�N�X</param>
        public void EmulateChangeCellComboSelect(int col, int row, int index)
        {
            App[GetType(), "EmulateChangeCellComboSelectInTarget"](AppVar, col, row, index);
        }

        /// <summary>
        /// �Z���R���{�I��ύX
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateChangeCellComboSelect(int col, int row, int index, Async async)
        {
            App[GetType(), "EmulateChangeCellComboSelectInTarget", async](AppVar, col, row, index);
        }

        /// <summary>
        /// �Z���R���{�I��ύX
        /// </summary>
        /// <param name="grid">�O���b�h</param>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        /// <param name="index">�C���f�b�N�X</param>
        static void EmulateChangeCellComboSelectInTarget(DataGridView grid, int col, int row, int index)
        {
            EmulateChangeCurrentCellInTarget(grid, col, row);
            grid.BeginEdit(false);
            ((ComboBox)grid.EditingControl).SelectedIndex = index;
            grid.EndEdit();
        }

        /// <summary>
        /// �Z���{�^���N���b�N
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        public void EmulateClickCellButton(int col, int row)
        {
            EmulateChangeCurrentCell(col, row);
            this["OnCellContentClick"](App.Dim(new NewInfo<DataGridViewCellEventArgs>(col, row)));
        }

        /// <summary>
        /// �Z���{�^���N���b�N
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        /// <param name="async"></param>
        public void EmulateClickCellButton(int col, int row, Async async)
        {
            EmulateChangeCurrentCell(col, row, new Async());
            this["OnCellContentClick", async](App.Dim(new NewInfo<DataGridViewCellEventArgs>(col, row)));
        }

        /// <summary>
        /// �Z�������N�N���b�N
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        public void EmulateClickCellLink(int col, int row)
        {
            EmulateChangeCurrentCell(col, row);
            this["OnCellContentClick"](App.Dim(new NewInfo<DataGridViewCellEventArgs>(col, row)));
        }

        /// <summary>
        /// �Z�������N�N���b�N
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateClickCellLink(int col, int row, Async async)
        {
            EmulateChangeCurrentCell(col, row, new Async());
            this["OnCellContentClick", async](App.Dim(new NewInfo<DataGridViewCellEventArgs>(col, row)));
        }

        /// <summary>
        /// �J�����g�Z����I��
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        public void EmulateChangeCurrentCell(int col, int row)
        {
            App[GetType(), "EmulateChangeCurrentCellInTarget"](AppVar, col, row);
        }

        /// <summary>
        /// �J�����g�Z����I��
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateChangeCurrentCell(int col, int row, Async async)
        {
            App[GetType(), "EmulateChangeCurrentCellInTarget", async](AppVar, col, row);
        }

        /// <summary>
        /// �J�����g�Z����I��
        /// </summary>
        /// <param name="grid">�O���b�h</param>
        /// <param name="col">��</param>
        /// <param name="row">�s</param>
        static void EmulateChangeCurrentCellInTarget(DataGridView grid, int col, int row)
        {
            grid.Focus();
            grid.Select();
            grid.CurrentCell = grid[col, row];
        }

        /// <summary>
        /// �I����ԉ���
        /// </summary>
        public void EmulateClearSelection()
        {
            this["ClearSelection"]();
        }

        /// <summary>
        /// �I����ԉ���
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateClearSelection(Async async)
        {
            this["ClearSelection", async]();
        }

        /// <summary>
        /// �I����ԕύX
        /// </summary>
        /// <param name="cells">�I���Z�����</param>
        public void EmulateChangeCellSelected(params CellSelectedInfo[] cells)
        {
            App[GetType(), "EmulateChangeCellSelectedInTarget"](AppVar, cells);
        }

        /// <summary>
        /// �I����ԕύX
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        /// <param name="cells">�I���Z�����</param>
        public void EmulateChangeCellSelected(Async async, params CellSelectedInfo[] cells)
        {
            App[GetType(), "EmulateChangeCellSelectedInTarget"](AppVar, cells);
        }

        /// <summary>
        /// �I����ԕύX
        /// </summary>
        /// <param name="grid">�O���b�h</param>
        /// <param name="cells">�I���Z�����</param>
        static void EmulateChangeCellSelectedInTarget(DataGridView grid, CellSelectedInfo[] cells)
        {
            grid.Focus();
            grid.Select();
            foreach (CellSelectedInfo cell in cells)
            {
                grid[cell.Col, cell.Row].Selected = cell.Selected;
            }
        }

        /// <summary>
        /// �s�I����ԕύX
        /// </summary>
        /// <param name="rows">�I���s���</param>
        public void EmulateChangeRowSelected(params RowSelectedInfo[] rows)
        {
            App[GetType(), "EmulateChangeRowSelectedInTarget"](AppVar, rows);
        }

        /// <summary>
        /// �s�I����ԕύX
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        /// <param name="rows">�I���s���</param>
        public void EmulateChangeRowSelected(Async async, params RowSelectedInfo[] rows)
        {
            App[GetType(), "EmulateChangeRowSelectedInTarget"](AppVar, rows);
        }

        /// <summary>
        /// �s�I����ԕύX
        /// </summary>
        /// <param name="grid">�O���b�h</param>
        /// <param name="rows">�I���s���</param>
        static void EmulateChangeRowSelectedInTarget(DataGridView grid, RowSelectedInfo[] rows)
        {
            grid.Focus();
            grid.Select();
            foreach (RowSelectedInfo row in rows)
            {
                grid.Rows[row.Row].Selected = row.Selected;
            }
        }

        /// <summary>
        /// Delete����G�~�����[�g
        /// </summary>
        public void EmulateDelete()
        {
            this["Focus"]();
            this["Select"]();
            this["OnKeyDown"](App.Dim(new NewInfo<KeyEventArgs>(Keys.Delete)));
            this["OnKeyUp"](App.Dim(new NewInfo<KeyEventArgs>(Keys.Delete)));
        }

        /// <summary>
        /// Delete����G�~�����[�g
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateDelete(Async async)
        {
            this["Focus", new Async()]();
            this["Select", new Async()]();
            this["OnKeyDown", new Async()](App.Dim(new NewInfo<KeyEventArgs>(Keys.Delete)));
            this["OnKeyUp", async](App.Dim(new NewInfo<KeyEventArgs>(Keys.Delete)));
        }
    }
}