using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;

namespace Test
{
    /// <summary>
    /// TreeView�e�X�g
    /// </summary>
    [TestFixture]
    public class TreeViewTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// ������
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            //�e�X�g�p�̉�ʋN��
            app = new WindowsAppFriend(Process.Start(Settings.TestApplicationPath), "2.0");
            testDlg = WindowControl.FromZTop(app);
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
        }

        /// <summary>
        /// �I��
        /// </summary>
        [TestFixtureTearDown]
        public void TearDown()
        {
            //�I������
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
        /// �m�[�h���e�L�X�g�Ō������đI�����܂�
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
        /// ���ݑI������Ă���m�[�h�̃e�L�X�g���擾���܂�
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
        /// �m�[�h���e�L�X�g�Ō������đI�����܂�
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
        /// �m�[�h���e�L�X�g�Ō������ēW�J�������ƕ��܂�
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
        /// �m�[�h���x����ҏW���܂�
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
        /// �m�[�h���`�F�b�N���܂�
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
