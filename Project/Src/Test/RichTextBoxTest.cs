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
    /// RichTextBox�e�X�g
    /// </summary>
    [TestFixture]
    public class RichTextBoxTest
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
            FormsRichTextBox richtextbox1 = new FormsRichTextBox(app, testDlg["richTextBox1"]());
            richtextbox1.EmulateChangeText("RICHTEXTBOX1");
            string richtextbox1Text = richtextbox1.Text;
            Assert.AreEqual("RICHTEXTBOX1", richtextbox1Text);

            // �񓯊�
            app[GetType(), "ChangeTextEvent"](richtextbox1.AppVar);
            richtextbox1.EmulateChangeText("RICHTEXTBOX11", new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            richtextbox1Text = richtextbox1.Text;
            Assert.AreEqual("RICHTEXTBOX11", richtextbox1Text);
        }

        /// <summary>
        /// �e�L�X�g�ύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="textbox">���b�`�e�L�X�g</param>
        static void ChangeTextEvent(RichTextBox textbox)
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
