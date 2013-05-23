using NUnit.Framework;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
namespace Test
{
    /// <summary>
    /// ListBox�e�X�g
    /// </summary>
    [TestFixture]
    public class ListBoxTest
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
        public void TestListBoxItemCount()
        {
            FormsListBox listbox1 = new FormsListBox(app, testDlg["listBox1"]());
            int itemCount = listbox1.ItemCount;
            Assert.AreEqual(5, itemCount);
        }

        /// <summary>
        /// �A�C�e�����e�L�X�g�Ō������I���B���̃A�C�e���̃e�L�X�g�ƃC���f�b�N�X���擾���܂�
        /// </summary>
        [Test]
        public void TestListBoxSelectAndItemTextGet()
        {
            FormsListBox listbox1 = new FormsListBox(app, testDlg["listBox1"]());
            int findIndex = listbox1.FindListIndex("Item-4");

            listbox1.EmulateChangeSelectedIndex(findIndex);

            Assert.AreEqual(3, listbox1.SelectedIndex);
        }

        /// <summary>
        /// ���X�g�A�C�e����I����Ԃɂ��܂��B�I���ꗗ���擾���܂��B
        /// </summary>
        [Test]
        public void TestSelectIndexes()
        {
            FormsListBox listbox2 = new FormsListBox(app, testDlg["listBox2"]());
            int[] select = new int[]{5};
            listbox2.EmulateChangeSelectedIndexes(select);
            int[] selected = listbox2.EmulateGetSelectedIndexes();
            Assert.AreEqual(1, selected.Length);
            Assert.AreEqual(5, selected[0]);
        }
    }
}
