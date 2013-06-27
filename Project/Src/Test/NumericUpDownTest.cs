using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace Test
{
    /// <summary>
    /// NumericUpDown�e�X�g
    /// </summary>
    [TestFixture]
    public class NumericUpDownTest
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
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
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

        /*
        /// <summary>
        /// �N���b�N�e�X�g
        /// </summary>
        [Test]
        public void TestNumericUpDownButtonClick()
        {
            FormsNumericUpDown numericUpDown = new FormsNumericUpDown(app, testDlg["numericUpDown1"]());
            numericUpDown.EmulateUp();
            numericUpDown.EmulateUp();
            numericUpDown.EmulateUp();
            Assert.AreEqual(3, int.Parse(numericUpDown.Text));

            numericUpDown.EmulateDown();
            Assert.AreEqual(2, int.Parse(numericUpDown.Text));
            numericUpDown.EmulateDown();
            numericUpDown.EmulateDown();
        }

        /// <summary>
        /// EmulateUp�AEmulateDown
        /// </summary>
        [Test]
        public void TestNumericUpDown()
        {
            FormsNumericUpDown numericUpDown = new FormsNumericUpDown(app, testDlg["numericUpDown1"]());
            numericUpDown.EmulateUp(new Async());
            numericUpDown.EmulateUp(new Async());
            numericUpDown.EmulateUp(new Async());
            Assert.AreEqual(3, int.Parse(numericUpDown.Text));

            // �񓯊�
            app[GetType(), "ValueChangedEvent"](numericUpDown.AppVar);
            numericUpDown.EmulateDown(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK"); 
            Assert.AreEqual(2, int.Parse(numericUpDown.Text));
            numericUpDown.EmulateDown();
            numericUpDown.EmulateDown();
        }

        /// <summary>
        /// EmulateChangeText�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeText()
        {
            FormsNumericUpDown numericUpDown = new FormsNumericUpDown(app, testDlg["numericUpDown1"]());
            numericUpDown.EmulateChangeText(@"13");
            Assert.AreEqual(@"13", numericUpDown.Text);

            // �񓯊�
            app[GetType(), "ValueChangedEvent"](numericUpDown.AppVar);
            numericUpDown.EmulateChangeText(@"56", new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(@"56", numericUpDown.Text);

            numericUpDown.EmulateChangeText(@"");
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
        }*/
    }
}
