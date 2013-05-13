using System;
using System.Collections.Generic;
using System.Text;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// WindowControl��System.Windows.Forms.TextBox�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsTextBox : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsTextBox(FormsControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsTextBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �e�L�X�g��ύX���܂�
        /// </summary>
        /// <param name="newText">�V���ȃe�L�X�g</param>
        public void EmulateChangeText(string newText)
        {
            this["Text"](newText);
        }

        /// <summary>
        /// �e�L�X�g��ύX���܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="newText">�V���ȃe�L�X�g</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateChangeText(string newText, Async async)
        {
            this["Text", async](newText);
        }
    }
}