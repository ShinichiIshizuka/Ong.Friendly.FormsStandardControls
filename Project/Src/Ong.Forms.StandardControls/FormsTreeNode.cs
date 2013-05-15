using System;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using Codeer.Friendly.Windows;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// �c���[�m�[�h
    /// </summary>
    public class FormsTreeNode:AppVarWrapper
    {
        WindowsAppFriend _app;

        //@@@ FindNode��ǉ�
        //����iExpand�̋t�j
        //Edit,Check��ǉ�

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsTreeNode(WindowsAppFriend app, AppVar appVar)
            : base(appVar)
        {
            _app = app;
        }
    
        /// <summary>
        /// �m�[�h
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�m�[�h</returns>
        public FormsTreeNode GetNode(int index)
        {
            return new FormsTreeNode(_app, AppVar["Nodes"]()["[]"](index));
        }

        /// <summary>
        /// �e�L�X�g��ύX���܂�
        /// </summary>
        /// <param name="newText">�V���ȃe�L�X�g</param>
        public void EmulateChangeText(string newText)
        {
            this["Text"](newText);
        }

        /// <summary>
        /// �e�L�X�g��ύX���܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="newText">�V���ȃe�L�X�g</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateChangeText(string newText, Async async)
        {
            this["Text", async](newText);
        }

        /// <summary>
        /// �e�L�X�g���擾���܂�
        /// </summary>
        /// <returns>�e�L�X�g</returns>
        public String Text
        {
            get { return (String)this["Text"]().Core; }
        }

        /// <summary>
        /// �W�J���Ă��邩���擾���܂�
        /// </summary>
        /// <returns>true:�W�J</returns>
        public bool IsExpanded
        {
            get { return (bool)this["IsExpanded"]().Core; }
        }

        /// <summary>
        /// �W�J���܂�
        /// </summary>
        public void EmulateExpand()
        {
            this["Expand"](); 
        }

        /// <summary>
        /// �W�J���܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        public void EmulateExpand(Async async)
        {
            this["Expand", async]();
        }

        /// <summary>
        /// �m�[�h���w�肳�ꂽ�e�L�X�g�Ō������܂�
        /// </summary>
        /// <param name="nodeText">�e�m�[�h�̃e�L�X�g</param>
        /// <returns>�������ꂽ�m�[�h�̃A�C�e���n���h���B����������null���Ԃ�܂�</returns>
        public FormsTreeNode FindNode(string nodeText)
        {
            AppVar returnNode = (_app[GetType(), "FindNodeInTarget"](AppVar, nodeText));
            if (returnNode != null)
            {
                return new FormsTreeNode(_app, returnNode);
            }
            return null;
        }

        /// <summary>
        /// �m�[�h���w�肳�ꂽ�e�L�X�g�Ō������܂��i�����j
        /// </summary>
        /// <param name="treeNode">�m�[�h</param>
        /// <param name="nodeText">��������e�L�X�g</param>
        /// <returns></returns>
        private static TreeNode FindNodeInTarget(TreeNode treeNode, string nodeText)
        {
            TreeNode findNode;
            if (treeNode == null)
            {
                return null;
            }
            if (treeNode.Text == nodeText)
            {
                return treeNode;
            }
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Text == nodeText)
                {
                    return node;
                }
                findNode = FindNodeInTarget(node, nodeText);
                if (findNode != null)
                {
                    return findNode;
                }
            }
            return null;
        }
    }
}
