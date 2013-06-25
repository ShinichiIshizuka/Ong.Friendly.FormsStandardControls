using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
namespace Test
{
    /// <summary>
    /// TabControl�e�X�g
    /// </summary>
    [TestFixture]
    public class TabControlTest
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
        /// TabCount�e�X�g
        /// </summary>
        [Test]
        public void TestTabCount()
        {
            FormsTabControl tabcontrol1 = new FormsTabControl(app, testDlg["tabControl1"]());
            Assert.AreEqual(3, tabcontrol1.TabCount);
        }

        /// <summary>
        /// SelectedIndex�e�X�g
        /// </summary>
        [Test]
        public void TestSelectedIndex()
        {
            FormsTabControl tabcontrol1 = new FormsTabControl(app, testDlg["tabControl1"]());
            tabcontrol1.EmulateTabSelect(2);
            Assert.AreEqual(2, tabcontrol1.SelectedIndex);
        }

        /// <summary>
        /// EmulateTabSelect
        /// @@@�񓯊�
        /// </summary>
        [Test]
        public void TestTabSelect()
        {
            FormsTabControl tabcontrol1 = new FormsTabControl(app, testDlg["tabControl1"]());
            tabcontrol1.EmulateTabSelect(2,new Async());
        }
    }
}
