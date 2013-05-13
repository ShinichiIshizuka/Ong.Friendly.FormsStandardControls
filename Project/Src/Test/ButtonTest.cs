using System;
using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using Codeer.Friendly.Windows.NativeStandardControls;
namespace Test
{
    /// <summary>
    /// Button�e�X�g
    /// </summary>
    [TestFixture]
    public class ButtonTest
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
        /// �N���b�N�e�X�g
        /// </summary>
        [Test]
        public void TestButtonClick()
        {
            FormsButton button1 = new FormsButton(app, testDlg["button1"]());
            button1.EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(3, count);            

            FormsButton button2 = new FormsButton(app, testDlg["button2"]());
            button2.EmulateClick(new Async());
            WindowControl msg = testDlg.WaitForNextModal();
            NativeButton buttonOK = new NativeButton(msg.IdentifyFromWindowText("OK"));
            buttonOK.EmulateClick();
        }

        /// <summary>
        /// �e�L�X�g���擾���܂�
        /// </summary>
        [Test]
        public void TestButtonTextGet()
        {
            FormsButton button1 = new FormsButton(app, testDlg["button1"]());
            String buttonText = button1.Text;
            Assert.AreEqual("button1", buttonText);
        }
    }
}
