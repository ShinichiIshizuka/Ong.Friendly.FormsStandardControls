using NUnit.Framework;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;

namespace Test
{
    //@@@class ���j���[�ƃc�[���X�g���b�v�̃e�X�g ���O�ς���B

    /// <summary>
    /// ContextMenuStrip�e�X�g
    /// </summary>
    [TestFixture]
    public class ContextMenuStripTest
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

        /// <summary>
        /// �N���b�N
        /// </summary>
        [Test]
        public void TestContextMenuStripClick1()
        {
            FormsToolStrip contextmenustrip1 = new FormsToolStrip(app, testDlg["contextMenuStrip1"]());
            contextmenustrip1.FindItem("MenuItem1").EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(1, count);
        }

        /// <summary>
        /// �N���b�N
        /// </summary>
        [Test]
        public void TestContextMenuStripClick2()
        {
            FormsToolStrip contextmenustrip1 = new FormsToolStrip(app, testDlg["contextMenuStrip1"]());
            contextmenustrip1.FindItem("MenuItem2").EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(2, count);
        }

        /// <summary>
        /// ���j���[�N���b�N
        /// </summary>
        [Test]
        public void TestMenuStripClickmenu001ToolStripMenuItem()
        {
            FormsToolStrip menustrip1 = new FormsToolStrip(app, testDlg["menuStrip1"]());
            FormsToolStripItem menuitem = menustrip1.FindItem("Menu001");
            menuitem.EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(100, count);
        }

        /// <summary>
        /// �T�u���j���[�N���b�N 
        /// </summary>
        [Test]
        public void TestMenuStripClickmenu00101ToolStripMenuItem()
        {
            FormsToolStrip menustrip1 = new FormsToolStrip(app, testDlg["menuStrip1"]());
            FormsToolStripItem menuitem1 = menustrip1.FindItem("Menu001", "Menu001-01");
            menuitem1.EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(101, count);
        }
    }
}
