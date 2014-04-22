using System;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Ong.Friendly.FormsStandardControls.Properties;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on tree nodes.
    /// </summary>
#else
    /// <summary>
    /// �c���[�m�[�h�ł��B
    /// </summary>
#endif
    public class FormsTreeNode : AppVarWrapper
    {
#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsTreeNode(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// ���ݔ񐄏��ł��B
        /// FormsTreeNode(AppVar windowObject)���g�p���Ă��������B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
#endif
        [Obsolete("Please use FormsTreeNode(AppVar windowObject).", false)]
        public FormsTreeNode(WindowsAppFriend app, AppVar appVar)
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
        public FormsTreeNode(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Returns the node's text.
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
        /// Returns true if the node is expanded.
        /// </summary>
#else
        /// <summary>
        /// �W�J���Ă��邩���擾���܂��B
        /// </summary>
#endif
        public bool IsExpanded
        {
            get { return (bool)this["IsExpanded"]().Core; }
        }

#if ENG
        /// <summary>
        /// Returns true if the node is currently checked.
        /// </summary>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ��擾���܂��B
        /// </summary>
#endif
        public bool Checked
        {
            get { return (bool)(this["Checked"]().Core); }
        }

#if ENG
        /// <summary>
        /// Expands the node.
        /// </summary>
#else
        /// <summary>
        /// �W�J���܂��B
        /// </summary>
#endif
        public void EmulateExpand()
        {
            App[GetType(), "EmulateExpandInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Expands the node.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �W�J���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateExpand(Async async)
        {
            App[GetType(), "EmulateExpandInTarget", async](AppVar);
        }

#if ENG
        /// <summary>
        /// Collapses the node.
        /// </summary>
#else
        /// <summary>
        /// �W�J����܂��B
        /// </summary>
#endif
        public void EmulateCollapse()
        {
            App[GetType(), "EmulateCollapseInTarget"](AppVar);
        }

#if ENG
        /// <summary>
        /// Collapses the node.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �W�J����܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g�B</param>
#endif
        public void EmulateCollapse(Async async)
        {
            App[GetType(), "EmulateCollapseInTarget", async](AppVar);
        }

#if ENG
        /// <summary>
        /// Modifies the node's text.
        /// </summary>
        /// <param name="nodeText">New text to use.</param>
#else
        /// <summary>
        /// �m�[�h����ҏW���܂��B
        /// </summary>
        /// <param name="nodeText">�e�L�X�g�B</param>
#endif
        public void EmulateEditLabel(string nodeText)
        {
            App[GetType(), "EmulateEditLabelInTarget"](AppVar, nodeText);
        }

#if ENG
        /// <summary>
        /// Modifies the node's text.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="nodeText">New text to use.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �m�[�h����ҏW���܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="nodeText">�e�L�X�g�B</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g�B</param>
#endif
        public void EmulateEditLabel(string nodeText, Async async)
        {
            App[GetType(), "EmulateEditLabelInTarget", async](AppVar, nodeText);
        }

#if ENG
        /// <summary>
        /// Sets the node's checked state.
        /// </summary>
        /// <param name="check">true to set the node as checked.</param>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="check">true:�`�F�b�N</param>
#endif
        public void EmulateCheck(bool check)
        {
            App[GetType(), "EmulateCheckInTarget"](AppVar, check);
        }

#if ENG
        /// <summary>
        /// Sets the node's checked state.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="check">true to set the node as checked.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �`�F�b�N��Ԃ�ݒ肵�܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="check">true:�`�F�b�N</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g</param>
#endif
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
            if (treeNode.TreeView == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetTreeView);
            }
            treeNode.TreeView.Focus();
            treeNode.Expand();
        }

        /// <summary>
        /// �W�J���Ƃ��܂��B
        /// </summary>
        /// <param name="treeNode">�m�[�h�B</param>
        private static void EmulateCollapseInTarget(TreeNode treeNode)
        {
            if (treeNode.TreeView == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetTreeView);
            }
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
            if (treeNode.TreeView == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetTreeView);
            }
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
            if (treeNode.TreeView == null)
            {
                throw new NotSupportedException(ResourcesLocal.Instance.ErrorNotSetTreeView);
            }
            treeNode.TreeView.Focus();
            treeNode.BeginEdit();
            treeNode.Text = nodeText;
            treeNode.EndEdit(false);
        }
    }
}
