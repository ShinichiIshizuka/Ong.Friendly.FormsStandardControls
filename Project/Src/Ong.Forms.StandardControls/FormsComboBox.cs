using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��System.Windows.Forms.ComboBox�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
    public class FormsComboBox : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���B</param>
        public FormsComboBox(WindowControl src)
            : base(src) { }

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsComboBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// �ꗗ�̃A�C�e�������擾���܂��B
        /// </summary>
        public int ItemCount
        {
            get { return (int)(this["Items"]()["Count"]().Core); }
        }

        /// <summary>
        /// ���ݑI������Ă���A�C�e���̃C���f�b�N�X���擾���܂��B
        /// </summary>
        public int SelectedItemIndex
        {
            get { return (int)(this["SelectedIndex"]().Core); }
        }

        /// <summary>
        /// �A�C�e���̕�������擾���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <returns>�A�C�e��������B</returns>
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
            App[GetType(), "EmulateChangeTextInTarget"](AppVar, text);
        }

        /// <summary>
        /// �e�L�X�g��ύX���܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateChangeText(string text, Async async)
        {
            App[GetType(), "EmulateChangeTextInTarget", async](AppVar, text);
        }

        /// <summary>
        /// �w��̃C���f�b�N�X�̃A�C�e����I�����܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        public void EmulateChangeSelect(int index)
        {
            App[GetType(), "EmulateChangeSelectInTarget"](AppVar, index);
        }

        /// <summary>
        /// �w��̃C���f�b�N�X�̃A�C�e����I�����܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateChangeSelect(int index, Async async)
        {
            App[GetType(), "EmulateChangeSelectInTarget", async](AppVar, index);
        }

        /// <summary>
        /// �e�L�X�g��ύX���܂��B
        /// </summary>
        /// <param name="comboBox">�R���{�{�b�N�X�B</param>
        /// <param name="text">�e�L�X�g�B</param>
        static void EmulateChangeTextInTarget(ComboBox comboBox, string text)
        {
            comboBox.Focus();
            comboBox.Text = text;
        }

        /// <summary>
        /// �w��̃C���f�b�N�X�̃A�C�e����I�����܂��B
        /// </summary>
        /// <param name="comboBox">�R���{�{�b�N�X�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        static void EmulateChangeSelectInTarget(ComboBox comboBox, int index)
        {
            comboBox.Focus();
            comboBox.SelectedIndex = index;
            comboBox.GetType().GetMethod("OnSelectionChangeCommitted", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(comboBox, new object[] { EventArgs.Empty });
        }
    }
}