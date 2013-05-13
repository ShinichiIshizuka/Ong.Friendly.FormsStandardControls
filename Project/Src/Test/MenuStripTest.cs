using NUnit.Framework;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
namespace Test
{
    /// <summary>
    /// MenuStrip�e�X�g
    /// </summary>
    [TestFixture]
    public class MenuStripTest
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
        /// ���j���[�N���b�N
        /// </summary>
        [Test]
        public void TestMenuStripClickmenu001ToolStripMenuItem()
        {
            FormsMenuStrip menustrip1 = new FormsMenuStrip(app, testDlg["menuStrip1"]());
            FormsToolStripMenuItem menuitem = menustrip1.FindItem("Menu001");
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
            FormsMenuStrip menustrip1 = new FormsMenuStrip(app, testDlg["menuStrip1"]());
            FormsToolStripMenuItem menuitem1 = menustrip1.FindItem("Menu001").FindItem("Menu001-01");
            menuitem1.EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(101, count);
        }
    }
}
