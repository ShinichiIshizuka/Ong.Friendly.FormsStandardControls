using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    //@@@ �ΐ삳��i���j���[�n�S�ʁj

    /// <summary>
    /// Type��System.Windows.Forms.MenuStrip�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsMenuStrip : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsMenuStrip(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
 �@     /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsMenuStrip(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �\�������񂩂�A�C�e�����������܂��B
        /// </summary>
        /// <param name="text">�\��������</param>
        /// <returns>�\��������</returns>
        public FormsToolStripMenuItem FindItem(string text)
        {
            foreach (AppVar element in new Enumerate(this["Items"]()))
            {
                if (element["Text"]().ToString() == text)
                {
                    return new FormsToolStripMenuItem(element);
                }
            }
            return null;
        }
    }
}