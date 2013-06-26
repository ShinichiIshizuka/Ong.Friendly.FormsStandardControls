using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;

namespace Test
{
    /// <summary>
    /// TreeViewテスト
    /// </summary>
    [TestFixture]
    public class TreeViewTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// 初期化
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            //テスト用の画面起動
            app = new WindowsAppFriend(Process.Start(Settings.TestApplicationPath), "2.0");
            testDlg = WindowControl.FromZTop(app);
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
        }

        /// <summary>
        /// 終了
        /// </summary>
        [TestFixtureTearDown]
        public void TearDown()
        {
            //終了処理
            if (app != null)
            {
                app.Dispose();
                Process process = Process.GetProcessById(app.ProcessId);
                process.CloseMainWindow();
                app = null;
            }
        }

        //@@@
        // public FormsTreeNode SelectNode
        //public FormsTreeNode GetItem(params int[] indexs)
        // public FormsTreeNode GetItem(params string[] keys)
        // public FormsTreeNode FindItem(params string[] texts)
        //public void EmulateNodeSelect(FormsTreeNode node)

        //public string Text
        //public bool IsExpanded
        //public bool Checked

        //EmulateExpand
        //EmulateCollapse

        //EmulateEditLabel


        /*
        /// <summary>
        /// ノードをテキストで検索して選択します
        /// </summary>
        [Test]
        public void TestTreeViewFindNodeAndSelect()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode node = treeView1.FindItem("Parent","Child 2");
            Assert.NotNull(node);
            treeView1.EmulateNodeSelect(node, new Async());
        }

        /// <summary>
        /// 現在選択されているノードのテキストを取得します
        /// </summary>
        [Test]
        public void TestTreeViewSelectNodeText()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode node = treeView1.FindItem("Parent","Child 1");
            Assert.NotNull(node);
            treeView1.EmulateNodeSelect(node, new Async());
            FormsTreeNode selectedNode = treeView1.SelectNode;
            Assert.AreEqual("Child 1", selectedNode.Text);
        }

        /// <summary>
        /// ノードをテキストで検索して選択します
        /// </summary>
        [Test]
        public void TestTreeViewFindNodeAndSelectAndExpand()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode node = treeView1.FindItem("Parent","Child 2");
            Assert.NotNull(node);
            treeView1.EmulateNodeSelect(node, new Async());
            node.EmulateExpand();
        }

        /// <summary>
        /// ノードをテキストで検索して展開したあと閉じます
        /// </summary>
        [Test]
        public void TestTreeViewFindNodeAndSelectAndExpandCollapse()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode node = treeView1.FindItem("Parent","Child 2");
            Assert.NotNull(node);
            treeView1.EmulateNodeSelect(node, new Async());
            node.EmulateExpand();
            Assert.AreEqual(true, node.IsExpanded);
            node.EmulateCollapse();
            Assert.AreEqual(false, node.IsExpanded);
            node.EmulateExpand(new Async());
            Assert.AreEqual(true, node.IsExpanded);
            node.EmulateCollapse(new Async());
            Assert.AreEqual(false, node.IsExpanded);
        }

        /// <summary>
        /// ノードラベルを編集します
        /// </summary>
        [Test]
        public void TestTreeViewEditLabel()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode node = treeView1.FindItem("Parent","Child 2");
            Assert.NotNull(node);
            node.EmulateEditLabel("ChangeText");
            Assert.AreEqual("ChangeText", node.Text);
            node.EmulateEditLabel("Child 2", new Async());
            Assert.AreEqual("Child 2", node.Text);
        }

        /// <summary>
        /// ノードをチェックします
        /// </summary>
        [Test]
        public void TestTreeViewCheck()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode node = treeView1.FindItem("Parent","Child 2");
            Assert.NotNull(node);
            node.EmulateCheck(true);
            Assert.IsTrue(node.Checked);
            node.EmulateCheck(false,new Async());
            Assert.IsFalse(node.Checked);
        }*/
    }
}
