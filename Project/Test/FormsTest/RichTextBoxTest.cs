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
    /// RichTextBox�e�X�g
    /// </summary>
    [TestClass]
    public class RichTextBoxTest
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
        /// �e�L�X�g�ݒ�E�擾�����܂�
        /// </summary>
        [TestMethod]
        public void TestEmulateChangeText()
        {
            FormsRichTextBox richTextBox = new FormsRichTextBox(app, testDlg["richTextBox"]());
            richTextBox.EmulateChangeText("richTextBox");
            string richTextBoxText = richTextBox.Text;
            Assert.AreEqual("richTextBox", richTextBoxText);

            // �񓯊�
            app[GetType(), "ChangeTextEvent"](richTextBox.AppVar);
            richTextBox.EmulateChangeText("richTextBox1", new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            richTextBoxText = richTextBox.Text;
            Assert.AreEqual("richTextBox1", richTextBoxText);
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
