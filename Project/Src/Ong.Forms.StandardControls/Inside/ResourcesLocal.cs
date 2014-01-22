using System;
using Codeer.Friendly.Windows;
using Ong.Friendly.FormsStandardControls.Properties;

namespace Ong.Friendly.FormsStandardControls.Inside
{
    /// <summary>
    /// ローカライズ済みリソース。
    /// </summary>
    [Serializable]
    class ResourcesLocal
    {
        static internal ResourcesLocal Instance;

        internal string ErrorCheckSetting;
        internal string ErrorNotSetListView;
        internal string ErrorNotSetToolStrip;
        internal string ErrorNotSetTreeView;

        /// <summary>
        /// 初期化。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        internal static void Initialize(WindowsAppFriend app)
        {
            Instance = new ResourcesLocal();
            Instance.Initialize();
            app[typeof(ResourcesLocal), "Instance"](Instance);
        }

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        void Initialize()
        {
            ErrorCheckSetting = Resources.ErrorCheckSetting;
            ErrorNotSetListView = Resources.ErrorNotSetListView;
            ErrorNotSetToolStrip = Resources.ErrorNotSetToolStrip;
            ErrorNotSetTreeView = Resources.ErrorNotSetTreeView;
        }
    }
}
