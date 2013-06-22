using System;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.Friendly.Windows;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ���X�g�A�C�e���ł��B
    /// </summary>
    public class FormsListViewItem : AppVarWrapper
    {
        AppVar _listView;

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="listView">���X�g�r���[�B</param>
        /// <param name="item">�A�C�e���B</param>
        public FormsListViewItem(WindowsAppFriend app, AppVar listView, AppVar item)
            : base(app, item)
        {
            _listView = listView;
        }
    
        /// <summary>
        /// �e�L�X�g���擾���܂��B
        /// </summary>
        /// <returns>�e�L�X�g�B</returns>
        public String Text
        {
            get { return (String)this["Text"]().Core; }
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
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="listviewitem">���X�g�r���[�A�C�e���B</param>
        /// <param name="value">�`�F�b�N��ԁB</param>
        static void EmulateCheckInTarget(ListViewItem listviewitem, bool value)
        {
            listviewitem.Checked = value;
        }

        /// <summary>
        /// �e�L�X�g��ҏW���܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        public void EmulateEditLabel(string text)
        {
            App[GetType(), "EmulateEditLabelInTarget"](_listView, AppVar, text);
        }

        /// <summary>
        /// �e�L�X�g��ҏW���܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g�B</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
        public void EmulateEditLabel(string text, Async async)
        {
            App[GetType(), "EmulateEditLabelInTarget", async](_listView, AppVar, text);
        }

        /// <summary>
        /// �e�L�X�g��ҏW���܂��B
        /// </summary>
        /// <param name="listView">���X�g�r���[�B</param>
        /// <param name="item">�A�C�e���B</param>
        /// <param name="text">�e�L�X�g�B</param>
        static void EmulateEditLabelInTarget(ListView listView, ListViewItem item, string text)
        {
            listView.Focus();

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
            EnumChildWindows(listView.Handle, proc, IntPtr.Zero);
            GC.KeepAlive(proc);

            //�e�L�X�g�ݒ�
            SetWindowText(edit, text);

            //�t�H�[�J�X�����X�g�r���[�ɖ߂��ҏW����
            listView.Focus();
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
        /// �E�B���h�E�����v���b�N�B
        /// </summary>
        /// <param name="hWnd">�E�B���h�E�n���h���B</param>
        /// <param name="lParam">�p�����[�^�B</param>
        /// <returns>�����𑱂��邩�B</returns>
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

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
        public static extern bool SetWindowText(IntPtr hWnd, String lpString);
    }
}
