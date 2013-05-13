using System.Windows.Forms;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��WindowControl��System.Windows.Forms.TreeView�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsTreeView : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsTreeView(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsTreeView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �I�����Ă���m�[�h���擾���܂�
        /// </summary>
        public FormsTreeNode SelectNode
        {
            get
            {
                return new FormsTreeNode(App, this["SelectedNode"]());
            }
        }

        /// <summary>
        /// �m�[�h��I�����܂�
        /// </summary>
        /// <param name="node">�m�[�h</param>
        public void EmulateNodeSelect(FormsTreeNode node)
        {
            this["SelectedNode"](node.AppVar);
        }

        /// <summary>
        /// �m�[�h��I�����܂�
        /// �񓯊��Ŏ��s���܂�
        /// </summary>
        /// <param name="node">�m�[�h</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g</param>
        public void EmulateNodeSelect(FormsTreeNode node, Async async)
        {
            this["SelectedNode", async](node.AppVar);
        }

        /// <summary>
        /// �m�[�h���w�肳�ꂽ�e�L�X�g�Ō������܂�
        /// </summary>
        /// <param name="nodeText">�e�m�[�h�̃e�L�X�g</param>
        /// <returns>�������ꂽ�m�[�h�̃A�C�e���n���h���B����������null���Ԃ�܂�</returns>
        public FormsTreeNode FindNode(string nodeText)
        {
            AppVar returnNode = (App[GetType(), "FindNodeInTarget"](AppVar, nodeText));
            if (returnNode != null)
            {
                return new FormsTreeNode(App, returnNode);
            }
            return null;
        }

        /// <summary>
        /// �m�[�h���w�肳�ꂽ�e�L�X�g�Ō������܂��i�����j
        /// </summary>
        /// <param name="treeview">�c���[�r���[</param>
        /// <param name="nodeText">��������e�L�X�g</param>
        /// <returns>�e�L�X�g�ƈ�v����m�[�h��ԋp���܂��B���݂��Ȃ��ꍇ��null,�������������ꍇ�͍ŏ��̃m�[�h��ԋp���܂�</returns>
        private static TreeNode FindNodeInTarget(TreeView treeview,string nodeText)
        {
            if (treeview.Nodes.Count > 0)
            {
                TreeNode treeNode = FindNodeInTargetCore(treeview.Nodes[0], nodeText);
                if (treeNode != null)
                {
                    return treeNode;
                }
            }
            return null;
        }

        /// <summary>
        /// �m�[�h���w�肳�ꂽ�e�L�X�g�Ō������܂��i�����j
        /// </summary>
        /// <param name="treeNode">�m�[�h</param>
        /// <param name="nodeText">��������e�L�X�g</param>
        /// <returns></returns>
        private static TreeNode FindNodeInTargetCore(TreeNode treeNode,string nodeText)
        {
            TreeNode findNode;
            if(treeNode == null)
            {
                return null;
            }
            if(treeNode.Text == nodeText)
            {
                return treeNode;
            }
            foreach(TreeNode node in treeNode.Nodes)
            {
                if(node.Text == nodeText)
                {
                    return node;
                }
                findNode = FindNodeInTargetCore(node, nodeText);
                if(findNode != null)
                {   
                    return findNode;
                }
            }
            return null;
        }
    }
}