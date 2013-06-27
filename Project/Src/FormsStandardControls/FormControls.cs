using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormsStandardControls
{
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
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            async_counter = 11;
        }
    }
}