using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormsStandardControls
{
    //@@@�R���g���[���̖��O�Ƃ����t�@�N�^�����O

    public partial class FormControls : Form
    {
        /// <summary>
        /// ���������m�F�p�ϐ�
        /// </summary>
        int async_counter = 0;
        
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public FormControls()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���[�h��
        /// </summary>
        /// <param name="sender">�R�[����</param>
        /// <param name="e">�C�x���g�p�����^</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            InitTreeView();
            InitListView();
            InitDataGrid();
            //ToolStripMenuItem item = (ToolStripMenuItem)menustrip.Items[""];
            //ToolStripItem a =item.DropDownItems[""];
        }

        private void InitDataGrid()
        {
            // �e�[�u�����쐬
            DataSet dataSet1 = new DataSet("���i�}�X�^�[");
            DataTable dataTable1 = dataSet1.Tables.Add("���i�e�[�u��");
            DataColumn dataClumn1 = dataTable1.Columns.Add("ID", typeof(int));
            DataColumn dataClumn2 = dataTable1.Columns.Add("���i");
            DataColumn dataClumn3 = dataTable1.Columns.Add("��", typeof(int));

            // �e�[�u���Ƀf�[�^��ǉ�
            dataTable1.Rows.Add(new Object[] { 1, "�݂���", 100 });
            dataTable1.Rows.Add(new Object[] { 2, "�p�C�i�b�v��", 300 });
            dataTable1.Rows.Add(new Object[] { 3, "�o�i�i", 120 });
            dataTable1.Rows.Add(new Object[] { 4, "������", 280 });
            dataTable1.Rows.Add(new Object[] { 5, "������", 200 });
            dataTable1.Rows.Add(new Object[] { 6, "������", 150 });

            // �f�[�^�O���b�h�̍s�̒ǉ��ƍ폜��s���A�f�[�^�ҏW�����ɂ���
            dataTable1.DefaultView.AllowNew = false;
            dataTable1.DefaultView.AllowDelete = false;
            dataTable1.DefaultView.AllowEdit = true;

            // �f�[�^�O���b�h�Ƀe�[�u����\������
            // �i�f�[�^�\�[�X��DataView���g���j
            dataGridView1.DataSource = dataTable1.DefaultView;

            // �e�[�u�����쐬
            DataSet dataSet2 = new DataSet("���i�}�X�^�[");
            DataTable dataTable2 = dataSet2.Tables.Add("���i�e�[�u��");
            DataColumn dataClumn21 = dataTable2.Columns.Add("ID", typeof(int));
            DataColumn dataClumn22 = dataTable2.Columns.Add("���i");
            DataColumn dataClumn23 = dataTable2.Columns.Add("��", typeof(int));

            //DataGridViewButtonColumn�̍쐬
            DataGridViewButtonColumn ButtonColumn = new DataGridViewButtonColumn();
            ButtonColumn.Name = "Button";
            ButtonColumn.UseColumnTextForButtonValue = true;
            ButtonColumn.Text = "�{�^��";
            dataGridView2.Columns.Add(ButtonColumn); 
            
            DataGridViewComboBoxColumn ComboColumn = new DataGridViewComboBoxColumn();
            //ComboBox�̃��X�g�ɕ\�����鍀�ڂ�ݒ肷��
            ComboColumn.Items.Add("���j��");
            ComboColumn.Items.Add("���j��");
            ComboColumn.Items.Add("�Ηj��");
            ComboColumn.Items.Add("���j��");
            ComboColumn.Items.Add("�ؗj��");
            ComboColumn.Items.Add("���j��");
            ComboColumn.Items.Add("�y�j��");
            dataGridView2.Columns.Add(ComboColumn);

            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            dataGridView2.Columns.Add(column);

            // �e�[�u���Ƀf�[�^��ǉ�
            dataTable2.Rows.Add(new Object[] { 1, "�݂���", 100 });
            dataTable2.Rows.Add(new Object[] { 2, "�p�C�i�b�v��", 300 });
            dataTable2.Rows.Add(new Object[] { 3, "�o�i�i", 120 });
            dataTable2.Rows.Add(new Object[] { 4, "������", 280 });
            dataTable2.Rows.Add(new Object[] { 5, "������", 200 });
            dataTable2.Rows.Add(new Object[] { 6, "������", 150 });

            // �f�[�^�O���b�h�̍s�̒ǉ��ƍ폜��s���A�f�[�^�ҏW�����ɂ���
            dataTable2.DefaultView.AllowNew = false;
            dataTable2.DefaultView.AllowDelete = false;
            dataTable2.DefaultView.AllowEdit = true;

            // �f�[�^�O���b�h�Ƀe�[�u����\������
            // �i�f�[�^�\�[�X��DataView���g���j
            dataGridView2.DataSource = dataTable2.DefaultView;
        }

        /// <summary>
        /// �c���[�r���[������
        /// </summary>
        private void InitTreeView()
        {
            treeView1.Nodes.Add("Parent");
            treeView1.Nodes[0].Nodes.Add("Child 1");
            treeView1.Nodes[0].Nodes.Add("Child 2");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");

            TreeNode tn = treeView1.Nodes[0].Nodes[0];
            treeView1.SelectedNode = tn;

            treeView2.Nodes.Add("Parent");
            treeView2.Nodes[0].Nodes.Add("Child 1");
            treeView2.Nodes[0].Nodes.Add("Child 2");
            treeView2.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            treeView2.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
        }

        /// <summary>
        /// ���X�g�r���[������
        /// </summary>
        private void InitListView()
        {
            // ListView�R���g���[���̃v���p�e�B��ݒ�
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Ascending;
            listView1.View = View.Details;

            // ��i�R�����j�w�b�_�̍쐬
            ColumnHeader columnName = new ColumnHeader();
            ColumnHeader columnType = new ColumnHeader();
            ColumnHeader columnData = new ColumnHeader();
            columnName.Text = "���O";
            columnName.Width = 100;
            columnType.Text = "���";
            columnType.Width = 60;
            columnData.Text = "�f�[�^";
            columnData.Width = 150;
            ColumnHeader[] colHeaderRegValue =
            { columnName, columnType, columnData };
            listView1.Columns.AddRange(colHeaderRegValue);

            // ListView�R���g���[���̃f�[�^�����ׂď������܂��B
            listView1.Items.Clear();
            // ListView�R���g���[���Ƀf�[�^��ǉ����܂��B
            string[] item1 = { "�����S", "�ʕ�", "��" };
            listView1.Items.Add(new ListViewItem(item1));
            string[] item2 = { "������", "�ʕ�", "��" };
            listView1.Items.Add(new ListViewItem(item2));
            string[] item3 = { "�s�[�}��", "���", "��" };
            listView1.Items.Add(new ListViewItem(item3));
            string[] item4 = { "�g�}�g", "���", "��" };
            listView1.Items.Add(new ListViewItem(item4));
        }
        
        /// <summary>
        /// �{�^���N���b�N
        /// </summary>
        /// <param name="sender">�R�[����</param>
        /// <param name="e">�C�x���g�p�����^</param>
        private void button1_Click(object sender, EventArgs e)
        {
            async_counter++;
        }

        /// <summary>
        /// �{�^���N���b�N
        /// </summary>
        /// <param name="sender">�R�[����</param>
        /// <param name="e">�C�x���g�p�����^</param>
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button2Click");
        }

        /// <summary>
        /// �`�F�b�N�{�b�N�X�ύX
        /// </summary>
        /// <param name="sender">�R�[����</param>
        /// <param name="e">�C�x���g�p�����^</param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            async_counter = 10;
        }

        /// <summary>
        /// �`�F�b�N�{�b�N�X�ύX
        /// </summary>
        /// <param name="sender">�R�[����</param>
        /// <param name="e">�C�x���g�p�����^</param>
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("CheckBox2Click");
        }

        /// <summary>
        /// ���W�I�{�^���`�F�b�N
        /// </summary>
        /// <param name="sender">�R�[����</param>
        /// <param name="e">�C�x���g�p�����^</param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            async_counter = 10;
        }

        /// <summary>
        /// ���W�I�{�^���`�F�b�N
        /// </summary>
        /// <param name="sender">�R�[����</param>
        /// <param name="e">�C�x���g�p�����^</param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            async_counter = 11;
        }

        private void menuItem1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            async_counter = 1;
        }

        private void menuItem2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            async_counter++;
        }

        private void menu00101ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            async_counter = 101;
        }

        private void menu001ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            async_counter = 100;

            ToolStripItem a = menuStrip1.Items[0];
        }
    }
}