using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using Codeer.Friendly.Windows.NativeStandardControls;
using System.Windows.Forms;

namespace FormsTest
{
    /// <summary>
    /// Button�e�X�g
    /// </summary>
    [TestClass]
    public class ButtonTest
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
        /// EmulateClick�̃e�X�g
        /// </summary>
        [TestMethod]
        public void TestButtonClick()
        {
            FormsButton button = new FormsButton(app, testDlg["button"]());
            button.EmulateClick();
            int count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(1, count);

            //�񓯊�
            app[GetType(), "ClickEvent"](button.AppVar);
            button.EmulateClick(new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            count = (int)testDlg["async_counter"]().Core;
            Assert.AreEqual(2, count);
        }

        /// <summary>
        /// �N���b�N���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="button">�{�^��</param>
        static void ClickEvent(Button button)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                button.BeginInvoke((MethodInvoker)delegate
                {
                    button.Click -= handler;
                });
            };
            button.Click += handler;
        }
    }
}
