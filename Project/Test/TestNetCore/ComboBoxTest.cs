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
    /// CheckBoxテスト
    /// </summary>
    
    public class ComboBoxTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// 初期化
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            //テスト用の画面起動
            app = new WindowsAppFriend(Process.Start(Settings.TestApplicationPath));
            testDlg = WindowControl.FromZTop(app);
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
        }

        /// <summary>
        /// 終了
        /// </summary>
        [TearDown]
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
            FormsComboBox comboBox = new FormsComboBox(testDlg["comboBox"]());
            int itemCount = comboBox.ItemCount;
            Assert.AreEqual(5, itemCount);
        }

        /// <summary>
        /// SelectedItemIndexのテスト
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
        /// FindStringのテスト
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
        /// FindStringExactのテスト
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
        /// GetItemTextのテスト
        /// </summary>
        [Test]
        public void TestGetItemText()
        {
            FormsComboBox comboBox = new FormsComboBox(testDlg["comboBox"]());
            string comboBoxText = comboBox.GetItemText(2);
            Assert.AreEqual("Item-3", comboBoxText);
        }

        /// <summary>
        /// EmulateChangeSelectのテスト
        /// </summary>
        [Test]
        public void TestEmulateChangeSelect()
        {
            FormsComboBox comboBox = new FormsComboBox(testDlg["comboBox"]());
            comboBox.EmulateChangeSelect(2);
            Assert.AreEqual(2, comboBox.SelectedItemIndex);

            //非同期
            app[GetType(), "SelectEvent"](comboBox.AppVar);
            comboBox.EmulateChangeSelect(1, new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual(1, comboBox.SelectedItemIndex);
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
            FormsComboBox comboBox = new FormsComboBox(testDlg["comboBox"]());
            comboBox.EmulateChangeText("12345");
            Assert.AreEqual("12345", comboBox.Text);

            //非同期
            app[GetType(), "TextEvent"](comboBox.AppVar);
            comboBox.EmulateChangeText("66666",new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            Assert.AreEqual("66666", comboBox.Text);
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
