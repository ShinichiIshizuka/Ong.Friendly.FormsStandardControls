using System;
using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
namespace Test
{
    /// <summary>
    /// RadioButton�e�X�g
    /// </summary>
    [TestFixture]
    public class RadioButtonTest
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
        public void TestRadioButtonCheck()
        {
            //��������
            FormsRadioButton radiobutton1 = new FormsRadioButton(app, testDlg["radioButton1"]());
            radiobutton1.EmulateCheck();
            Assert.AreEqual(true, radiobutton1.Checked);

            //�񓯊����s
            FormsRadioButton radiobutton2 = new FormsRadioButton(app, testDlg["radioButton2"]());
            radiobutton2.EmulateCheck(new Async());
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(11, count);
        }

        /// <summary>
        /// �e�L�X�g���擾���܂�
        /// </summary>
        [Test]
        public void TestRadioButtonTextGet()
        {
            FormsRadioButton radiobutton1 = new FormsRadioButton(app, testDlg["radioButton1"]());
            String radiobutton1Text = radiobutton1.Text;
            Assert.AreEqual("radioButton1", radiobutton1Text);
        }
    }
}
