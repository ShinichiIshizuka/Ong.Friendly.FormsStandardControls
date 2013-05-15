using System;
using System.Windows.Forms;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Reflection;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��System.Windows.Forms.CheckBox�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsCheckBox : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsCheckBox(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsCheckBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂�
        /// </summary>
        /// <param name="value">�`�F�b�N���</param>
        public void EmulateCheck(CheckState value)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, value);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="value">�`�F�b�N���</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateCheck(CheckState value, Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar, value);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂�
        /// </summary>
        /// <param name="checkBox">�`�F�b�N�{�b�N�X</param>
        /// <param name="value">�`�F�b�N���</param>
        static void EmulateCheckInTarget(CheckBox checkBox, CheckState value)
        {
            while (checkBox.CheckState != value)
            {
                checkBox.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(checkBox, new object[] { EventArgs.Empty });
            }
        }

        /// <summary>
        /// �`�F�b�N��Ԃ��擾���܂�
        /// </summary>
        /// <returns>�`�F�b�N���</returns>
        public CheckState CheckState
        {
            get { return (CheckState)(this["CheckState"]().Core); }
        }
    }
}