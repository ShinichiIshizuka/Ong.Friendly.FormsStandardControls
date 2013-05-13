using System;
using Codeer.Friendly;

namespace Ong.Friendly.FormsStandardControls.Inside
{
    /// <summary>
    /// AppVarラップクラス
    /// </summary>
    public class AppVarWrapper
    {
        AppVar _appVar;

        /// <summary>
        /// アプリケーション操作クラス
        /// </summary>
        public AppVar AppVar
        {
            get { return _appVar; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="appVar">アプリ内操作クラス</param>
        internal AppVarWrapper(AppVar appVar)
        {
            _appVar = appVar;
        }

        /// <summary>
        /// アプリケーション内変数の操作呼び出し用デリゲートを取得します
        /// </summary>
        /// <param name="operation">操作</param>
        /// <returns>操作実行デリゲート</returns>
        public FriendlyOperation this[string operation]
        {
            get
            {
                return _appVar[operation];
            }
        }

        /// <summary>
        /// アプリケーション内変数の操作呼び出し用デリゲートを取得します
        /// </summary>
        /// <param name="operation">操作</param>
        /// <param name="async">非同期実行オブジェクト</param>
        /// <returns>操作実行デリゲート</returns>
        public FriendlyOperation this[string operation, Async async]
        {
            get
            {
                return _appVar[operation, async];
            }
        }

        /// <summary>
        /// アプリケーション内変数の操作呼び出し用デリゲートを取得します
        /// </summary>
        /// <param name="operation">操作</param>
        /// <param name="operationTypeInfo">操作タイプ情報</param>
        /// <returns>操作実行デリゲート</returns>
        public FriendlyOperation this[string operation, OperationTypeInfo operationTypeInfo]
        {
            get
            {
                return _appVar[operation, operationTypeInfo];
            }
        }

        /// <summary>
        /// アプリケーション内変数の操作呼び出し用デリゲートを取得します
        /// </summary>
        /// <param name="operation">操作</param>
        /// <param name="operationTypeInfo">操作タイプ情報</param>
        /// <param name="async">非同期実行オブジェクト</param>
        /// <returns>操作実行デリゲート</returns>
        public FriendlyOperation this[string operation, OperationTypeInfo operationTypeInfo, Async async]
        {
            get
            {
                return _appVar[operation, operationTypeInfo, async];
            }
        }
    }
}
