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
        /// リストのアイテム数取得テスト
        /// </summary>
        [Test]
        public void TestComboBoxItemCount()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            int itemCount = combobox1.ItemCount;
            Assert.AreEqual(3, itemCount);
        }

        /// <summary>
        /// 1行目を選択しテキストを取得します
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
        /// 2行目を選択し選択行番号を取得します
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
        /// 3行目を選択しそのテキストを取得します
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
        /// 3行目のテキストを取得します
        /// </summary>
        [Test]
        public void TestComboBoxGetItemText()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            String combobox1Text = combobox1.GetItemText(2);
            Assert.AreEqual("Item-3", combobox1Text);
        }

        /// <summary>
        /// Item-2のテキストを持つアイテムのインデックスを検索します
        /// </summary>
        [Test]
        public void TestFindStringItem()
        {
            FormsComboBox combobox1 = new FormsComboBox(app, testDlg["comboBox1"]());
            int findindex = combobox1.FindString("Item-2",0);
            Assert.AreEqual(1, findindex);
        }

        /// <summary>
        /// 1行目のテキストを設定します
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
