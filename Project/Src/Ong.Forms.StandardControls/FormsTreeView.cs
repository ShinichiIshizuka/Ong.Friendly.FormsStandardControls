using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.TreeView.
    /// </summary>
#else
    /// <summary>
    /// Type��System.Windows.Forms.TreeView�̃E�B���h�E�ɑΉ����������񋟂��܂��B
    /// </summary>
#endif
    public class FormsTreeView : FormsControlBase
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
        public FormsTreeView(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ��B</param>
#endif
        public FormsTreeView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Returns the currently selected node.
        /// </summary>
#else
        /// <summary>
        /// �I�����Ă���m�[�h���擾���܂��B
        /// </summary>
#endif
        public FormsTreeNode SelectNode
        {
            get { return new FormsTreeNode(App, this["SelectedNode"]()); }
        }

#if ENG
        /// <summary>
        /// I get the child items.
        /// </summary>
        /// <param name="indexes">Index.</param>
        /// <returns>Child items.</returns>
#else
        /// <summary>
        /// �q�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="indexes">�C���f�b�N�X�B</param>
        /// <returns>�q�A�C�e���B</returns>
#endif
        public FormsTreeNode GetItem(params int[] indexes)
        {
            return new FormsTreeNode(App, App[GetType(), "GetItemInTarget"](AppVar, indexes));
        }

#if ENG
        /// <summary>
        /// I get the child items.
        /// </summary>
        /// <param name="keys">A string of the key.</param>
        /// <returns>Child items.</returns>
#else
        /// <summary>
        /// �q�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="keys">�L�[�ƂȂ�C���f�b�N�X�ł��B</param>
        /// <returns>�q�A�C�e���B</returns>
#endif
        public FormsTreeNode GetItem(params string[] keys)
        {
            return new FormsTreeNode(App, App[GetType(), "GetItemInTarget"](AppVar, keys));
        }

#if ENG
        /// <summary>
        /// Searches for items with the indicated display strings.
        /// </summary>
        /// <param name="texts">Display strings.</param>
        /// <returns>Child items.</returns>
#else
        /// <summary>
        /// �\�������񂩂�A�C�e�����������܂��B
        /// </summary>
        /// <param name="texts">�\��������B</param>
        /// <returns>�q�A�C�e���B</returns>
#endif
        public FormsTreeNode FindItem(params string[] texts)
        {
            return new FormsTreeNode(App, App[GetType(), "FindItemInTarget"](AppVar, texts));
        }

#if ENG
        /// <summary>
        /// Selects a certain node.
        /// </summary>
        /// <param name="node">Node to select.</param>
#else
        /// <summary>
        /// �m�[�h��I�����܂��B
        /// </summary>
        /// <param name="node">�m�[�h�B</param>
#endif
        public void EmulateNodeSelect(FormsTreeNode node)
        {
            App[GetType(), "EmulateNodeSelectInTarget"](AppVar, node.AppVar);
        }

#if ENG
        /// <summary>
        /// Selects a certain node.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="node">Node to select.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// �m�[�h��I�����܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="node">�m�[�h�B</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g�B</param>
#endif
        public void EmulateNodeSelect(FormsTreeNode node, Async async)
        {
            App[GetType(), "EmulateNodeSelectInTarget", async](AppVar, node.AppVar);
        }

        /// <summary>
        /// �m�[�h��I�����܂��B
        /// �񓯊��Ŏ��s���܂��B
        /// </summary>
        /// <param name="tree">�c���[�B</param>
        /// <param name="node">�m�[�h�B</param>
        static void EmulateNodeSelectInTarget(TreeView tree, TreeNode node)
        {
            tree.Focus();
            tree.SelectedNode = node;
        }

        /// <summary>
        /// �A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="trerview">�c���[�r���[�B</param>
        /// <param name="indexes">�C���f�b�N�X�B</param>
        /// <returns>�A�C�e��</returns>
        static TreeNode GetItemInTarget(TreeView trerview, params int[] indexes)
        {
            int currentIndex = 0;
            TreeNodeCollection items = trerview.Nodes;
            while (true)
            {
                TreeNode current = items[indexes[currentIndex]];
                if (indexes.Length - 1 == currentIndex)
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
        static TreeNode GetItemInTarget(TreeView trerview, params string[] keys)
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
        static TreeNode FindItemInTarget(TreeView trerview, string[] texts)
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