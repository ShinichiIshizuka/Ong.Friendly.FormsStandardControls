using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using System;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.CheckedListBox.
    /// </summary>
#else
    /// <summary>
    /// Type��System.Windows.Forms.CheckdListBox�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
#endif
    public class FormsCheckedListBox : FormsControlBase
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
        [Obsolete("Please use FormsCheckedListBox(WindowControl src)", false)]
        public FormsCheckedListBox(FormsControlBase src)
            : base(src) { }

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
        public FormsCheckedListBox(WindowControl src)
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
        public FormsCheckedListBox(WindowsAppFriend app, AppVar appVar)
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
        /// Returns an array of the indices that are currently checked.
        /// </summary>
#else
        /// <summary>
        /// ���݃`�F�b�N����Ă���A�C�e���̃C���f�b�N�X��z��Ŏ擾���܂��B
        /// </summary>
#endif
        public int[] CheckedIndices
        {
            get { return (int[])(App[GetType(), "CheckedIndicsInTarget"](AppVar).Core); }
        }

#if ENG
        /// <summary>
        /// Returns the control's check state.
        /// </summary>
        /// <returns>The check state.</returns>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ��擾���܂��B
        /// </summary>
        /// <returns>�`�F�b�N���</returns>
#endif
        public CheckState GetCheckState(int index)
        {
            return (CheckState)(this["GetItemCheckState"](index).Core);
        }

#if ENG
        /// <summary>
        /// Finds an item with the indicated text.
        /// </summary>
        /// <param name="itemText">Text of the item.</param>
        /// <returns>Index of the found item. Returns -1 if the item could not be found.</returns>
#else
        /// <summary>
        /// �A�C�e�����w�肳�ꂽ�e�L�X�g�Ō������܂��B
        /// </summary>
        /// <param name="itemText">�A�C�e���̃e�L�X�g�B</param>
        /// <returns>�������ꂽ�A�C�e���̃C���f�b�N�X�B����������-1���Ԃ�܂��B</returns>
#endif
        [Obsolete("Please use one of the following. FindString, FindStringExact", false)]
        public int FindListIndex(string itemText)
        {
            return (int)(this["FindString"](itemText).Core);
        }

#if ENG
        /// <summary>
        /// Finds an item with the indicated text.
        /// </summary>
        /// <param name="itemText">Text of the item.</param>
        /// <returns>Index of the found item. Returns -1 if the item could not be found.</returns>
#else
        /// <summary>
        /// �w�肵��������Ŏn�܂�ŏ��̍��ڂ��������܂��B
        /// </summary>
        /// <param name="itemText">�A�C�e���̃e�L�X�g�B</param>
        /// <returns>�������ꂽ�A�C�e���̃C���f�b�N�X�B����������-1���Ԃ�܂��B</returns>
#endif
        public int FindString(string itemText)
        {
            return (int)(this["FindString"](itemText).Core);
        }

#if ENG
        /// <summary>
        /// Finds the first item that starts with the specified string. The search starts at a specific starting index.
        /// </summary>
        /// <param name="itemText">Text of the item.</param>
        /// <param name="startIndex">Index of the item before the first item to be searched. Set to -1 to search from the beginning. </param>
        /// <returns>Index of the found item. Returns -1 if the item could not be found.</returns>
#else
        /// <summary>
        /// �w�肵��������Ŏn�܂�ŏ��̃A�C�e�����������܂��B�w�肵���J�n�C���f�b�N�X���猟�����J�n���܂��B
        /// </summary>
        /// <param name="itemText">�A�C�e���̃e�L�X�g�B</param>
        /// <param name="startIndex">�ŏ��̌����Ώۍ��ڂ̑O�ɂ��鍀�ڂ̃C���f�b�N�X�B �擪���猟������ꍇ��-1�ɐݒ肵�܂��B </param>
        /// <returns>�������ꂽ�m�[�h�̃C���f�b�N�X�B����������-1���Ԃ�܂��B</returns>
#endif
        public int FindString(string itemText, int startIndex)
        {
            return (int)(this["FindString"](itemText, startIndex).Core);
        }

#if ENG
        /// <summary>
        /// Finds the first item that exactly matches the specified string.
        /// </summary>
        /// <param name="itemText">Text of the item.</param>
        /// <returns>Index of the first item found; returns -1 if no match is found.</returns>
