using System;
using System.Windows.Forms;
using System.Reflection;
using Ong.Friendly.FormsStandardControls.Properties;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.RadioButton.
    /// </summary>
#else
    /// <summary>
    /// Type��System.Windows.Forms.RadioButton�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
#endif
    public class FormsRadioButton : FormsControlBase
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
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���B</param>
#endif
        public FormsRadioButton(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsRadioButton(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// ���ݔ񐄏��ł��B
        /// FormsRadioButton(AppVar windowObject)���g�p���Ă��������B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
#endif
        [Obsolete("Please use FormsRadioButton(AppVar windowObject).", false)]
        public FormsRadioButton(WindowsAppFriend app, AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
#endif
        public FormsRadioButton(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the checked state state.
        /// </summary>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ��擾���܂��B
        /// </summary>
#endif
        public bool Checked
        {
            get { return (bool)(this["Checked"]().Core); }
        }

#if ENG
        /// <summary>
        /// Checks this control.
        /// </summary>
#else
        /// <summary>
        /// �`�F�b�N���܂��B
        /// </summary>
#endif
        public void EmulateCheck()
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Checks this control.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �`�F�b�N���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateCheck(Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar);
        }

        /// <summary>
        /// �`�F�b�N��Ԃɂ��܂��B
        /// </summary>
        /// <param name="radioButton">���W�I�{�^���B</param>
        static void EmulateCheckInTarget(RadioButton radioButton)
        {
            radioButton.Focus();
            int tryCount = 0;
            while (radioButton.Checked != true)
            {
                tryCount++;
                radioButton.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(radioButton, new object[] { EventArgs.Empty });
                if (tryCount == 2)
                {
                    throw new NotSupportedException(ResourcesLocal.Instance.ErrorCheckSetting);
                }
            }
        }
    }
}
