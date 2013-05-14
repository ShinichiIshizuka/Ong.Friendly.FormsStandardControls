using System;
using Codeer.Friendly;
using Codeer.Friendly.Windows;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// AppVarラップアイテムの基本クラス
    /// </summary>
    public class AppVarWrapBase
    {
        WindowsAppFriend _app;
        AppVar _appVar;

        /// <summary>
        /// アプリケーション操作クラス
        /// </summary>
        public WindowsAppFriend App { get { return _app; } }

        /// <summary>
        /// アプリケーション変数操作クラス
        /// </summary>
        public AppVar AppVar { get { return _appVar; } }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="app">対象アプリ操作クラス</param>
        /// <param name="appVar">対象アプリ内変数操作クラス</param>
        internal AppVarWrapBase(WindowsAppFriend app, AppVar appVar)
        {
            _app = app;
            _appVar = appVar;
        }

        /// <summary>
        /// テスト対象アプリケーション内の変数の操作を呼び出すdelegateを取得します。
        /// </summary>
        /// <param name="operation">操作。</param>
        /// <returns>操作実行delegate。</returns>
        public FriendlyOperation this[string operation]
        {
            get
            {
                return _appVar[operation];
            }
        }

        /// <summary>
        /// テスト対象アプリケーション内の変数の操作を呼び出すdelegateを取得します。
        /// </summary>
        /// <param name="operation">操作。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        /// <returns>操作実行delegate。</returns>
        public FriendlyOperation this[string operation, Async async]
        {
            get
            {
                return _appVar[operation, async];
            }
        }

        /// <summary>
        /// テスト対象アプリケーション内の変数の操作を呼び出すdelegateを取得します。
        /// </summary>
        /// <param name="operation">操作。</param>
        /// <param name="operationTypeInfo">操作タイプ情報。</param>
        /// <returns>操作実行delegate。</returns>
        public FriendlyOperation this[string operation, OperationTypeInfo operationTypeInfo]
        {
            get
            {
                return _appVar[operation, operationTypeInfo];
            }
        }

        /// <summary>
        /// テスト対象アプリケーション内の変数の操作を呼び出すdelegateを取得します。
        /// </summary>
        /// <param name="operation">操作。</param>
        /// <param name="operationTypeInfo">操作タイプ情報。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        /// <returns>操作実行delegate。</returns>
        public FriendlyOperation this[string operation, OperationTypeInfo operationTypeInfo, Async async]
        {
            get
            {
                return _appVar[operation, operationTypeInfo, async];
            }
        }
    }
}
