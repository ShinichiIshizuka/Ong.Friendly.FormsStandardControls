using System;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// �c���[�m�[�h�ł��B
    /// </summary>
    public class FormsTreeNode : AppVarWrapper
    {
        WindowsAppFriend _app;

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsTreeNode(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            _app = app;
        }

        /// <summary>
        /// �e�L�X�g���擾���܂��B
        /// </summary>
        /// <returns>�e�L�X�g�B</returns>
        public string Text
        {
            get { return (string)this["Text"]().Core; }
        }

        /// <summary>
        /// �W�J���Ă��邩���擾���܂��B
        /// </summary>
        /// <returns>true:�W�J�B</returns>
        public bool IsExpanded
        {
            get { return (bool)this["IsExpanded"]().Core; }
        }

        /// <summary>
        /// �`�F�b�N��Ԃ��擾���܂��B
        /// </summary>
        public bool Checked
        {
            get { return (bool)(this["Checked"]().Core); }
        }

        /// <summary>
        /// �W�J���܂��B
        /// </summary>
        public void EmulateExpand()
        {
            App[GetType(), "EmulateExpandInTarget"](AppVar);
        }

        /// <summary>
        /// �W�J���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        public void EmulateExpand(Async async)
        {
            App[GetType(), "EmulateExpandInTarget", async](AppVar);
        }

        /// <summary>
        /// �W�J����܂��B
        /// </summary>
        public void EmulateCollapse()
        {
            App[GetType(), "EmulateCollapseInTarget"](AppVar);
        }

        /// <summary>
        /// �W�J����܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        public void EmulateCollapse(Async async)
        {
            App[GetType(), "EmulateCollapseInTarget", async](AppVar);
        }

        /// <summary>
        /// �m�[�h����ҏW���܂��B
        /// </summary>
        /// <param name="nodeText">�e�L�X�g�B</param>
        public void EmulateEditLabel(string nodeText)
        {
            App[GetType(), "EmulateEditLabelInTarget"](AppVar, nodeText);
        }

        /// <summary>
        /// �m�[�h����ҏW���܂�(�񓯊�)�B
        /// </summary>
        /// <param name="nodeText">�e�L�X�g�B</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g�B</param>
        public void EmulateEditLabel(string nodeText, Async async)
        {
            App[GetType(), "EmulateEditLabelInTarget", async](AppVar, nodeText);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="check">true:�`�F�b�N</param>
        public void EmulateCheck(bool check)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, check);
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="check">true:�`�F�b�N</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g</param>
        public void EmulateCheck(bool check, Async async)
        {
            App[GetType(), "EmulateCheckInTarget", async](AppVar, check);
        }

        /// <summary>
        /// �W�J���܂��B
        /// </summary>
        /// <param name="treeNode">�m�[�h�B</param>
        private static void EmulateExpandInTarget(TreeNode treeNode)
        {
            treeNode.TreeView.Focus();
            treeNode.Expand();
        }

        /// <summary>
        /// �W�J���Ƃ��܂��B
        /// </summary>
        /// <param name="treeNode">�m�[�h�B</param>
        private static void EmulateCollapseInTarget(TreeNode treeNode)
        {
            treeNode.TreeView.Focus();
            treeNode.Collapse();
        }

        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="treeNode">�m�[�h�B</param>
        /// <param name="check">true:�`�F�b�N</param>
        private static void EmulateCheckInTarget(TreeNode treeNode, bool check)
        {
            treeNode.TreeView.Focus();
            treeNode.Checked = check;
        }

        /// <summary>
        /// �m�[�h����ҏW���܂��i�����j�B
        /// </summary>
        /// <param name="treeNode">�m�[�h�B</param>
        /// <param name="nodeText">�e�L�X�g�B</param>
        private static void EmulateEditLabelInTarget(TreeNode treeNode, string nodeText)
        {
            treeNode.TreeView.Focus();
            treeNode.BeginEdit();
            treeNode.Text = nodeText;
            treeNode.EndEdit(false);
        }
    }
}
