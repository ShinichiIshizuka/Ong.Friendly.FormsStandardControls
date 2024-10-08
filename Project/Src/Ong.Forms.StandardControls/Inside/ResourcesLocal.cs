using System;
using Codeer.Friendly.Windows;
using Ong.Friendly.FormsStandardControls.Properties;

namespace Ong.Friendly.FormsStandardControls.Inside
{
    /// <summary>
    /// ローカライズ済みリソース。
    /// </summary>
    [Serializable]
    public class ResourcesLocal
    {
        static internal ResourcesLocal Instance;

        /// <summary>
        /// ErrorCheckSetting
        /// </summary>
        public string ErrorCheckSetting { get; set; }

        /// <summary>
        /// ErrorNotSetListView
        /// </summary>
        public string ErrorNotSetListView { get; set; }

        /// <summary>
        /// ErrorNotSetToolStrip
        /// </summary>
        public string ErrorNotSetToolStrip { get; set; }

        /// <summary>
        /// ErrorNotSetTreeView
        /// </summary>
        public string ErrorNotSetTreeView { get; set; }

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
        /// 初期化。
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
