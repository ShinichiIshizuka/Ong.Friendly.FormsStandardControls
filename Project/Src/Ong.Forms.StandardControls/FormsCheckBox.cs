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
    /// Type��System.Windows.Forms.CheckBox�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
    public class FormsCheckBox : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł��B</param>
        public FormsCheckBox(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsCheckBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="value">�`�F�b�N��ԁB</param>
        public void EmulateCheck(CheckState value)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, value);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="value">�`�F�b�N��ԁB</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateCheck(CheckState value, Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar, value);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="checkBox">�`�F�b�N�{�b�N�X�B</param>
        /// <param name="value">�`�F�b�N��ԁB</param>
        static void EmulateCheckInTarget(CheckBox checkBox, CheckState value)
        {
            while (checkBox.CheckState != value)
            {
                checkBox.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(checkBox, new object[] { EventArgs.Empty });
            }
        }

        /// <summary>
        /// �`�F�b�N��Ԃ��擾���܂��B
        /// </summary>
        /// <returns>�`�F�b�N��ԁB</returns>
        public CheckState CheckState
        {
            get { return (CheckState)(this["CheckState"]().Core); }
        }
    }
}