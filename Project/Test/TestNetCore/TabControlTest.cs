
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
    /// TabControl�e�X�g
    /// </summary>
    
    public class TabControlTest
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
        /// TabCount�e�X�g
        /// </summary>
        [Test]
        public void TestTabCount()
        {
            FormsTabControl tabControl = new FormsTabControl(testDlg["tabControl"]());
            Assert.AreEqual(3, tabControl.TabCount);
        }

        /// <summary>
        /// SelectedIndex�e�X�g
        /// </summary>
        [Test]
        public void TestSelectedIndex()
        {
            FormsTabControl tabControl = new FormsTabControl(testDlg["tabControl"]());
            tabControl.EmulateTabSelect(2);
            Assert.AreEqual(2, tabControl.SelectedIndex);
        }

        /// <summary>
        /// EmulateTabSelect
        /// </summary>
        [Test]
        public void TestTabSelect()
        {
            FormsTabControl tabControl = new FormsTabControl(testDlg["tabControl"]());
            tabControl.EmulateTabSelect(1);
            Assert.AreEqual(1, tabControl.SelectedIndex);

            //�񓯊�
            app[GetType(), "TabSelectEvent"](tabControl.AppVar);
            tabControl.EmulateTabSelect(2, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(2, tabControl.SelectedIndex);
        }

        /// <summary>
        /// ��ԕύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="tabcontrol">�^�u�R���g���[��</param>
        static void TabSelectEvent(TabControl tabcontrol)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                tabcontrol.BeginInvoke((MethodInvoker)delegate
                {
                    tabcontrol.SelectedIndexChanged -= handler;
                });
            };
            tabcontrol.SelectedIndexChanged += handler;
        }
    }
}
