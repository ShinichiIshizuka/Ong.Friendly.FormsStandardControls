using System.Windows.Forms;
using System.Collections.Generic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.ListBox.
    /// </summary>
#else
    /// <summary>
    /// Type��System.Windows.Forms.ListBox�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
#endif
    public class FormsListBox : FormsControlBase
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
        public FormsListBox(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsListBox(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// ���ݔ񐄏��ł��B
        /// FormsListBox(AppVar windowObject)���g�p���Ă��������B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
#endif
        [Obsolete("Please use FormsListBox(AppVar windowObject).", false)]
        public FormsListBox(WindowsAppFriend app, AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
#endif
        public FormsListBox(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// I get the number of items in the list.
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
        /// I get the index of the currently selected item.
        /// </summary>
#else
        /// <summary>
        /// ���ݑI������Ă���A�C�e���̃C���f�b�N�X���擾���܂��B
        /// </summary>
#endif
        public int SelectedIndex
        {
            get { return (int)(this["SelectedIndex"]().Core); }
        }

#if ENG
        /// <summary>
        /// I get the selection mode.
        /// </summary>
#else
        /// <summary>
        /// �I�����[�h���擾���܂��B
        /// </summary>
#endif
        public SelectionMode SelectionMode
        {
            get { return (SelectionMode)(this["SelectionMode"]().Core); }
        }

#if ENG
        /// <summary>
        /// I get a list item list in the selected state.
        /// </summary>
#else
        /// <summary>
        /// �I����Ԃ̃��X�g���ڈꗗ���擾���܂��B
        /// </summary>
#endif
        public int[] SelectedIndexes
        {
            get { return (int[])(App[GetType(), "GetSelectedIndexesInTarget"](AppVar).Core); }
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
        /// <param name="itemText">�A�C�e���̃e�L�X�g�B</param>
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
        /// <param name="startIndex">�ŏ��̌����Ώۍ��ڂ̑O�ɂ��鍀�ڂ̃C���f�b�N�X�B �擪���猟������ꍇ��-1�ɐݒ肵�܂��B</param>
        /// <returns>�ŏ��Ɍ����������ڂ̃C���f�b�N�X�B��v���鍀�ڂ�������Ȃ��ꍇ��-1��Ԃ��܂��B</returns>
#endif
        public int FindStringExact(string itemText, int startIndex)
        {
            return (int)(this["FindStringExact"](itemText, startIndex).Core);
        }

#if ENG
        /// <summary>
        /// I want to select an item state corresponding to the specified index.
        /// </summary>
#else
        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂��B
        /// </summary>
#endif
        public void EmulateChangeSelectedIndex(int index)
        {
            App[GetType(), "EmulateChangeSelectedIndexInTarget"](AppVar, index);
        }

#if ENG
        /// <summary>
        /// I want to select an item state corresponding to the specified index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Index.</param>
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

#if ENG
        /// <summary>
        /// I want to select an item state corresponding to the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="isSelect">Set true to the selected state.</param>
#else
        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="isSelect">�I����Ԃɂ���ꍇ��true��ݒ肵�܂��B</param>
#endif
        public void EmulateChangeSelectedState(int index, bool isSelect)
        {
            App[GetType(), "EmulateChangeSelectedStateInTarget"](AppVar, index, isSelect);
        }

#if ENG
        /// <summary>
        /// I want to select an item state corresponding to the specified index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="isSelect">Set true to the selected state.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂��B
        /// �񓯊��Ɏ��s���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="isSelect">�I����Ԃɂ���ꍇ��true��ݒ肵�܂��B</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g</param>
#endif
        public void EmulateChangeSelectedState(int index, bool isSelect, Async async)
        {
            App[GetType(), "EmulateChangeSelectedStateInTarget", async](AppVar, index, isSelect);
        }

        /// <summary>
        /// ���X�g�A�C�e����I�����܂��i�����j�B
        /// </summary>
        /// <param name="listbox">���X�g�{�b�N�X</param>
        private static int[] GetSelectedIndexesInTarget(ListBox listbox)
        {
            List<int> list = new List<int>();
            ListBox.SelectedIndexCollection collection = listbox.SelectedIndices;
            for (int itemIndex = 0; itemIndex < collection.Count; itemIndex++)
            {
                list.Add(collection[itemIndex]);
            }
            return list.ToArray();
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂��B
        /// �񓯊��Ɏ��s���܂��B
        /// </summary>
        /// <param name="listbox">ListBox�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        static void EmulateChangeSelectedIndexInTarget(ListBox listbox, int index)
        {
            listbox.Focus();
            listbox.SelectedIndex = index;
        }

        /// <summary>
        /// ���X�g�A�C�e����I�����܂��i�����j�B
        /// </summary>
        /// <param name="listbox">ListBox�B</param>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <param name="isSelect">�I����Ԃɂ���ꍇ��true��ݒ肵�܂��B</param>
        private static void EmulateChangeSelectedStateInTarget(ListBox listbox, int index, bool isSelect)
        {
            listbox.Focus();
            listbox.SetSelected(index, isSelect);
        }
    }
}
