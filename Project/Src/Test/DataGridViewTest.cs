using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
namespace Test
{
    /// <summary>
    /// DataGridView�e�X�g
    /// </summary>
    [TestFixture]
    public class DataGridViewTest
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
        /// �s���Ɨ񐔐��擾
        /// </summary>
        [Test]
        public void TestDataGridViewRowColCount()
        {
            FormsDataGridView datagridview1 = new FormsDataGridView(app, testDlg["dataGridView1"]());
            Assert.AreEqual(6, datagridview1.RowCount);
            Assert.AreEqual(3, datagridview1.ColumnCount);
        }

        /// <summary>
        /// �w�肵���s��̃e�L�X�g�ύX
        /// </summary>
        [Test]
        public void TestDataGridViewChangeText()
        {
            FormsDataGridView datagridview1 = new FormsDataGridView(app, testDlg["dataGridView1"]());
            datagridview1.EmulateChangeText(1, 1, "�ύX",new Async());
        }

        /// <summary>
        /// �w�肵���s��̃e�L�X�g�擾
        /// </summary>
        [Test]
        public void TestDataGridViewGetText()
        {
            FormsDataGridView datagridview1 = new FormsDataGridView(app, testDlg["dataGridView1"]());
            Assert.AreEqual("�ύX", datagridview1.GetText(1, 1));
        }
    }
}
