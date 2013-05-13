using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Reflection;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// WindowControl��System.Windows.Forms.ComboBox�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsComboBox : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsComboBox(FormsControlBase src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsComboBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �ꗗ�̃A�C�e�������擾���܂�
        /// </summary>
        public int ItemCount
        {
            get 
            {
                return (int)(this["Items"]()["Count"]().Core);
            }
        }

        /// <summary>
        /// ���ݑI������Ă���A�C�e���̃C���f�b�N�X���擾���܂�
        /// </summary>
        public int SelectedItemIndex
        {
            get 
            {
                return (int)(this["SelectedIndex"]().Core);
            }
        }

        /// <summary>
        /// �A�C�e��������擾
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�A�C�e��������</returns>
        public string GetItemText(int index)
        {
            return this["Items"]()["[]"](index).ToString();
        }

        /// <summary>
        /// �w��̕�����̃A�C�e�����������܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        /// <param name="startIndex">�����J�n�C���f�b�N�X�B</param>
        /// <returns>�A�C�e���C���f�b�N�X�B</returns>
        public int FindString(string text, int startIndex)
        {
            return (int)this["FindString"](text, startIndex).Core;
        }

        /// <summary>
        /// �e�L�X�g��ύX���܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        public void EmulateChangeText(string text)
        {
            this["Text"](text);
        }

        /// <summary>
        /// �e�L�X�g��ύX���܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateChangeText(string text, Async async)
        {
            this["Text", async](text);
        }

        /// <summary>
        /// �w��̃C���f�b�N�X�̃A�C�e����I�����܂�
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        public void EmulateChangeSelect(int index)
        {
            App[GetType(), "EmulateChangeSelectInTarget"](AppVar, index);
        }

        /// <summary>
        /// �w��̃C���f�b�N�X�̃A�C�e����I�����܂�
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateChangeSelect(int index, Async async)
        {
            App[GetType(), "EmulateChangeSelectInTarget", async](AppVar, index);
        }

        /// <summary>
        /// �w��̃C���f�b�N�X�̃A�C�e����I�����܂�
        /// </summary>
        /// <param name="comboBox">�R���{�{�b�N�X</param>
        /// <param name="index">�C���f�b�N�X</param>
        static void EmulateChangeSelectInTarget(ComboBox comboBox, int index)
        {
            comboBox.SelectedIndex = index;
            comboBox.GetType().GetMethod("OnSelectionChangeCommitted", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(comboBox, new object[] { EventArgs.Empty });
        }

    }
}