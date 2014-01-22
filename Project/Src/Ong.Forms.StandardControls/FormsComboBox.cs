using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.ComboBox.
    /// </summary>
#else
    /// <summary>
    /// Type��System.Windows.Forms.ComboBox�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
#endif
    public class FormsComboBox : FormsControlBase
    {
#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="src">Window control object for the underlying control.</param>
#else
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���B</param>
#endif
        public FormsComboBox(WindowControl src)
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
        public FormsComboBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Returns the number of items in the list.
        /// </summary>
#else
        /// <summary>
        /// �ꗗ�̃A�C�e�������擾���܂��B
        /// </summary>
#endif
        public int ItemCount
        {
            get { return (int)(this["Items"]()["Count"]().Core); }
        }

#if ENG
        /// <summary>
        /// Returns the index of the currently selected item.
        /// </summary>
#else
        /// <summary>
        /// ���ݑI������Ă���A�C�e���̃C���f�b�N�X���擾���܂��B
        /// </summary>
#endif
        public int SelectedItemIndex
        {
            get { return (int)(this["SelectedIndex"]().Core); }
        }

#if ENG
        /// <summary>
        /// Returns the text for an item in the list.
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <returns>The item's text.</returns>
#else
        /// <summary>
        /// �A�C�e���̕�������擾���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <returns>�A�C�e��������B</returns>
#endif
        public string GetItemText(int index)
        {
            return this["Items"]()["[]"](index).ToString();
        }

#if ENG
        /// <summary>
        /// Returns the index of the first item in the ComboBox that starts with the specified string.
        /// </summary>
        /// <param name="text">Text of item.</param>
        /// <returns>Index of the first item found; returns -1 if no match is found.</returns>
#else
        /// <summary>
        /// �w��̕�����̃A�C�e���𕔕���v�������܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        /// <returns>�A�C�e���C���f�b�N�X�B</returns>
#endif
        public int FindString(string text)
        {
            return (int)this["FindString"](text).Core;
        }

#if ENG
        /// <summary>
        /// Returns the index of the first item in the ComboBox beyond the specified index that contains the specified string. The search is not case sensitive.
        /// </summary>
        /// <param name="text">Text of item.</param>
        /// <param name="startIndex">Index of the item before the first item to be searched. Set to -1 to search from the beginning of the control. </param>
        /// <returns>Index of the first item found; returns -1 if no match is found.</returns>
#else
        /// <summary>
        /// �w��̕�����̃A�C�e���𕔕���v�������܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        /// <param name="startIndex">�����J�n�C���f�b�N�X�B</param>
        /// <returns>�A�C�e���C���f�b�N�X�B</returns>
#endif
        public int FindString(string text, int startIndex)
        {
            return (int)this["FindString"](text, startIndex).Core;
        }

#if ENG
        /// <summary>
        /// Finds the first item in the combo box that matches the specified string.
        /// </summary>
        /// <param name="text">Text of item.</param>
        /// <returns>Index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies Empty.</returns>
#else
        /// <summary>
        /// �w��̕�����̃A�C�e�������S��v�������܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        /// <returns>�A�C�e���C���f�b�N�X�B</returns>
#endif
        public int FindStringExact(string text)
        {
            return (int)this["FindStringExact"](text).Core;
        }

#if ENG
        /// <summary>
        /// Finds the first item after the specified index that matches the specified string.
        /// </summary>
        /// <param name="text">Text of item.</param>
        /// <param name="startIndex">Index of the item before the first item to be searched. Set to -1 to search from the beginning of the control. </param>
        /// <returns>Index of the first item found; returns -1 if no match is found, or 0 if the s parameter specifies Empty.</returns>
#else
        /// <summary>
        /// �w��̕�����̃A�C�e�������S��v�������܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        /// <param name="startIndex">�����J�n�C���f�b�N�X�B</param>
        /// <returns>�A�C�e���C���f�b�N�X�B</returns>
#endif
        public int FindStringExact(string text, int startIndex)
        {
            return (int)this["FindStringExact"](text, startIndex).Core;
        }

#if ENG
        /// <summary>
        /// Modifies the control's text.
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
        /// Modifies the control's text.
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

#if ENG
        /// <summary>
        /// Selects the item with the specified index.
        /// </summary>
        /// <param name="index">Item index.</param>
#else
        /// <summary>
        /// �w��̃C���f�b�N�X�̃A�C�e����I�����܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
#endif
        public void EmulateChangeSelect(int index)
        {
            App[GetType(), "EmulateChangeSelectInTarget"](AppVar, index);
        }

#if ENG
        /// <summary>
        /// Selects the item with the specified index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Item index.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �w��̃C���f�b�N�X�̃A�C�e����I�����܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
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