#else
        /// <summary>
        /// �w�肵��������Ɛ��m�Ɉ�v����ŏ��̍��ڂ��������܂��B
        /// </summary>
        /// <param name="itemText">�e�L�X�g�B</param>
        /// <returns>�ŏ��Ɍ����������ڂ̃C���f�b�N�X�B��v���鍀�ڂ�������Ȃ��ꍇ��-1��Ԃ��܂��B</returns>
#endif
        public int FindStringExact(string itemText)
        {
            return (int)(this["FindStringExact"](itemText).Core);
        }

#if ENG
        /// <summary>
        /// Finds the first item that exactly matches the specified string. The search starts at a specific starting index.
        /// </summary>
        /// <param name="itemText">Text of the item.</param>
        /// <param name="startIndex">Index of the item before the first item to be searched. Set to -1 to search from the beginning. </param>
        /// <returns>Index of the first item found; returns -1 if no match is found.</returns>
#else
        /// <summary>
        /// �w�肵��������Ɛ��m�Ɉ�v����ŏ��̍��ڂ��������܂��B �w�肵���J�n�C���f�b�N�X���猟�����J�n���܂��B
        /// </summary>
        /// <param name="itemText">�e�m�[�h�̃e�L�X�g</param>
        /// <param name="startIndex">�ŏ��̌����Ώۍ��ڂ̑O�ɂ��鍀�ڂ̃C���f�b�N�X�ԍ��B �擪���猟������ꍇ��-1�ɐݒ肵�܂��B</param>
        /// <returns>�ŏ��Ɍ����������ڂ̃C���f�b�N�X�B��v���鍀�ڂ�������Ȃ��ꍇ��-1��Ԃ��܂��B</returns>
#endif
        public int FindStringExact(string itemText, int startIndex)
        {
            return (int)(this["FindStringExact"](itemText, startIndex).Core);
        }

#if ENG
        /// <summary>
        /// Sets the check state of a certain item.
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <param name="value">Check state.</param>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="value">�`�F�b�N��ԁB</param>
#endif
        public void EmulateCheckState(int index, CheckState value)
        {
            App[GetType(), "EmulateCheckStateInTarget"](AppVar, index, value);
        }

#if ENG
        /// <summary>
        /// Sets the check state of a certain item.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <param name="value">Check state.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="value">�`�F�b�N��ԁB</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateCheckState(int index ,CheckState value, Async async)
        {
            App[GetType(), "EmulateCheckStateInTarget", async](AppVar, index, value);
        }

#if ENG
        /// <summary>
        /// Sets the currently selected index.
        /// </summary>
        /// <param name="index">The index.</param>
#else
        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
#endif
        public void EmulateChangeSelectedIndex(int index)
        {
            App[GetType(), "EmulateChangeSelectedIndexInTarget"](AppVar, index);
        }

#if ENG
        /// <summary>
        /// Sets the currently selected index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂��B
        /// �񓯊��Ɏ��s���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateChangeSelectedIndex(int index, Async async)
        {
            App[GetType(), "EmulateChangeSelectedIndexInTarget", async](AppVar, index);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="checkedListBox">�Ώۂ̃`�F�b�N���X�g�{�b�N�X�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="value">�`�F�b�N��ԁB</param>
        static void EmulateCheckStateInTarget(CheckedListBox checkedListBox, int index, CheckState value)
        {
            checkedListBox.Focus();
            checkedListBox.SetItemCheckState(index, value);
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂��B
        /// �񓯊��Ɏ��s���܂��B
        /// </summary>
        /// <param name="checkedListBox">�Ώۂ̃`�F�b�N���X�g�{�b�N�X�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        static void EmulateChangeSelectedIndexInTarget(CheckedListBox checkedListBox, int index)
        {
            checkedListBox.Focus();
            checkedListBox.SelectedIndex = index;
        }

        /// <summary>
        /// ���݃`�F�b�N����Ă���A�C�e���̃C���f�b�N�X��z��Ŏ擾���܂�(����)�B
        /// </summary>
        /// <param name="checkedListBox">�Ώۂ̃`�F�b�N���X�g�{�b�N�X�B</param>
        /// <returns></returns>
        private static int[] CheckedIndicsInTarget(CheckedListBox checkedListBox)
        {
            List<int> checkedlist = new List<int>();
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    checkedlist.Add(i);
                }
            }
            return checkedlist.ToArray();
        }
    }
}
