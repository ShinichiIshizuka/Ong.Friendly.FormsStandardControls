using System;

using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
using Codeer.Friendly.Windows.NativeStandardControls;

namespace TestNetCore
{
    /// <summary>
    /// CheckBox�e�X�g
    /// </summary>
    
    public class ComboBoxTest
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
        /// ItemCount�̃e�X�g
        /// </summary>
        [Test]
        public void TestItemCount()
        {
            FormsComboBox comboBox = new FormsComboBox(testDlg["comboBox"]());
            int itemCount = comboBox.ItemCount;
            Assert.AreEqual(5, itemCount);
        }

        /// <summary>
        /// SelectedItemIndex�̃e�X�g
        /// </summary>
        [Test]
        public void TestSelectedItemIndex()
        {
            FormsComboBox comboBox = new FormsComboBox(testDlg["comboBox"]());
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
            FormsComboBox comboBox = new FormsComboBox(testDlg["comboBox"]());
            int findindex = comboBox.FindString("Item-2");
            Assert.AreEqual(1, findindex);
            comboBox["Items"]()["Add"](@"dmy");
            comboBox["Items"]()["Add"](@"Item-2");
            findindex = comboBox.FindString(@"Item-2", 2);
            Assert.AreEqual(comboBox.ItemCount - 1, findindex);
            comboBox["Items"]()["RemoveAt"](comboBox.ItemCount - 1);
            comboBox["Items"]()["RemoveAt"](comboBox.ItemCount - 1);
        }

        /// <summary>
        /// FindStringExact�̃e�X�g
        /// </summary>
        [Test]
        public void TestFindExact()
        {
            FormsComboBox comboBox = new FormsComboBox(testDlg["comboBox"]());
            int findindex = comboBox.FindStringExact("Item-11");
            Assert.AreEqual(4, findindex);
            comboBox["Items"]()["Add"](@"dmy");
            comboBox["Items"]()["Add"](@"Item-11");
            findindex = comboBox.FindStringExact(@"Item-11", 5);
            Assert.AreEqual(comboBox.ItemCount - 1, findindex);
            comboBox["Items"]()["RemoveAt"](comboBox.ItemCount - 1);
            comboBox["Items"]()["RemoveAt"](comboBox.ItemCount - 1);
        }

        /// <summary>
        /// GetItemText�̃e�X�g
        /// </summary>
        [Test]
        public void TestGetItemText()
        {
            FormsComboBox comboBox = new FormsComboBox(testDlg["comboBox"]());
            string comboBoxText = comboBox.GetItemText(2);
            Assert.AreEqual("Item-3", comboBoxText);
        }

        /// <summary>
        /// EmulateChangeSelect�̃e�X�g
        /// </summary>
        [Test]
        public void TestEmulateChangeSelect()
        {
            FormsComboBox comboBox = new FormsComboBox(testDlg["comboBox"]());
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
            FormsComboBox comboBox = new FormsComboBox(testDlg["comboBox"]());
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
