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
        public void TestRichTextBoxTextGetAndSet()
        {
            FormsRichTextBox richtextbox1 = new FormsRichTextBox(app, testDlg["richTextBox1"]());
            richtextbox1.EmulateChangeText("RICHTEXTBOX1");
            String richtextbox1Text = richtextbox1.Text;
            Assert.AreEqual("RICHTEXTBOX1", richtextbox1Text);

            richtextbox1.EmulateChangeText("RICHTEXTBOX11", new Async());
            richtextbox1Text = richtextbox1.Text;
            Assert.AreEqual("RICHTEXTBOX11", richtextbox1Text);
        }
    }
}
