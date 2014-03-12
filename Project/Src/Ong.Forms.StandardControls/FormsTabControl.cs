using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.TabControl.
    /// </summary>
#else
    /// <summary>
    /// Type��System.Windows.Forms.TabControl�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
#endif
    public class FormsTabControl : FormsControlBase
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
        public FormsTabControl(WindowControl src)
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
        public FormsTabControl(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Returns the number of tabs.
        /// </summary>
#else
        /// <summary>
        /// �^�u�����擾���܂��B
        /// </summary>
#endif
        public int TabCount
        {
            get { return (int)this["TabCount"]().Core; }
        }

#if ENG
        /// <summary>
        /// Returns the currently selected index.
        /// </summary>
#else
        /// <summary>
        /// �I�����ꂽ�^�u�C���f�b�N�X���擾���܂��B
        /// </summary>
#endif
        public int SelectedIndex
        {
            get { return (int)this["SelectedIndex"]().Core; }
        }

#if ENG
        /// <summary>
        /// Selects a certain tab.
        /// </summary>
        /// <param name="index">Index (0-based) of the tab to select.</param>
#else
        /// <summary>
        /// �^�u��I�����܂��B
        /// </summary>
        /// <param name="index">�^�u�C���f�b�N�X�i�O�n�܂�j�B</param>
#endif
        public void EmulateTabSelect(int index)
        {
            App[GetType(), "EmulateTabSelectInTarget"](AppVar, index);
        }

#if ENG
        /// <summary>
        /// Selects a certain tab.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Index (0-based) of the tab to select.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �^�u��I�����܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="index">�^�u�C���f�b�N�X�i�O�n�܂�j�B</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g�B</param>
#endif
        public void EmulateTabSelect(int index, Async async)
        {
            App[GetType(), "EmulateTabSelectInTarget", async](AppVar, index);
        }

        /// <summary>
        /// �w��̃C���f�b�N�X�̃A�C�e����I�����܂��B
        /// </summary>
        /// <param name="tabControl">�^�u�R���g���[���B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        static void EmulateTabSelectInTarget(TabControl tabControl, int index)
        {
            tabControl.Focus();
            tabControl.SelectedIndex = index;
        }
    }
}