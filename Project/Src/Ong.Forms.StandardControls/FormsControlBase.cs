using System;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// FormsControlBase
    /// </summary>
    public class FormsControlBase : WindowControl
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsControlBase(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
 �@     /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsControlBase(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }
        
        /// <summary>
        /// �e�L�X�g���擾���܂�
        /// </summary>
        /// <returns>�e�L�X�g</returns>
        public String Text
        {
            get { return (String)this["Text"]().Core; }
        }

        //@@@ Visible��ǉ�

        //@@@ Enable��ǉ�

    }
}
