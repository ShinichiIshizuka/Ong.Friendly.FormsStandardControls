using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��WindowControl��System.Windows.Forms.TabControl�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
    public class FormsTabControl : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���B</param>
        public FormsTabControl(WindowControl src)
            : base(src) { }

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsTabControl(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// �^�u�����擾���܂��B
        /// </summary>
        /// <returns>�^�u���B</returns>
        public int TabCount
        {
            get { return (int)this["TabCount"]().Core; }
        }

        /// <summary>
        /// �I�����ꂽ�^�u�C���f�b�N�X���擾���܂��B
        /// </summary>
        /// <returns>�^�u�C���f�b�N�X�B</returns>
        public int SelectedIndex
        {
            get { return (int)this["SelectedIndex"]().Core; }
        }

        /// <summary>
        /// �^�u��I�����܂��B
        /// </summary>
        /// <param name="index">�^�u�C���f�b�N�X�i�O�n�܂�j�B</param>
        public void EmulateTabSelect(int index)
        {
            this["Focus"]();
            this["SelectedIndex"](index);
        }

        /// <summary>
        /// �^�u��I�����܂��B
        /// </summary>
        /// <param name="index">�^�u�C���f�b�N�X�i�O�n�܂�j�B</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g�B</param>
        public void EmulateTabSelect(int index, Async async)
        {
            this["Focus", new Async()]();
            this["SelectedIndex", async](index);
        }
    }
}