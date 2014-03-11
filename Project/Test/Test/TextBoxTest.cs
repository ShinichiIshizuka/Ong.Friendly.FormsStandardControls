using System;
using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace Test
{
    /// <summary>
    /// TextBox�e�X�g
    /// </summary>
    [TestFixture]
    public class TextBoxTest
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

        /// <summary>
        /// �e�L�X�g�ݒ�E�擾�����܂�
        /// </summary>
        [Test]
        public void TestEmulateChangeText()
        {
            FormsTextBox textBox = new FormsTextBox(app, testDlg["textBox"]());
            textBox.EmulateChangeText("textBox");
            string textBoxText = textBox.Text;
            Assert.AreEqual("textBox", textBoxText);

            // �񓯊�
            app[GetType(), "ChangeTextEvent"](textBox.AppVar);
            textBox.EmulateChangeText("textBox1", new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            textBoxText = textBox.Text;
            Assert.AreEqual("textBox1", textBoxText);
        }

        /// <summary>
        /// �e�L�X�g�ύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="textbox">�{�^��</param>
        static void ChangeTextEvent(TextBox textbox)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                textbox.BeginInvoke((MethodInvoker)delegate
                {
                    textbox.TextChanged -= handler;
                });
            };
            textbox.TextChanged += handler;
        }
    }
}
