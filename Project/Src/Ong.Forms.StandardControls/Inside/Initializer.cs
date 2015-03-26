using System;
using System.Reflection;
using System.Windows.Forms;
using Codeer.Friendly.Windows;

namespace Ong.Friendly.FormsStandardControls.Inside
{
    /// <summary>
    /// 初期化です。
    /// </summary>
    static class Initializer
    {
        /// <summary>
        /// 初期化です。対象のアプリケーションにアセンブリを読み込ませます。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        internal static void Initialize(WindowsAppFriend app)
        {
            Type myType = typeof(Initializer);

            //初期化は一度だけです。
            //何度呼び出しても問題はないが、パフォーマンスに効いてくるのでWindowsAppFriendのキャッシュを利用します。
            string key = myType.Module.Name + "[Initialize]";
            object isInit;
            if (!app.TryGetAppControlInfo(key, out isInit))
            {
                //身初期化の場合はアセンブリを読み込ませます。
                WindowsAppExpander.LoadAssembly(app, myType.Assembly);
                ResourcesLocal.Initialize(app);
                app.AddAppControlInfo(key, true);
            }
        }
    }
}
