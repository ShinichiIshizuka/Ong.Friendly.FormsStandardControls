using System;

using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace TestNetCore
{
    /// <summary>
    /// CheckBox�e�X�g
    /// </summary>
    
    public class CheckBoxTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// ������
        /// </summary>
        [SetUp]
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
        [TearDown]
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
        /// CheckState
        /// �̗������e�X�g
        /// </summary>
        [Test]
        public void TestCheckBoxCheck()
        {
            FormsCheckBox checkbox = new FormsCheckBox(testDlg["checkBox"]());
            checkbox.EmulateCheck(CheckState.Checked);
            Assert.AreEqual(CheckState.Checked, checkbox.CheckState);

            //�񓯊�
            app[GetType(), "CheckedChangeEvent"](checkbox.AppVar);
            checkbox.EmulateCheck(CheckState.Unchecked, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(CheckState.Unchecked, checkbox.CheckState);
        }

        /// <summary>
        /// ��ԕύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="checkBox">�`�F�b�N�{�b�N�X</param>
        static void CheckedChangeEvent(CheckBox checkBox)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                checkBox.BeginInvoke((MethodInvoker)delegate
                {
                    checkBox.CheckedChanged -= handler;
                });
            };
            checkBox.CheckedChanged += handler;
        }
    }
}
