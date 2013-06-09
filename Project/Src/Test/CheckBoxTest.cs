using System;
using NUnit.Framework;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using Codeer.Friendly;
namespace Test
{
    /// <summary>
    /// CheckBox�e�X�g
    /// </summary>
    [TestFixture]
    public class CheckBoxTest
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
        /// �`�F�b�N�e�X�g
        /// </summary>
        [Test]
        public void TestCheckBoxCheck()
        {
            FormsCheckBox checkbox1 = new FormsCheckBox(app, testDlg["checkBox1"]());
            checkbox1.EmulateCheck(CheckState.Checked);
            Assert.AreEqual(CheckState.Checked, checkbox1.CheckState);

            checkbox1.EmulateCheck(CheckState.Unchecked,new Async());
            Assert.AreEqual(CheckState.Unchecked, checkbox1.CheckState);
        }

        /// <summary>
        /// �e�L�X�g���擾���܂�
        /// </summary>
        [Test]
        public void TestCheckBoxTextGet()
        {
            FormsCheckBox checkBox1 = new FormsCheckBox(app, testDlg["checkBox1"]());
            String checkBox1Text = checkBox1.Text;
            Assert.AreEqual("checkBox1", checkBox1Text);

            checkBox1Text = checkBox1.Text;
            Assert.AreEqual("checkBox1", checkBox1Text);
        }
    }
}
