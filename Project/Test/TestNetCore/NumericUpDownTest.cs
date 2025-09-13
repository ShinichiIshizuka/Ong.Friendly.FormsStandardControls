
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace TestNetCore
{
    /// <summary>
    /// NumericUpDown�e�X�g
    /// </summary>
    
    public class NumericUpDownTest
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
        /// EmulateChangeValue��Value�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeValueAndValue()
        {
            FormsNumericUpDown numericUpDown = new FormsNumericUpDown(testDlg["numericUpDown"]());
            numericUpDown.EmulateChangeValue(50);
            Assert.AreEqual(50, numericUpDown.Value);

            // �񓯊�
            app[GetType(), "ValueChangedEvent"](numericUpDown.AppVar);
            numericUpDown.EmulateChangeValue(80, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(80, numericUpDown.Value);
        }

        /// <summary>
        /// Minimum�̃e�X�g
        /// </summary>
        [Test]
        public void TestMinimum()
        {
            FormsNumericUpDown numericUpDown = new FormsNumericUpDown(testDlg["numericUpDown"]());
            Assert.AreEqual(0, numericUpDown.Minimum);
        }

        /// <summary>
        /// Maximum�̃e�X�g
        /// </summary>
        [Test]
        public void TestMaximum()
        {
            FormsNumericUpDown numericUpDown = new FormsNumericUpDown(testDlg["numericUpDown"]());
            Assert.AreEqual(100, numericUpDown.Maximum);
        }

        /// <summary>
        /// �ύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="numericupdown">NumericUpDown</param>
        static void ValueChangedEvent(NumericUpDown numericupdown)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                numericupdown.BeginInvoke((MethodInvoker)delegate
                {
                    numericupdown.ValueChanged -= handler;
                });
            };
            numericupdown.ValueChanged += handler;
        }
    }
}
