using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ong.Friendly.FormsStandardControls;
using Codeer.Friendly;
using Codeer.Friendly.Windows;

namespace FormsTest
{
    [TestClass]
    public class ConstructorTest
    {
        [TestMethod]
        public void Test()
        {
            foreach(var element in typeof(FormsButton).Assembly.GetTypes())
            {
                if (element.GetConstructor(new Type[] {  typeof(WindowsAppFriend), typeof(AppVar) }) != null)
                {
                    if (element.GetConstructor(new Type[] { typeof(AppVar) }) == null)
                    {
                        Assert.Fail();
                    }
                }
            }
        }
    }
}
