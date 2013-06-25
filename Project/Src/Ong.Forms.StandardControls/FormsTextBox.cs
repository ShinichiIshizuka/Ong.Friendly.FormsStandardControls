using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��WindowControl��System.Windows.Forms.TextBox�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
    public class FormsTextBox : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���B</param>
        public FormsTextBox(WindowControl src)
            : base(src) { }

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsTextBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// �e�L�X�g��ύX���܂��B
        /// </summary>
        /// <param name="newText">�V���ȃe�L�X�g�B</param>
        public void EmulateChangeText(string newText)
        {
            this["Focus"]();
            this["Text"](newText);
        }

        /// <summary>
        /// �e�L�X�g��ύX���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="newText">�V���ȃe�L�X�g�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateChangeText(string newText, Async async)
        {
            this["Focus", new Async()]();
            this["Text", async](newText);
        }
    }
}