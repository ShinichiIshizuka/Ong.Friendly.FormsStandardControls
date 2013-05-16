using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
namespace Test
{
    /// <summary>
    /// NumericUpDown�e�X�g
    /// </summary>
    [TestFixture]
    public class NumericUpDown
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
        /// �N���b�N�e�X�g
        /// </summary>
        [Test]
        public void TestNumericUpDownButtonClick()
        {
            FormsNumericUpDown numericUpDown = new FormsNumericUpDown(app, testDlg["numericUpDown1"]());
            numericUpDown.EmulateUpClick();
            numericUpDown.EmulateUpClick();
            numericUpDown.EmulateUpClick();
            Assert.AreEqual(3, int.Parse(numericUpDown.Text));

            numericUpDown.EmulateDownClick();
            Assert.AreEqual(2, int.Parse(numericUpDown.Text));
            numericUpDown.EmulateDownClick();
            numericUpDown.EmulateDownClick();
        }

        /// <summary>
        /// �N���b�N�e�X�g
        /// </summary>
        [Test]
        public void TestNumericUpDownButtonAsyncClick()
        {
            FormsNumericUpDown numericUpDown = new FormsNumericUpDown(app, testDlg["numericUpDown1"]());
            numericUpDown.EmulateUpClick(new Async());
            numericUpDown.EmulateUpClick(new Async());
            numericUpDown.EmulateUpClick(new Async());
            Assert.AreEqual(3, int.Parse(numericUpDown.Text));

            numericUpDown.EmulateDownClick(new Async());
            Assert.AreEqual(2, int.Parse(numericUpDown.Text));
            numericUpDown.EmulateDownClick(new Async());
            numericUpDown.EmulateDownClick(new Async());
        }
    }
}
