using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��WindowControl��System.Windows.Forms.TreeView�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
    public class FormsTreeView : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���B</param>
        public FormsTreeView(WindowControl src)
            : base(src) { }

        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
        public FormsTreeView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// �I�����Ă���m�[�h���擾���܂��B
        /// </summary>
        public FormsTreeNode SelectNode
        {
            get { return new FormsTreeNode(App, this["SelectedNode"]()); }
        }

        /// <summary>
        /// �q�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="indexs">�C���f�b�N�X�B</param>
        /// <returns>�q�A�C�e���B</returns>
        public FormsTreeNode GetItem(params int[] indexs)
        {
            return new FormsTreeNode(App, App[GetType(), "GetItemInTarget"](AppVar, indexs));
        }

        /// <summary>
        /// �q�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="keys">�L�[�ƂȂ�C���f�b�N�X�ł��B</param>
        /// <returns>�q�A�C�e���B</returns>
        public FormsTreeNode GetItem(params string[] keys)
        {
            return new FormsTreeNode(App, App[GetType(), "GetItemInTarget"](AppVar, keys));
        }

        /// <summary>
        /// �\�������񂩂�A�C�e�����������܂��B
        /// </summary>
        /// <param name="texts">�\��������B</param>
        /// <returns>�\��������B</returns>
        public FormsTreeNode FindItem(params string[] texts)
        {
            return new FormsTreeNode(App, App[GetType(), "FindItemInTarget"](AppVar, texts));
        }

        /// <summary>
        /// �m�[�h��I�����܂��B
        /// </summary>
        /// <param name="node">�m�[�h�B</param>
        public void EmulateNodeSelect(FormsTreeNode node)
        {
            this["SelectedNode"](node.AppVar);
        }

        /// <summary>
        /// �m�[�h��I�����܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="node">�m�[�h�B</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g�B</param>
        public void EmulateNodeSelect(FormsTreeNode node, Async async)
        {
            this["SelectedNode", async](node.AppVar);
        }

        /// <summary>
        /// �A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="trerview">�c���[�r���[�B</param>
        /// <param name="indexs">�C���f�b�N�X�B</param>
        /// <returns>�A�C�e��</returns>
        private static TreeNode GetItemInTarget(TreeView trerview, params int[] indexs)
        {
            int currentIndex = 0;
            TreeNodeCollection items = trerview.Nodes;
            while (true)
            {
                TreeNode current = items[indexs[currentIndex]];
                if (indexs.Length - 1 == currentIndex)
                {
                    return current;
                }
                else
                {
                    currentIndex++;
                }
                TreeNode treenode = current as TreeNode;
                if (treenode == null)
                {
                    return null;
                }
                items = treenode.Nodes;
            }
        }

        /// <summary>
        /// �A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="trerview">�c���[�r���[�B</param>
        /// <param name="keys">�C���f�b�N�X�B</param>
        /// <returns>�A�C�e��</returns>
        private static TreeNode GetItemInTarget(TreeView trerview, params string[] keys)
        {
            int currentIndex = 0;
            TreeNodeCollection items = trerview.Nodes;
            while (true)
            {
                TreeNode current = items[keys[currentIndex]];
                if (keys.Length - 1 == currentIndex)
                {
                    return current;
                }
                else
                {
                    currentIndex++;
                }
                TreeNode treenode = current as TreeNode;
                if (treenode == null)
                {
                    return null;
                }
                items = treenode.Nodes;
            }
        }

        /// <summary>
        /// �\�������񂩂�A�C�e�����������܂��B
        /// </summary>
        /// <param name="trerview">�c���[�r���[�B</param>
        /// <param name="texts">�\��������B</param>
        /// <returns>�A�C�e���B</returns>
        private static TreeNode FindItemInTarget(TreeView trerview, string[] texts)
        {
            int currentIndex = 0;
            TreeNodeCollection items = trerview.Nodes;
            while (true)
            {
                TreeNode current = null;
                foreach (TreeNode element in items)
                {
                    if (element.Text == texts[currentIndex])
                    {
                        if (texts.Length - 1 == currentIndex)
                        {
                            return element;
                        }
                        else
                        {
                            current = element;
                            currentIndex++;
                            break;
                        }
                    }
                }
                TreeNode treenode = current as TreeNode;
                if (treenode == null)
                {
                    return null;
                }
                items = treenode.Nodes;
            }
        }
    }
}