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
        /// 同期処理確認用変数
        /// </summary>
        int async_counter = 0;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormControls()
        {
            InitializeComponent();
            _columnFormat.ValueType = typeof(decimal);
        }

        /// <summary>
        /// ロード時
        /// </summary>
        /// <param name="sender">コール元</param>
        /// <param name="e">イベントパラメタ</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            InitTreeView();
            InitListView();
        }

        /// <summary>
        /// ツリービュー初期化
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
        /// リストビュー初期化
        /// </summary>
        private void InitListView()
        {
            // ListViewコントロールのプロパティを設定
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Ascending;
            listView1.View = View.Details;

            // 列（コラム）ヘッダの作成
            ColumnHeader columnName = new ColumnHeader();
            ColumnHeader columnType = new ColumnHeader();
            ColumnHeader columnData = new ColumnHeader();
            columnName.Text = "名前";
            columnName.Width = 100;
            columnType.Text = "種類";
            columnType.Width = 60;
            columnData.Text = "データ";
            columnData.Width = 150;
            ColumnHeader[] colHeaderRegValue =
            { columnName, columnType, columnData };
            listView1.Columns.AddRange(colHeaderRegValue);

            // ListViewコントロールのデータをすべて消去します。
            listView1.Items.Clear();
            // ListViewコントロールにデータを追加します。
            string[] item1 = { "リンゴ", "果物", "赤" };
            listView1.Items.Add(new ListViewItem(item1));
            string[] item2 = { "メロン", "果物", "緑" };
            listView1.Items.Add(new ListViewItem(item2));
            string[] item3 = { "ピーマン", "野菜", "緑" };
            listView1.Items.Add(new ListViewItem(item3));
            string[] item4 = { "トマト", "野菜", "赤" };
            listView1.Items.Add(new ListViewItem(item4));
        }
        
        /// <summary>
        /// ボタンクリック
        /// </summary>
        /// <param name="sender">コール元</param>
        /// <param name="e">イベントパラメタ</param>
        private void button1_Click(object sender, EventArgs e)
        {
            async_counter++;
        }

        /// <summary>
        /// ボタンクリック
        /// </summary>
        /// <param name="sender">コール元</param>
        /// <param name="e">イベントパラメタ</param>
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button2Click");
        }

        /// <summary>
        /// チェックボックス変更
        /// </summary>
        /// <param name="sender">コール元</param>
        /// <param name="e">イベントパラメタ</param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            async_counter = 10;
        }

        /// <summary>
        /// チェックボックス変更
        /// </summary>
        /// <param name="sender">コール元</param>
        /// <param name="e">イベントパラメタ</param>
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("CheckBox2Click");
        }

        /// <summary>
        /// ラジオボタンチェック
        /// </summary>
        /// <param name="sender">コール元</param>
        /// <param name="e">イベントパラメタ</param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            async_counter = 11;
        }

        /// <summary>
        /// リンクラベルクリック
        /// </summary>
        /// <param name="sender">コール元</param>
        /// <param name="e">イベントパラメタ</param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            async_counter = 12;
        }

        private void Menu001ToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            menu00103ToolStripMenuItem.Enabled = true;
            menu00104ToolStripMenuItem.Enabled = true;
        }

        private void Menu001ToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            menu00103ToolStripMenuItem.Enabled = false;
            menu00104ToolStripMenuItem.Enabled = false;
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            menuItem3ToolStripMenuItem.Enabled = true;
            menuItem4ToolStripMenuItem.Enabled = true;
        }

        private void ContextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            menuItem3ToolStripMenuItem.Enabled = false;
            menuItem4ToolStripMenuItem.Enabled = false;
        }

        bool _item00104Clicked;
        private void Menu00104ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _item00104Clicked = true;
        }

        bool _item4Clicked;
        private void MenuItem4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _item4Clicked = true;
        }
    }
}