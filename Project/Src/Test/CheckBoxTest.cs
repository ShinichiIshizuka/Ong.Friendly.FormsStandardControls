using System;
using NUnit.Framework;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using System.Windows.Forms;
namespace Test
{
    /// <summary>
    /// CheckBoxテスト
    /// </summary>
    [TestFixture]
    public class CheckBoxTest
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
        /// チェックテスト
        /// </summary>
        [Test]
        public void TestCheckBoxCheck()
        {
            FormsCheckBox checkbox1 = new FormsCheckBox(app, testDlg["checkBox1"]());
            checkbox1.EmulateCheck(true);
            Assert.AreEqual(CheckState.Checked, checkbox1.CheckState);
        }

        /// <summary>
        /// テキストを取得します
        /// </summary>
        [Test]
        public void TestCheckBoxTextGet()
        {
            FormsCheckBox checkBox1 = new FormsCheckBox(app, testDlg["checkBox1"]());
            String checkBox1Text = checkBox1.Text;
            Assert.AreEqual("checkBox1", checkBox1Text);

            checkBox1Text = checkBox1.Text;
            Assert.AreEqual("checkBox1", checkBox1Text);
        }
    }
}
