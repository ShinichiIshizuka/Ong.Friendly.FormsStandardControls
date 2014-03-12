using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Reflection;
using System;
using Ong.Friendly.FormsStandardControls.Properties;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.CheckBox.
    /// </summary>
#else
    /// <summary>
    /// Type��System.Windows.Forms.CheckBox�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
#endif
    public class FormsCheckBox : FormsControlBase
    {
#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="src">WindowControl object for the underlying control.</param>
#else
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł��B</param>
#endif
        public FormsCheckBox(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
#endif
        public FormsCheckBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Returns the control's check state.
        /// </summary>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ��擾���܂��B
        /// </summary>
#endif
        public CheckState CheckState
        {
            get { return (CheckState)(this["CheckState"]().Core); }
        }

#if ENG
        /// <summary>
        /// Sets the control's check state.
        /// </summary>
        /// <param name="value">Check state.</param>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="value">�`�F�b�N��ԁB</param>
#endif
        public void EmulateCheck(CheckState value)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, value);
        }

#if ENG
        /// <summary>
        /// Sets the control's check state.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="value">Check state.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="value">�`�F�b�N��ԁB</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
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
            checkBox.Focus();
            int tryCount = 0;
            while (checkBox.CheckState != value)
            {
                tryCount++;
                checkBox.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(checkBox, new object[] { EventArgs.Empty });
                if (tryCount == 2)
                {
                    throw new NotSupportedException(ResourcesLocal.Instance.ErrorCheckSetting);
                }
            }
        }
    }
}