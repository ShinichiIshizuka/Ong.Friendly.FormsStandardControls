using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls.Properties;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ���X�g�A�C�e���ł��B
    /// </summary>
    public class FormsListViewItem : AppVarWrapper
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="item">�A�C�e���B</param>
        public FormsListViewItem(WindowsAppFriend app, AppVar item)
            : base(app, item) { }
    
        /// <summary>
        /// �e�L�X�g���擾���܂��B
        /// </summary>
        /// <returns>�e�L�X�g�B</returns>
        public string Text
        {
            get { return (string)this["Text"]().Core; }
        }

        /// <summary>
        /// �A�C�e���C���f�b�N�X���擾���܂��B
        /// </summary>
        /// <returns>�s�ԍ��B</returns>
        public int ItemIndex
        {
            get { return (int)this["Index"]().Core; }
        }

        /// <summary>
        /// �`�F�b�N��Ԃ��擾���܂��B
        /// </summary>
        public bool Checked
        {
            get { return (bool)this["Checked"]().Core; }
        }

        /// <summary>
        /// �T�u�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="subitemindex">�T�u�A�C�e���C���f�b�N�X�B</param>
        /// <returns></returns>
        public FormsListViewSubItem GetSubItem(int subitemindex)
        {
            return new FormsListViewSubItem(App, App[GetType(), "GetSubItemInTarget"](AppVar, subitemindex));
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="value">�`�F�b�N��ԁB</param>
        public void EmulateCheck(bool value)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, value);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="value">�`�F�b�N��ԁB</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateCheck(bool value, Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar, value);
        }

        /// <summary>
        /// �e�L�X�g��ҏW���܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        public void EmulateEditLabel(string text)
        {
            App[GetType(), "EmulateEditLabelInTarget"](AppVar, text);
        }

        /// <summary>
        /// �e�L�X�g��ҏW���܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
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
                throw new NotSupportedException(Resources.ErrorNotSetListView);
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
                throw new NotSupportedException(Resources.ErrorNotSetListView);
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
