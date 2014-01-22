using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.TextBox.
    /// </summary>
#else
    /// <summary>
    /// Type��System.Windows.Forms.TextBox�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
#endif
    public class FormsTextBox : FormsControlBase
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
        public FormsTextBox(WindowControl src)
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
        public FormsTextBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Sets the control's text.
        /// </summary>
        /// <param name="text">Text to use.</param>
#else
        /// <summary>
        /// �e�L�X�g��ύX���܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
#endif
        public void EmulateChangeText(string text)
        {
            App[GetType(), "EmulateChangeTextInTarget"](AppVar, text);
        }

#if ENG
        /// <summary>
        /// Sets the control's text.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="text">Text to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �e�L�X�g��ύX���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateChangeText(string text, Async async)
        {
            App[GetType(), "EmulateChangeTextInTarget", async](AppVar, text);
        }

        /// <summary>
        /// �e�L�X�g��ύX���܂��B
        /// </summary>
        /// <param name="textBox">���b�`�e�L�X�g�{�b�N�X�B</param>
        /// <param name="text">�e�L�X�g�B</param>
        static void EmulateChangeTextInTarget(TextBox textBox, string text)
        {
            textBox.Focus();
            textBox.Text = text;
        }
    }
}