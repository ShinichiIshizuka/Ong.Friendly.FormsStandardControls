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
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            int itemCount = combobox1.ItemCount;
            Assert.AreEqual(3, itemCount);
        }

        /// <summary>
        /// SelectedItemIndex�̃e�X�g
        /// </summary>
        [Test]
        public void TestSelectedItemIndex()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            combobox1.EmulateChangeSelect(1);
            int selectIndex = combobox1.SelectedItemIndex;
            Assert.AreEqual(1, selectIndex);
        }

        /// <summary>
        /// FindString�̃e�X�g
        /// </summary>
        [Test]
        public void TestFindString()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            int findindex = combobox1.FindString("Item-2",0);
            Assert.AreEqual(1, findindex);
        }

        /// <summary>
        /// GetItemText�̃e�X�g
        /// </summary>
        [Test]
        public void TestGetItemText()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            string combobox1Text = combobox1.GetItemText(2);
            Assert.AreEqual("Item-3", combobox1Text);
        }

        /// <summary>
        /// EmulateChangeSelect�̃e�X�g
        /// @@@�񓯊��̃e�X�g�ɂȂ��Ă��Ȃ��B
        /// </summary>
        [Test]
        public void TestEmulateChangeSelect()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            combobox1.EmulateChangeSelect(2, new Async());
            string combobox1Text = combobox1.Text;
            Assert.AreEqual("Item-3", combobox1Text);
        }

        /// <summary>
        /// EmulateChangeText�̃e�X�g
        /// @@@�񓯊�
        /// </summary>
        [Test]
        public void TestEmulateChangeText()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            combobox1.EmulateChangeText("12345");
            string combobox1Text = combobox1.Text;
            Assert.AreEqual("12345", combobox1Text);

            combobox1.EmulateChangeText("66666",new Async());
            combobox1Text = combobox1.Text;
            Assert.AreEqual("66666", combobox1Text);
        }
    }
}
