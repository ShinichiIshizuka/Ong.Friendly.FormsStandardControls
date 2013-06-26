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
    /// ListBox�e�X�g
    /// </summary>
    [TestFixture]
    public class CheckedListBoxTest
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
        /// ItemCount�e�X�g
        /// </summary>
        [Test]
        public void TestItemCount()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            int itemCount = checkedlistbox1.ItemCount;
            Assert.AreEqual(6, itemCount);
        }

        //@@@GetCheckState

        //@@@FindListIndex

        /// <summary>
        /// CheckedIndices�e�X�g
        /// </summary>
        [Test]
        public void TestCheckedIndices()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateCheckState(1, CheckState.Checked, new Async());
            checkedlistbox1.EmulateCheckState(3, CheckState.Checked, new Async());

            int[] list = checkedlistbox1.CheckedIndices;
            Assert.AreEqual(0, list[0]);
            Assert.AreEqual(1, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(3, list[3]);
            Assert.AreEqual(4, list[4]);
        }

        /// <summary>
        /// SelectedItemIndex�e�X�g
        /// </summary>
        [Test]
        public void TestSelectedItemIndex()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateChangeSelectedIndex(4);
            Assert.AreEqual(4, checkedlistbox1.SelectedItemIndex);

            checkedlistbox1.EmulateChangeSelectedIndex(2,new Async());
            Assert.AreEqual(2, checkedlistbox1.SelectedItemIndex);
        }

        /// <summary>
        /// EmulateChangeSelectedIndex�e�X�g
        /// @@@�񓯊�
        /// </summary>
        [Test]
        public void TestEmulateChangeSelectedIndex()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateChangeSelectedIndex(4);
            string checkedlistbox1Text = checkedlistbox1.Text;
            Assert.AreEqual("Item-5", checkedlistbox1Text);

            checkedlistbox1.EmulateChangeSelectedIndex(2, new Async());
            checkedlistbox1Text = checkedlistbox1.Text;
            Assert.AreEqual("Item-3", checkedlistbox1Text);
        }

        /// <summary>
        /// EmulateCheckState�e�X�g
        /// @@@�񓯊�
        /// </summary>
        [Test]
        public void TestEmulateCheckState()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateCheckState(0, CheckState.Checked);

            int[] list = checkedlistbox1.CheckedIndices;
            Assert.AreEqual(0, list[0]);

            //�񓯊�
            app[GetType(), "ItemCheckedEvent"](checkedlistbox1.AppVar);
            checkedlistbox1.EmulateCheckState(0, CheckState.Unchecked,new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            int[] listUnchecked = checkedlistbox1.CheckedIndices;
            Assert.AreEqual(0, list[0]);
        }

        /// <summary>
        /// ��ԕύX���Ƀ��b�Z�[�W�{�b�N�X��\������
        /// </summary>
        /// <param name="checkdListBox">�`�F�b�N���X�g�{�b�N�X</param>
        static void ItemCheckedEvent(CheckedListBox checkdListBox)
        {
            ItemCheckEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                checkdListBox.BeginInvoke((MethodInvoker)delegate
                {
                    checkdListBox.ItemCheck -= handler;
                });
            };
            checkdListBox.ItemCheck += handler;
        }    
    }
}
