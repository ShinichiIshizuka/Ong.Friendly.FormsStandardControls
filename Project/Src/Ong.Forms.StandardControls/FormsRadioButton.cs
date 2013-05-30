using System;
using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Reflection;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��System.Windows.Forms.RadioButton�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
    public class FormsRadioButton : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���B</param>
        public FormsRadioButton(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsRadioButton(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �`�F�b�N���܂��B
        /// </summary>
        public void EmulateCheck()
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar);
        }

        /// <summary>
        /// �`�F�b�N���܂��B
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
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
            int tryCount = 0;
            while (radioButton.Checked != true)
            {
                tryCount++;
                radioButton.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(radioButton, new object[] { EventArgs.Empty });
                if (tryCount == 2)
                {
                    throw new NotSupportedException(Properties.Resources.ErrorCheckSetting);
                }
            }
        }

        /// <summary>
        /// �`�F�b�N��Ԃ��擾���܂��B
        /// </summary>
        /// <returns>�`�F�b�N��ԁB</returns>
        public bool Checked
        {
            get { return (bool)(this["Checked"]().Core); }
        }
    }
}
