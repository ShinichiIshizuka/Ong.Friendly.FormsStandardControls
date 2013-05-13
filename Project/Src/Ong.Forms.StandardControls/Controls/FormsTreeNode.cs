using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// �c���[�m�[�h
    /// </summary>
    public class FormsTreeNode:AppVarWrapper
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsTreeNode(AppVar appVar)
            : base(appVar)
        {
        }
    
        /// <summary>
        /// �m�[�h
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�m�[�h</returns>
        public FormsTreeNode GetNode(int index)
        {
            return new FormsTreeNode(AppVar["Nodes"]()["[]"](index));
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
    }
}
