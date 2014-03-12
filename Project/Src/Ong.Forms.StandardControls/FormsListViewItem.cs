using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls.Properties;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Represtnts a list item.
    /// </summary>
#else
    /// <summary>
    /// ���X�g�A�C�e���ł��B
    /// </summary>
#endif
    public class FormsListViewItem : AppVarWrapper
    {
#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="item">AppVar referencing the target control object.</param>
#else
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="item">�A�C�e���B</param>
#endif
        public FormsListViewItem(WindowsAppFriend app, AppVar item)
            : base(app, item) { }

#if ENG
        /// <summary>
        /// Returns the item's text.
        /// </summary>
#else
        /// <summary>
        /// �e�L�X�g���擾���܂��B
        /// </summary>
#endif
        public string Text
        {
            get { return (string)this["Text"]().Core; }
        }

#if ENG
        /// <summary>
        /// Returns the item's index.
        /// </summary>
#else
        /// <summary>
        /// �A�C�e���C���f�b�N�X���擾���܂��B
        /// </summary>
#endif
        public int ItemIndex
        {
            get { return (int)this["Index"]().Core; }
        }

#if ENG
        /// <summary>
        /// Returns the item's check state.
        /// </summary>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ��擾���܂��B
        /// </summary>
#endif
        public bool Checked
        {
            get { return (bool)this["Checked"]().Core; }
        }

#if ENG
        /// <summary>
        /// Retrieves a sub item.
        /// </summary>
        /// <param name="subitemindex">Index of the sub-item to retrieve.</param>
        /// <returns>The indicated item.</returns>
#else
        /// <summary>
        /// �T�u�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="subitemindex">�T�u�A�C�e���C���f�b�N�X�B</param>
        /// <returns>�T�u�A�C�e���B</returns>
#endif
        public FormsListViewSubItem GetSubItem(int subitemindex)
        {
            return new FormsListViewSubItem(App, App[GetType(), "GetSubItemInTarget"](AppVar, subitemindex));
        }

#if ENG
        /// <summary>
        /// Sets the item's checked state.
        /// </summary>
        /// <param name="value">Check state to use.</param>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="value">�`�F�b�N��ԁB</param>
#endif
        public void EmulateCheck(bool value)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, value);
        }

#if ENG
        /// <summary>
        /// Sets the item's checked state.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="value">Check state to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="value">�`�F�b�N��ԁB</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateCheck(bool value, Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar, value);
        }

#if ENG
        /// <summary>
        /// Sets the item's text.
        /// </summary>
        /// <param name="text">Text to use.</param>
#else
        /// <summary>
        /// �e�L�X�g��ҏW���܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
#endif
        public void EmulateEditLabel(string text)
        {
            App[GetType(), "EmulateEditLabelInTarget"](AppVar, text);
        }

#if ENG
        /// <summary>
        /// Sets the item's text.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="text">Text to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �e�L�X�g��ҏW���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateEditLabel(string text, Async async)
        {
            App[GetType(), "EmulateEditLabelInTarget", async](AppVar, text);
        }

        /// <summary>
        /// �T�u�A�C�e�����擾���܂�(����)�B
        /// </summary>
        /// <param name="listviewitem">���X�g�r���[�A�C�e���B</param>
        /// <param name="subitemindex">���X�g�r���[�T�u�A�C�e���C���f�b�N�X�B</param>
        /// <returns>FormsListViewSubItem</returns>
        static ListViewItem.ListViewSubItem GetSubItemInTarget(ListViewItem listviewitem, int subitemindex)
        {
            return listviewitem.SubItems[subitemindex];
        }

        /// <summary>
        /// �e�L�X�g��ҏW���܂��B
        /// </summary>
        /// <param name="item">�A�C�e���B</param>
        /// <param name="text">�e�L�X�g�B</param>
        static void EmulateEditLabelInTarget(ListViewItem item, string text)
        {
            if (item.ListView == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetListView);
            }

            item.ListView.Focus();

            //�ҏW�J�n
            item.BeginEdit();

            //�G�f�B�^��T��
            IntPtr edit = IntPtr.Zero;
            EnumWindowsProc proc = delegate(IntPtr hWnd, IntPtr lParam)
            {
                StringBuilder build = new StringBuilder(256 + 8);
                GetClassName(hWnd, build, 256);
                if (build.ToString().ToLower() == "edit")
                {
                    edit = hWnd;
                    return false;
                }
                return true;
            };
            EnumChildWindows(item.ListView.Handle, proc, IntPtr.Zero);
            GC.KeepAlive(proc);

            //�e�L�X�g�ݒ�
            SetWindowText(edit, text);

            //�t�H�[�J�X�����X�g�r���[�ɖ߂��ҏW����
            item.ListView.Focus();
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="item">���X�g�r���[�A�C�e���B</param>
        /// <param name="value">�`�F�b�N��ԁB</param>
        static void EmulateCheckInTarget(ListViewItem item, bool value)
        {
            if (item.ListView == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetListView);
            }
            item.ListView.Focus();
            item.Checked = value;
        }

        /// <summary>
        /// �E�B���h�E�����v���b�N�B
        /// </summary>
        /// <param name="hWnd">�E�B���h�E�n���h���B</param>
        /// <param name="lParam">�p�����[�^�B</param>
        /// <returns>�����𑱂��邩�B</returns>
        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary>
        /// �q�E�B���h�E�����B
        /// </summary>
        /// <param name="parent">�e�E�B���h�E�n���h���B</param>
        /// <param name="lpEnumFunc">�����v���b�N�B</param>
        /// <param name="lParam">�p�����[�^�B</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumChildWindows(IntPtr parent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// �E�B���h�E�N���X���̎擾�B
        /// </summary>
        /// <param name="hWnd">�E�B���h�E�n���h���B</param>
        /// <param name="lpClassName">�N���X���̊i�[�o�b�t�@�B</param>
        /// <param name="nMaxCount">�ő吔�B</param>
        /// <returns>�������B</returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// �e�L�X�g�̐ݒ�B
        /// </summary>
        /// <param name="hWnd">�E�B���h�E�n���h���B</param>
        /// <param name="lpString">�e�L�X�g�B</param>
        /// <returns>���ہB</returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool SetWindowText(IntPtr hWnd, string lpString);
    }
}
