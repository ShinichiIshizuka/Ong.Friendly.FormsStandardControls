using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace FormsTest
{
    /// <summary>
    /// RadioButton�e�X�g
    /// </summary>
    [TestClass]
    public class RadioButtonTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// ������
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            //�e�X�g�p�̉�ʋN��
            app = new WindowsAppFriend(Process.Start(Settings.TestApplicationPath));
            testDlg = WindowControl.FromZTop(app);
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
        }

        /// <summary>
        /// �I��
        /// </summary>
        [TestCleanup]
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
        /// EmulateCheck
        /// Checked
        /// �̗������e�X�g
        /// </summary>
        [TestMethod]
        public void TestCheckBoxCheck()
        {
            FormsRadioButton radiobutton1 = new FormsRadioButton(testDlg["radioButton1"]());
            radiobutton1.EmulateCheck();
            Assert.AreEqual(true, radiobutton1.Checked);

            //�񓯊�
            FormsRadioButton radiobutton2 = new FormsRadioButton(testDlg["radioButton2"]());
            app[GetType(), "CheckedChangeEvent"](radiobutton2.AppVar);
            radiobutton2.EmulateCheck(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(11, count);
        }

        /// <summary>
        /// ��ԕύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="radioButton">�`�F�b�N�{�b�N�X</param>
        static void CheckedChangeEvent(RadioButton radioButton)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                radioButton.BeginInvoke((MethodInvoker)delegate
                {
                    radioButton.CheckedChanged -= handler;
                });
            };
            radioButton.CheckedChanged += handler;
        }
    }
}
