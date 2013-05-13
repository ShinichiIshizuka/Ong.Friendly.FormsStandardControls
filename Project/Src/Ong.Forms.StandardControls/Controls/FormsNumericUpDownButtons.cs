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
    /// Windows.Forms.NumericUpDownButtons�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsNumericUpDownButtons : WindowControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsNumericUpDownButtons(WindowControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
 �@     /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsNumericUpDownButtons(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �����N���b�N���܂�
        /// </summary>
        public void EmulateUpClick()
        {
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)1));
            this["upDownButtons"]()["OnUpDown"](args);
        }

        /// <summary>
        /// �����N���b�N���܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateUpClick(Async async)
        {
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)1));
            this["upDownButtons"]()["OnUpDown", async](args);
        }

        /// <summary>
        /// �����N���b�N���܂�
        /// </summary>
        public void EmulateDownClick()
        {
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)2));
            this["upDownButtons"]()["OnUpDown"](args);
        }

        /// <summary>
        /// �����N���b�N���܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateDownClick(Async async)
        {
            AppVar args = App.Dim(new NewInfo("System.Windows.Forms.UpDownEventArgs", (int)2));
            this["upDownButtons"]()["OnUpDown", async](args);
        }
    }
}