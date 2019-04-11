using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;
using CreateDriverTarget;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ong.Friendly.FormsStandardControls;

namespace GeneratorTest
{
    [TestClass]
    public class CreateDriverTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            DriverCreatorAdapter.TypeFullNameAndControlDriver.Clear();
            foreach (var type in typeof(FormsButton).Assembly.GetTypes())
            {
                //属性をチェック
                foreach (var attr in type.GetCustomAttributes(false).OfType<ControlDriverAttribute>())
                {
                    //コントロールドライバ
                    DriverCreatorAdapter.TypeFullNameAndControlDriver.Add(
                        attr.TypeFullName,
                        new ControlDriverInfo
                        {
                            SearchDescendantUserControls = attr.SearchDescendantUserControls,
                            ControlDriverTypeFullName = type.FullName,
                            DriverMappingEnabled = attr.DriverMappingEnabled
                        });
                }
            }
            // プロパティに値を設定
            var driverCreatorAdapterType = typeof(DriverCreatorAdapter);
            driverCreatorAdapterType.InvokeMember("SetSelectedNamespace", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, new object[] { "TestCode" });
            driverCreatorAdapterType.InvokeMember("SetClientProjectExtension", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, new object[] { ".csproj" });
        }

        [TestMethod]
        public void SingleFormTest()
        {
            var expected = new Dictionary<string, string>
            {
                ["SingleForm_Driver.cs"] = Properties.Resources.SingleForm_Driver
            };
            TestCore<SingleForm>(expected);
        }

        [TestMethod]
        public void MdiFormTest()
        {
            var expected = new Dictionary<string, string>
            {
                ["MdiParentForm_Driver.cs"] = Properties.Resources.MdiParentForm_Driver,
                ["SingleForm_Driver.cs"] = Properties.Resources.MdiChildForm_Driver
            };
            TestCore<MdiParentForm>(expected);
        }

        [TestMethod]
        public void UserControlFormTest()
        {
            var expected = new Dictionary<string, string>
            {
                ["UserControlForm_Driver.cs"] = Properties.Resources.UserControlForm_Driver,
                ["UserControl1_Driver.cs"] = Properties.Resources.UserControl1_Driver
            };
            TestCore<UserControlForm>(expected);
        }

        [TestMethod]
        public void TabUserControlTest()
        {
            var expected = new Dictionary<string, string>
            {
                ["TabUserControlForm_Driver.cs"] = Properties.Resources.TabUserControlForm_Driver,
                ["UserControl2_Driver.cs"] = Properties.Resources.UserControl2_Driver,
                ["UserControl1_Driver.cs"] = Properties.Resources.NestedUserControl1_Driver
            };
            TestCore<TabUserControlForm>(expected);
        }

        /// <summary>
        /// テスト実行の本体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expected"></param>
        private void TestCore<T>(IDictionary<string, string> expected) where T : Form, new()
        {
            // テスト用のフォームを作成してコード生成
            using (var form = new T())
            {
                Application.Run(form);
            }
            // 生成したコードを取得して正しいかチェック
            var actual = GetCode();
            AreEqual(expected, actual);
        }

        /// <summary>
        /// 生成したコードを取得する
        /// </summary>
        /// <returns></returns>
        private IDictionary<string, string> GetCode()
        {
            var codes = new Dictionary<string, string>();
            var result = typeof(DriverCreatorAdapter).InvokeMember("PopFiles", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, new object[0]);
            foreach (var item in (dynamic)result)
            {
                var key = (string)GetProperty(item, "Key").GetValue(item);
                var value = GetProperty(item, "Value").GetValue(item);
                var code = (string)GetProperty(value, "Code").GetValue(value);
                codes.Add(key, code);
            }
            return codes;
        }

        /// <summary>
        /// 指定されたプロパティ情報を取得する
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private PropertyInfo GetProperty(object source, string propertyName)
        {
            var info = source.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (info == null) throw new InvalidOperationException($"Property [{propertyName}] is not found.");
            return info;
        }

        /// <summary>
        /// 指定されたDictionaryが同じか調べる
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        private void AreEqual(IDictionary<string, string> expected, IDictionary<string, string> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);
            foreach (var expectedItem in expected)
            {
                Assert.IsTrue(actual.TryGetValue(expectedItem.Key, out var code));
                Assert.AreEqual(expectedItem.Value, code);
            }
        }
    }
}
