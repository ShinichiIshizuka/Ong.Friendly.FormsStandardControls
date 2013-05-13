using System;
using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
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
        public void TestCheckedListBoxItemCount()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            int itemCount = checkedlistbox1.ItemCount;
            Assert.AreEqual(6, itemCount);
        }

        /// <summary>
        /// �C���f�b�N�X�ŃA�C�e����I�����e�L�X�g���擾���܂�
        /// </summary>
        [Test]
        public void TestCheckedListBoxSelectAndTextGet()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateChangeSelectedIndex(4);
            String checkedlistbox1Text = checkedlistbox1.Text;
            Assert.AreEqual("Item-5", checkedlistbox1Text);

            checkedlistbox1.EmulateChangeSelectedIndex(2, new Async());
            checkedlistbox1Text = checkedlistbox1.Text;
            Assert.AreEqual("Item-3", checkedlistbox1Text);
        }

        /// <summary>
        /// �`�F�b�N�����ꗗ���擾���܂�
        /// </summary>
        [Test]
        public void TestCheckedListBoxCheckListGet()
        {
            FormsCheckedListBox checkedlistbox1 = new FormsCheckedListBox(app, testDlg["checkedListBox1"]());
            checkedlistbox1.EmulateCheckState(0, CheckState.Checked);
            checkedlistbox1.EmulateCheckState(2, CheckState.Checked);
            checkedlistbox1.EmulateCheckState(4, CheckState.Checked);

            int[] list = checkedlistbox1.CheckedIndices;
            Assert.AreEqual(0, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(4, list[2]);
        }
    }
}
