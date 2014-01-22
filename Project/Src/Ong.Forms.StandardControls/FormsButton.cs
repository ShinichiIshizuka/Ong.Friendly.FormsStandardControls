using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.Button.
    /// </summary>
#else
    /// <summary>
    /// Type��System.Windows.Forms.Button�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
#endif
    public class FormsButton : FormsControlBase
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
        public FormsButton(WindowControl src)
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
        public FormsButton(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Performs a click.
        /// </summary>
#else
        /// <summary>
        /// �N���b�N�ł��B
        /// </summary>
#endif
        public void EmulateClick()
        {
            App[GetType(), "EmulateClickInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Performs a click.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �N���b�N�ł��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateClick(Async async)
        {
            App[GetType(), "EmulateClickInTarget", async](AppVar);
        }

        /// <summary>
        /// �N���b�N�ł��B
        /// </summary>
        /// <param name="button">�{�^���B</param>
        static void EmulateClickInTarget(Button button)
        {
            button.Focus();
            button.PerformClick();
        }
    }
}