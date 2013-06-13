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
        /// ���X�g�̃A�C�e�����擾�e�X�g
        /// </summary>
        [Test]
        public void TestComboBoxItemCount()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            int itemCount = combobox1.ItemCount;
            Assert.AreEqual(3, itemCount);
        }

        /// <summary>
        /// 1�s�ڂ�I�����e�L�X�g���擾���܂�
        /// </summary>
        [Test]
        public void TestComboBoxSelectAndTextGet()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            combobox1.EmulateChangeSelect(0);
            String combobox1Text = combobox1.Text;
            Assert.AreEqual("Item-1", combobox1Text);
        }

        /// <summary>
        /// 2�s�ڂ�I�����I���s�ԍ����擾���܂�
        /// </summary>
        [Test]
        public void TestComboBoxSelectAndSelectNoGet()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            combobox1.EmulateChangeSelect(1);
            int selectIndex = combobox1.SelectedItemIndex;
            Assert.AreEqual(1, selectIndex);
        }

        /// <summary>
        /// 3�s�ڂ�I�������̃e�L�X�g���擾���܂�
        /// </summary>
        [Test]
        public void TestComboBoxSelectItemTextGet()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            combobox1.EmulateChangeSelect(2, new Async());
            String combobox1Text = combobox1.Text;
            Assert.AreEqual("Item-3", combobox1Text);
        }

        /// <summary>
        /// 3�s�ڂ̃e�L�X�g���擾���܂�
        /// </summary>
        [Test]
        public void TestComboBoxGetItemText()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            String combobox1Text = combobox1.GetItemText(2);
            Assert.AreEqual("Item-3", combobox1Text);
        }

        /// <summary>
        /// Item-2�̃e�L�X�g�����A�C�e���̃C���f�b�N�X���������܂�
        /// </summary>
        [Test]
        public void TestFindStringItem()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            int findindex = combobox1.FindString("Item-2",0);
            Assert.AreEqual(1, findindex);
        }

        /// <summary>
        /// 1�s�ڂ̃e�L�X�g��ݒ肵�܂�
        /// </summary>
        [Test]
        public void TestComboBoxSetItemText()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            combobox1.EmulateChangeText("12345");
            String combobox1Text = combobox1.Text;
            Assert.AreEqual("12345", combobox1Text);

            combobox1.EmulateChangeText("66666",new Async());
            combobox1Text = combobox1.Text;
            Assert.AreEqual("66666", combobox1Text);
        }
    }
}
