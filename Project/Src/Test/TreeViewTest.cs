using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using Codeer.Friendly.Windows.NativeStandardControls;

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

        /// <summary>
        /// FormsTreeNode SelectNodeのテスト
        /// </summary>
        [Test]
        public void TestFormsTreeNodeSelectNode()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode node = treeView1.FindItem("Parent", "Child 1");
            treeView1.EmulateNodeSelect(node);
            FormsTreeNode selectedNode = treeView1.SelectNode;
            Assert.AreEqual("Child 1", selectedNode.Text);
        }

        /// <summary>
        /// FormsTreeNode GetItem(params int[] indexes)のテスト
        /// </summary>
        [Test]
        public void TestFormsTreeNodeGetItemIndexs()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode item = treeView1.GetItem(0, 1);
            Assert.AreEqual(@"Child 2", item.Text);
        }

        /// <summary>
        /// FormsTreeNode GetItem(params string[] keys)のテスト
        /// </summary>
        public void TestFormsTreeNodeGetItemKeys()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode item = treeView1.GetItem(@"Parent", @"Child 2", @"GrandChild");
            Assert.AreEqual(@"GrandChild", item.Text);
        }

        /// <summary>
        /// FormsTreeNode FindItem(params string[] texts)のテスト
        /// </summary>
        [Test]
        public void TestFormsTreeNodeFindItemTexts()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            string[] texts = { @"Parent" };
            FormsTreeNode item = treeView1.FindItem(texts);
            Assert.AreEqual(@"Parent", item.Text);
        }

        /// <summary>
        /// EmulateNodeSelect(FormsTreeNode node)のテスト
        /// </summary>
        [Test]
        public void TestEmulateNodeSelectNode()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode item = treeView1.FindItem("Parent");
            treeView1.EmulateNodeSelect(item);
            FormsTreeNode selectitem = treeView1.SelectNode;
            Assert.AreEqual("Parent", selectitem.Text);

            //非同期
            app[GetType(), "TreeViewAfterSelectEvent"](treeView1.AppVar);
            FormsTreeNode item2 = treeView1.GetItem(0, 1);
            treeView1.EmulateNodeSelect(item2, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            FormsTreeNode selectitem2 = treeView1.SelectNode;
            Assert.AreEqual("Child 2", selectitem2.Text);
        }

        /// <summary>
        /// 選択時にメッセージボックスを表示する
        /// </summary>
        /// <param name="treeView">ツリービュー</param>
        static void TreeViewAfterSelectEvent(TreeView treeView)
        {
            TreeViewEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                treeView.BeginInvoke((MethodInvoker)delegate
                {
                    treeView.AfterSelect -= handler;
                });
            };
            treeView.AfterSelect += handler;
        }

        /// <summary>
        /// string Textのテスト
        /// </summary>
        [Test]
        public void TestStringText()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode item = treeView1.FindItem("Parent");
            treeView1.EmulateNodeSelect(item);
            FormsTreeNode selectitem = treeView1.SelectNode;
            Assert.AreEqual("Parent", selectitem.Text);
        }

        /// <summary>
        /// bool IsExpandedのテスト
        /// </summary>
        [Test]
        public void TestIsExpanded()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode item = treeView1.FindItem("Parent");
            item.EmulateExpand();
            Assert.AreEqual(true, item.IsExpanded);
        }

        /// <summary>
        /// bool Checkedのテスト
        /// </summary>
        [Test]
        public void TestChecked()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode item = treeView1.FindItem("Parent");
            item.EmulateCheck(true);
            Assert.AreEqual(true, item.Checked);
        }

        /// <summary>
        /// EmulateExpandのテスト
        /// </summary>
        [Test]
        public void TestEmulateExpand()
        {
            //非同期
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            app[GetType(), "TreeViewAfterExpandEvent"](treeView1.AppVar);
            FormsTreeNode item = treeView1.FindItem("Parent");
            item.EmulateCollapse(new Async()); 
            item.EmulateExpand(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(true, item.IsExpanded);
        }

        /// <summary>
        /// Expand時にメッセージボックスを表示する
        /// </summary>
        /// <param name="treeView">ツリービュー</param>
        static void TreeViewAfterExpandEvent(TreeView treeView)
        {
            TreeViewEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                treeView.BeginInvoke((MethodInvoker)delegate
                {
                    treeView.AfterExpand -= handler;
                });
            };
            treeView.AfterExpand += handler;
        }

        /// <summary>
        /// EmulateCollapseのテスト
        /// </summary>
        [Test]
        public void TestEmulateCollapse()
        {
            //非同期
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            app[GetType(), "TreeViewAfterCollapse"](treeView1.AppVar);
            FormsTreeNode item = treeView1.FindItem("Parent");
            item.EmulateCollapse(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(false, item.IsExpanded);
        }

        /// <summary>
        /// Collapse時にメッセージボックスを表示する
        /// </summary>
        /// <param name="treeView">ツリービュー</param>
        static void TreeViewAfterCollapse(TreeView treeView)
        {
            TreeViewEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                treeView.BeginInvoke((MethodInvoker)delegate
                {
                    treeView.AfterCollapse -= handler;
                });
            };
            treeView.AfterCollapse += handler;
        }

        /// <summary>
        /// EmulateEditLabelのテスト
        /// </summary>
        [Test]
        public void TestEmulateEditLabel()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode item = treeView1.FindItem("Parent");
            item.EmulateEditLabel(@"ChangeText");
            Assert.AreEqual(@"ChangeText", item.Text);

            //非同期
            app[GetType(), "TreeViewAfterLabelEditEvent"](treeView1.AppVar);
            item.EmulateEditLabel(@"Parent", new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(@"Parent", item.Text);
        }

        /// <summary>
        /// EditLabel時にメッセージボックスを表示する
        /// </summary>
        /// <param name="treeView">ツリービュー</param>
        static void TreeViewAfterLabelEditEvent(TreeView treeView)
        {
            NodeLabelEditEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                treeView.BeginInvoke((MethodInvoker)delegate
                {
                    treeView.AfterLabelEdit -= handler;
                });
            };
            treeView.AfterLabelEdit += handler;
        }
    }
}
