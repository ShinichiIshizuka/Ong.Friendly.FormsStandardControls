using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��System.Windows.Forms.Button�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
    public class FormsButton : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł��B</param>
        public FormsButton(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsButton(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �N���b�N�ł��B
        /// </summary>
        public void EmulateClick()
        {
            this["Focus"]();
            this["PerformClick"]();
        }

        /// <summary>
        /// �N���b�N�ł��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateClick(Async async)
        {
            this["Focus", new Async()]();
            this["PerformClick", async]();
        }
    }
}