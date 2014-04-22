using System;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// This is the base class of AppVar wrappers.
    /// </summary>
#else
    /// <summary>
    /// AppVarラップアイテムの基本クラスです。
    /// </summary>
#endif
    public class AppVarWrapper : IAppVarOwner
    {
        WindowsAppFriend _app;
        AppVar _appVar;

#if ENG
        /// <summary>
        /// Application manipulation object.
        /// </summary>
#else
        /// <summary>
        /// アプリケーション操作クラスです。
        /// </summary>
#endif
        public WindowsAppFriend App { get { return _app; } }

#if ENG
        /// <summary>
        /// Variable manipulation object within the target application.
        /// </summary>
#else
        /// <summary>
        /// アプリケーション変数操作クラスです。
        /// </summary>
#endif
        public AppVar AppVar { get { return _appVar; } }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="appVar">対象アプリ内変数操作クラス。</param>
        internal AppVarWrapper(AppVar appVar)
        {
            if (appVar == null)
            {
                throw new ArgumentNullException("appVar");
            }
            _app = (WindowsAppFriend)appVar.App;
            _appVar = appVar;
            Initializer.Initialize(App, GetType());
        }

#if ENG
        /// <summary>
        /// Returns a delegate to invoke static operations in the test application.
        /// </summary>
        /// <param name="operation">The operation name.</param>
        /// <returns>Delegate to invoke static operations in the application.</returns>
#else
        /// <summary>
        /// テスト対象アプリケーション内の変数の操作を呼び出すdelegateを取得します。
        /// </summary>
        /// <param name="operation">操作。</param>
        /// <returns>操作実行delegate。</returns>
#endif
        public FriendlyOperation this[string operation]
        {
            get { return _appVar[operation]; }
        }

#if ENG
        /// <summary>
        /// Returns a delegate to invoke static operations in the test application.
        /// </summary>
        /// <param name="operation">The operation name.</param>
        /// <param name="async">Asynchronous execution.</param>
        /// <returns>Delegate to invoke static operations in the application.</returns>
#else
        /// <summary>
        /// テスト対象アプリケーション内の変数の操作を呼び出すdelegateを取得します。
        /// </summary>
        /// <param name="operation">操作。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        /// <returns>操作実行delegate。</returns>
#endif
        public FriendlyOperation this[string operation, Async async]
        {
            get { return _appVar[operation, async]; }
        }

#if ENG
        /// <summary>
        /// Returns a delegate to invoke static operations in the test application.
        /// </summary>
        /// <param name="operation">The operation name.</param>
        /// <param name="operationTypeInfo">
        /// Operation type information. 
        /// Used when there is more than one overload for the operation or you want to call an operation by the same name in a parent class. 
        /// Often the operation can be resolved based on its parameters without specifying the operation type info.
        /// </param>
        /// <returns>Delegate to invoke static operations in the application.</returns>
#else
        /// <summary>
        /// テスト対象アプリケーション内の変数の操作を呼び出すdelegateを取得します。
        /// </summary>
        /// <param name="operation">操作。</param>
        /// <param name="operationTypeInfo">操作タイプ情報。</param>
        /// <returns>操作実行delegate。</returns>
#endif
        public FriendlyOperation this[string operation, OperationTypeInfo operationTypeInfo]
        {
            get { return _appVar[operation, operationTypeInfo]; }
        }

#if ENG
        /// <summary>
        /// Returns a delegate to invoke static operations in the test application.
        /// </summary>
        /// <param name="operation">The operation name.</param>
        /// <param name="operationTypeInfo">
        /// Operation type information. 
        /// Used when there is more than one overload for the operation or you want to call an operation by the same name in a parent class. 
        /// Often the operation can be resolved based on its parameters without specifying the operation type info.
        /// </param>
        /// <param name="async">Asynchronous execution.</param>
        /// <returns>Delegate to invoke static operations in the application.</returns>
#else
        /// <summary>
        /// テスト対象アプリケーション内の変数の操作を呼び出すdelegateを取得します。
        /// </summary>
        /// <param name="operation">操作。</param>
        /// <param name="operationTypeInfo">操作タイプ情報。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
        /// <returns>操作実行delegate。</returns>
#endif
        public FriendlyOperation this[string operation, OperationTypeInfo operationTypeInfo, Async async]
        {
            get { return _appVar[operation, operationTypeInfo, async]; }
        }
    }
}
