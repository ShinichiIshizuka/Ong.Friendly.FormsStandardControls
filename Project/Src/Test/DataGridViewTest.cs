using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
namespace Test
{
    //@@@class

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
            datagridview1.EmulateChangeCellText(1, 1, "�ύX", new Async());
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

        /// <summary>
        /// �`�F�b�N��Ԑݒ�
        /// </summary>
        [Test]
        public void TestDataGridViewCheck()
        {
            FormsDataGridView datagridview2 = new FormsDataGridView(app, testDlg["dataGridView2"]());
            datagridview2.EmulateCellCheck(2, 1, true);
            datagridview2.EmulateCellCheck(2, 2, false, new Async());
            datagridview2.EmulateCellCheck(2, 3, true, new Async());
        }

        /// <summary>
        /// �Z���R���{����
        /// </summary>
        [Test]
        public void TestDataGridViewComboBox()
        {
            FormsDataGridView datagridview2 = new FormsDataGridView(app, testDlg["dataGridView2"]());
            datagridview2.EmulateChangeCellComboSelect(1, 1, 1);
            datagridview2.EmulateChangeCellComboSelect(1, 2, 2, new Async());
            datagridview2.EmulateChangeCellComboSelect(1, 3, 3, new Async());
        }

        /// <summary>
        /// �Z���{�^������
        /// </summary>
        [Test]
        public void TestDataGridViewButton()
        {
            FormsDataGridView datagridview2 = new FormsDataGridView(app, testDlg["dataGridView2"]());
            datagridview2.EmulateClickCellContent(0, 1);
            datagridview2.EmulateClickCellContent(0, 2, new Async());
            datagridview2.EmulateClickCellContent(0, 3, new Async());
        }
    }
}
