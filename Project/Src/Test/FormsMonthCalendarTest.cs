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
    /// MonthCalenderテスト
    /// </summary>
    [TestFixture]
    public class MonthCalenderTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// 初期化
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp ()
        {
            //テスト用の画面起動
            app = new WindowsAppFriend ( Process.Start ( Settings.TestApplicationPath ), "2.0" );
            testDlg = WindowControl.FromZTop ( app );
            WindowsAppExpander.LoadAssemblyFromFile ( app, GetType ().Assembly.Location );
        }

        /// <summary>
        /// 終了
        /// </summary>
        [TestFixtureTearDown]
        public void TearDown ()
        {
            //終了処理
            if ( app != null )
            {
                app.Dispose ();
                Process process = Process.GetProcessById ( app.ProcessId );
                process.CloseMainWindow ();
                app = null;
            }
        }

        /// <summary>
        /// カレンダーの左端の列に表示される曜日を取得します。 
        /// </summary>
        [Test]
        public void FirstDayOfWeekTest()
        {
            FormsMonthCalendar monthcalender = new FormsMonthCalendar(app, testDlg["monthCalendar1"]());
            Day day = monthcalender.FirstDayOfWeek;
            Assert.AreEqual(Day.Default, day);
        }

        /// <summary>
        /// 選択できる最大日数を取得します。 
        /// </summary>
        [Test]
        public void MaxSelectionCountTest()
        {
            FormsMonthCalendar monthcalender = new FormsMonthCalendar(app, testDlg["monthCalendar1"]());
            int maxcount = monthcalender.MaxSelectionCount;
            Assert.AreEqual(7, maxcount);
        }

        /// <summary>
        /// 現在の選択日時を取得します。 
        /// </summary>
        [Test]
        public void SelectedDayTest()
        {
            FormsMonthCalendar monthcalender = new FormsMonthCalendar(app, testDlg["monthCalendar1"]());
            monthcalender.EmulateSelectDay(new DateTime(2013, 10, 22));

            DateTime datetime = monthcalender.SelectedDay;
            Assert.AreEqual(new DateTime(2013, 10, 22), datetime);
        }

        /// <summary>
        /// 今日を取得します。 
        /// </summary>
        [Test]
        public void TodayTest()
        {
            FormsMonthCalendar monthcalender = new FormsMonthCalendar(app, testDlg["monthCalendar1"]());
            DateTime datetime = monthcalender.Today;
            Assert.AreEqual(DateTime.Today, datetime);
        }

        /// <summary>
        /// 現在の選択日付を設定します。
        /// </summary>
        [Test]
        public void EmulateSelectDayTest()
        {
                FormsMonthCalendar monthcalender = new FormsMonthCalendar(app, testDlg["monthCalendar1"]());
                monthcalender.EmulateSelectDay(new DateTime(2013, 10, 30));
                DateTime datetime = monthcalender.SelectedDay;
                Assert.AreEqual(new DateTime(2013, 10, 30), datetime);

                // 非同期
                app[GetType (), "ChangeDateTimeEvent"] (monthcalender.AppVar );
                monthcalender.EmulateSelectDay(new DateTime(2013, 10, 25), new Async());
                new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
                datetime = monthcalender.SelectedDay;
                Assert.AreEqual(new DateTime(2013, 10, 25), datetime);
        }

        /// <summary>
        /// テキスト変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="textbox">ボタン</param>
        static void ChangeDateTimeEvent(MonthCalendar monthcalender)
        {
            DateRangeEventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                monthcalender.BeginInvoke((MethodInvoker)delegate
                {
                    monthcalender.DateChanged -= handler;
                });
            };
            monthcalender.DateChanged += handler;
        }

        /// <summary>
        /// 選択範囲を取得します。 
        /// </summary>
        [Test]
        public void GetSelectionRangeTest()
        {
            FormsMonthCalendar monthcalender = new FormsMonthCalendar(app, testDlg["monthCalendar1"]());
            DateTime datetimeStart = new DateTime();
            DateTime datetimeEnd = new DateTime();
            monthcalender.GetSelectionRange(ref datetimeStart, ref datetimeEnd);
            Assert.AreEqual(new DateTime(2013, 10, 25), datetimeStart);
            Assert.AreEqual(new DateTime(2013, 10, 25), datetimeEnd);
        }
    }
}
