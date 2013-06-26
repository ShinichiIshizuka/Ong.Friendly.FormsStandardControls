using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormsStandardControls
{
    //@@@コントロールの名前とかリファクタリング

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
            InitDataGrid();
            //ToolStripMenuItem item = (ToolStripMenuItem)menustrip.Items[""];
            //ToolStripItem a =item.DropDownItems[""];
        }

        private void InitDataGrid()
        {
            // テーブルを作成
            DataSet dataSet1 = new DataSet("商品マスター");
            DataTable dataTable1 = dataSet1.Tables.Add("商品テーブル");
            DataColumn dataClumn1 = dataTable1.Columns.Add("ID", typeof(int));
            DataColumn dataClumn2 = dataTable1.Columns.Add("商品");
            DataColumn dataClumn3 = dataTable1.Columns.Add("個数", typeof(int));

            // テーブルにデータを追加
            dataTable1.Rows.Add(new Object[] { 1, "みかん", 100 });
            dataTable1.Rows.Add(new Object[] { 2, "パイナップル", 300 });
            dataTable1.Rows.Add(new Object[] { 3, "バナナ", 120 });
            dataTable1.Rows.Add(new Object[] { 4, "すいか", 280 });
            dataTable1.Rows.Add(new Object[] { 5, "いちご", 200 });
            dataTable1.Rows.Add(new Object[] { 6, "メロン", 150 });

            // データグリッドの行の追加と削除を不許可、データ編集を許可にする
            dataTable1.DefaultView.AllowNew = false;
            dataTable1.DefaultView.AllowDelete = false;
            dataTable1.DefaultView.AllowEdit = true;

            // データグリッドにテーブルを表示する
            // （データソースにDataViewを使う）
            dataGridView1.DataSource = dataTable1.DefaultView;

            // テーブルを作成
            DataSet dataSet2 = new DataSet("商品マスター");
            DataTable dataTable2 = dataSet2.Tables.Add("商品テーブル");
            DataColumn dataClumn21 = dataTable2.Columns.Add("ID", typeof(int));
            DataColumn dataClumn22 = dataTable2.Columns.Add("商品");
            DataColumn dataClumn23 = dataTable2.Columns.Add("個数", typeof(int));

            //DataGridViewButtonColumnの作成
            DataGridViewButtonColumn ButtonColumn = new DataGridViewButtonColumn();
            ButtonColumn.Name = "Button";
            ButtonColumn.UseColumnTextForButtonValue = true;
            ButtonColumn.Text = "ボタン";
            dataGridView2.Columns.Add(ButtonColumn); 
            
            DataGridViewComboBoxColumn ComboColumn = new DataGridViewComboBoxColumn();
            //ComboBoxのリストに表示する項目を設定する
            ComboColumn.Items.Add("日曜日");
            ComboColumn.Items.Add("月曜日");
            ComboColumn.Items.Add("火曜日");
            ComboColumn.Items.Add("水曜日");
            ComboColumn.Items.Add("木曜日");
            ComboColumn.Items.Add("金曜日");
            ComboColumn.Items.Add("土曜日");
            dataGridView2.Columns.Add(ComboColumn);

            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            dataGridView2.Columns.Add(column);

            // テーブルにデータを追加
            dataTable2.Rows.Add(new Object[] { 1, "みかん", 100 });
            dataTable2.Rows.Add(new Object[] { 2, "パイナップル", 300 });
            dataTable2.Rows.Add(new Object[] { 3, "バナナ", 120 });
            dataTable2.Rows.Add(new Object[] { 4, "すいか", 280 });
            dataTable2.Rows.Add(new Object[] { 5, "いちご", 200 });
            dataTable2.Rows.Add(new Object[] { 6, "メロン", 150 });

            // データグリッドの行の追加と削除を不許可、データ編集を許可にする
            dataTable2.DefaultView.AllowNew = false;
            dataTable2.DefaultView.AllowDelete = false;
            dataTable2.DefaultView.AllowEdit = true;

            // データグリッドにテーブルを表示する
            // （データソースにDataViewを使う）
            dataGridView2.DataSource = dataTable2.DefaultView;
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
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            async_counter = 10;
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