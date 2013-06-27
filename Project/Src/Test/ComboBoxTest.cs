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
    /// CheckBox�e�X�g
    /// </summary>
    [TestFixture]
    public class ComboBoxTest
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
        /// ItemCount�̃e�X�g
        /// </summary>
        [Test]
        public void TestItemCount()
        {
            FormsComboBox comboBox = new FormsComboBox(app, testDlg["comboBox"]());
            int itemCount = comboBox.ItemCount;
            Assert.AreEqual(3, itemCount);
        }

        /// <summary>
        /// SelectedItemIndex�̃e�X�g
        /// </summary>
        [Test]
        public void TestSelectedItemIndex()
        {
            FormsComboBox comboBox = new FormsComboBox(app, testDlg["comboBox"]());
            comboBox.EmulateChangeSelect(1);
            int selectIndex = comboBox.SelectedItemIndex;
            Assert.AreEqual(1, selectIndex);
        }

        /// <summary>
        /// FindString�̃e�X�g
        /// </summary>
        [Test]
        public void TestFindString()
        {
            FormsComboBox comboBox = new FormsComboBox(app, testDlg["comboBox"]());
            int findindex = comboBox.FindString("Item-2",0);
            Assert.AreEqual(1, findindex);
        }

        /// <summary>
        /// GetItemText�̃e�X�g
        /// </summary>
        [Test]
        public void TestGetItemText()
        {
            FormsComboBox comboBox = new FormsComboBox(app, testDlg["comboBox"]());
            string comboBoxText = comboBox.GetItemText(2);
            Assert.AreEqual("Item-3", comboBoxText);
        }

        /// <summary>
        /// EmulateChangeSelect�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeSelect()
        {
            FormsComboBox comboBox = new FormsComboBox(app, testDlg["comboBox"]());
            comboBox.EmulateChangeSelect(2);
            Assert.AreEqual(2, comboBox.SelectedItemIndex);

            //�񓯊�
            app[GetType(), "SelectEvent"](comboBox.AppVar);
            comboBox.EmulateChangeSelect(1, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(1, comboBox.SelectedItemIndex);
        }

        /// <summary>
        /// �I�����Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="comboBox">�R���{�{�b�N�X</param>
        static void SelectEvent(ComboBox comboBox)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                comboBox.BeginInvoke((MethodInvoker)delegate
                {
                    comboBox.SelectedIndexChanged -= handler;
                });
            };
            comboBox.SelectedIndexChanged += handler;
        }

        /// <summary>
        /// EmulateChangeText�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeText()
        {
            FormsComboBox comboBox = new FormsComboBox(app, testDlg["comboBox"]());
            comboBox.EmulateChangeText("12345");
            Assert.AreEqual("12345", comboBox.Text);

            //�񓯊�
            app[GetType(), "TextEvent"](comboBox.AppVar);
            comboBox.EmulateChangeText("66666",new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual("66666", comboBox.Text);
        }

        /// <summary>
        /// �e�L�X�g�ύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="comboBox">�R���{�{�b�N�X</param>
        static void TextEvent(ComboBox comboBox)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                comboBox.BeginInvoke((MethodInvoker)delegate
                {
                    comboBox.TextChanged -= handler;
                });
            };
            comboBox.TextChanged += handler;
        }
    }
}
