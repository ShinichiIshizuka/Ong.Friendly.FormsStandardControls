using System;
using System.Collections.Generic;
using System.Text;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// WindowControl��System.Windows.Forms.TabControl�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsTabControl : WindowControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsTabControl(WindowControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
 �@     /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsTabControl(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �^�u�����擾���܂�
        /// </summary>
        /// <returns>�^�u��</returns>
        public int TabCount
        {
            get { return (int)this["TabCount"]().Core; }
        }

        /// <summary>
        /// �I�����ꂽ�^�u�C���f�b�N�X���擾���܂�
        /// </summary>
        /// <returns>�^�u�C���f�b�N�X</returns>
        public int SelectedIndex
        {
            get { return (int)this["SelectedIndex"]().Core; }
        }

        /// <summary>
        /// �^�u��I�����܂�
        /// </summary>
        /// <param name="index">�^�u�C���f�b�N�X�i�O�n�܂�j</param>
        public void EmulateTabSelect(int index)
        {
            this["SelectedIndex"](index);
        }

        /// <summary>
        /// �^�u��I�����܂�
        /// </summary>
        /// <param name="index">�^�u�C���f�b�N�X�i�O�n�܂�j</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g</param>
        public void EmulateTabSelect(int index,Async async)
        {
            this["SelectedIndex", async](index);
        }
    }
}