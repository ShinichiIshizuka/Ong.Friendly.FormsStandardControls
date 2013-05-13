using System;
using Codeer.Friendly;

namespace Ong.Friendly.FormsStandardControls.Inside
{
    /// <summary>
    /// AppVar���b�v�N���X
    /// </summary>
    public class AppVarWrapper
    {
        AppVar _appVar;

        /// <summary>
        /// �A�v���P�[�V��������N���X
        /// </summary>
        public AppVar AppVar
        {
            get { return _appVar; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="appVar">�A�v��������N���X</param>
        internal AppVarWrapper(AppVar appVar)
        {
            _appVar = appVar;
        }

        /// <summary>
        /// �A�v���P�[�V�������ϐ��̑���Ăяo���p�f���Q�[�g���擾���܂�
        /// </summary>
        /// <param name="operation">����</param>
        /// <returns>������s�f���Q�[�g</returns>
        public FriendlyOperation this[string operation]
        {
            get
            {
                return _appVar[operation];
            }
        }

        /// <summary>
        /// �A�v���P�[�V�������ϐ��̑���Ăяo���p�f���Q�[�g���擾���܂�
        /// </summary>
        /// <param name="operation">����</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        /// <returns>������s�f���Q�[�g</returns>
        public FriendlyOperation this[string operation, Async async]
        {
            get
            {
                return _appVar[operation, async];
            }
        }

        /// <summary>
        /// �A�v���P�[�V�������ϐ��̑���Ăяo���p�f���Q�[�g���擾���܂�
        /// </summary>
        /// <param name="operation">����</param>
        /// <param name="operationTypeInfo">����^�C�v���</param>
        /// <returns>������s�f���Q�[�g</returns>
        public FriendlyOperation this[string operation, OperationTypeInfo operationTypeInfo]
        {
            get
            {
                return _appVar[operation, operationTypeInfo];
            }
        }

        /// <summary>
        /// �A�v���P�[�V�������ϐ��̑���Ăяo���p�f���Q�[�g���擾���܂�
        /// </summary>
        /// <param name="operation">����</param>
        /// <param name="operationTypeInfo">����^�C�v���</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        /// <returns>������s�f���Q�[�g</returns>
        public FriendlyOperation this[string operation, OperationTypeInfo operationTypeInfo, Async async]
        {
            get
            {
                return _appVar[operation, operationTypeInfo, async];
            }
        }
    }
}
