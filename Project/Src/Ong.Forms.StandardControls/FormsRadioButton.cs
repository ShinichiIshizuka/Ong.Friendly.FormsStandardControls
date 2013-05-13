using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Reflection;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// WindowControl��System.Windows.Forms.RadioButton�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsRadioButton : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsRadioButton(FormsControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsRadioButton(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂�
        /// </summary>
        /// <param name="value">�`�F�b�N���</param>
        public void EmulateCheck(bool value)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, value);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="value">�`�F�b�N���</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateCheck(bool value, Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar, value);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂�
        /// </summary>
        /// <param name="radioButton">���W�I�{�^��</param>
        /// <param name="value">�`�F�b�N���</param>
        static void EmulateCheckInTarget(RadioButton radioButton, bool value)
        {
            while (radioButton.Checked != value)
            {
                radioButton.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(radioButton, new object[] { EventArgs.Empty });
            }
        }

        /// <summary>
        /// �`�F�b�N��Ԃ��擾���܂�
        /// </summary>
        /// <returns>�`�F�b�N���</returns>
        public bool Checked
        {
            get { return (bool)(this["Checked"]().Core); }
        }
    }
}
