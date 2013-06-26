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
            FormsTextBox textbox1 = new FormsTextBox(app, testDlg["textBox1"]());
            textbox1.EmulateChangeText("TEXTBOX1");
            string textbox1Text = textbox1.Text;
            Assert.AreEqual("TEXTBOX1", textbox1Text);

            // �񓯊�
            app[GetType(), "ChangeTextEvent"](textbox1.AppVar);
            textbox1.EmulateChangeText("TEXTBOX11", new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            textbox1Text = textbox1.Text;
            Assert.AreEqual("TEXTBOX11", textbox1Text);
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
