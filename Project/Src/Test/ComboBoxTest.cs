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
    /// CheckBoxテスト
    /// </summary>
    [TestFixture]
    public class ComboBoxTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// 初期化
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            //テスト用の画面起動
            app = new WindowsAppFriend(Process.Start(Settings.TestApplicationPath), "2.0");
            testDlg = WindowControl.FromZTop(app);
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
        }

        /// <summary>
        /// 終了
        /// </summary>
        [TestFixtureTearDown]
        public void TearDown()
        {
            //終了処理
            if (app != null)
            {
                app.Dispose();
                Process process = Process.GetProcessById(app.ProcessId);
                process.CloseMainWindow();
                app = null;
            }
        }

        /// <summary>
        /// ItemCountのテスト
        /// </summary>
        [Test]
        public void TestItemCount()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            int itemCount = combobox1.ItemCount;
            Assert.AreEqual(3, itemCount);
        }

        /// <summary>
        /// SelectedItemIndexのテスト
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
        /// FindStringのテスト
        /// </summary>
        [Test]
        public void TestFindString()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            int findindex = combobox1.FindString("Item-2",0);
            Assert.AreEqual(1, findindex);
        }

        /// <summary>
        /// GetItemTextのテスト
        /// </summary>
        [Test]
        public void TestGetItemText()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            string combobox1Text = combobox1.GetItemText(2);
            Assert.AreEqual("Item-3", combobox1Text);
        }

        /// <summary>
        /// EmulateChangeSelectのテスト
        /// </summary>
        [Test]
        public void TestEmulateChangeSelect()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            combobox1.EmulateChangeSelect(2);
            Assert.AreEqual(2, combobox1.SelectedItemIndex);

            //非同期
            app[GetType(), "SelectEvent"](combobox1.AppVar);
            combobox1.EmulateChangeSelect(1, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(1, combobox1.SelectedItemIndex);
        }

        /// <summary>
        /// 選択時にメッセージボックスを表示する
        /// </summary>
        /// <param name="comboBox">コンボボックス</param>
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
        /// EmulateChangeTextのテスト
        /// </summary>
        [Test]
        public void TestEmulateChangeText()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            combobox1.EmulateChangeText("12345");
            Assert.AreEqual("12345", combobox1.Text);

            //非同期
            app[GetType(), "TextEvent"](combobox1.AppVar);
            combobox1.EmulateChangeText("66666",new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual("66666", combobox1.Text);
        }

        /// <summary>
        /// テキスト変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="comboBox">コンボボックス</param>
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
