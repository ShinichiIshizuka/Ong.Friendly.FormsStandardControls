using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using Codeer.Friendly.Windows.NativeStandardControls;
using System.Windows.Forms;
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
            FormsNumericUpDownButtons numericUpDownButton = new FormsNumericUpDownButtons(app, testDlg["numericUpDown1"]());
            numericUpDownButton.EmulateUpClick();
            numericUpDownButton.EmulateUpClick();
            numericUpDownButton.EmulateUpClick();
            FormsNumericUpDownEdit numericUpDownEdit = new FormsNumericUpDownEdit(app, testDlg["numericUpDown1"]());
            Assert.AreEqual(3, int.Parse(numericUpDownEdit.Text));

            numericUpDownButton.EmulateDownClick();
            Assert.AreEqual(2, int.Parse(numericUpDownEdit.Text));
            numericUpDownButton.EmulateDownClick();
            numericUpDownButton.EmulateDownClick();
        }

        /// <summary>
        /// �N���b�N�e�X�g
        /// </summary>
        [Test]
        public void TestNumericUpDownButtonAsyncClick()
        {
            FormsNumericUpDownButtons numericUpDownButton = new FormsNumericUpDownButtons(app, testDlg["numericUpDown1"]());
            numericUpDownButton.EmulateUpClick(new Async());
            numericUpDownButton.EmulateUpClick(new Async());
            numericUpDownButton.EmulateUpClick(new Async());
            FormsNumericUpDownEdit numericUpDownEdit = new FormsNumericUpDownEdit(app, testDlg["numericUpDown1"]());
            Assert.AreEqual(3, int.Parse(numericUpDownEdit.Text));

            numericUpDownButton.EmulateDownClick(new Async());
            Assert.AreEqual(2, int.Parse(numericUpDownEdit.Text));
            numericUpDownButton.EmulateDownClick(new Async());
            numericUpDownButton.EmulateDownClick(new Async());
        }
    }
}
