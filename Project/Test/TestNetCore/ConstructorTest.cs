using System;

using Ong.Friendly.FormsStandardControls;
using Codeer.Friendly;
using Codeer.Friendly.Windows;

namespace TestNetCore
{
    
    public class ConstructorTest
    {
        [Test]
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
