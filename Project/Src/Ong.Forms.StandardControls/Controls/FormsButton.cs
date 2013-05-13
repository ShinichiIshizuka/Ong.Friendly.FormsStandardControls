using System;
using System.Collections.Generic;
using System.Text;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// WindowControl��System.Windows.Forms.Button�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsButton : WindowControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsButton(WindowControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
 �@     /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsButton(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �N���b�N���܂�
        /// </summary>
        public void EmulateClick()
        {
            this["PerformClick"]();
        }

        /// <summary>
        /// �N���b�N���܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateClick(Async async)
        {
            this["PerformClick", async]();
        }
    }
}