using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// �c�[���X�g���b�v
    /// </summary>
    public class FormsToolStrip : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł��B</param>
        public FormsToolStrip(WindowControl src)
            : base(src) { }

        /// <summary>
        /// �R���X�g���N�^�ł��B
		/// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X�B</param>
        /// <param name="windowHandle">�E�B���h�E�n���h���B</param>
        public FormsToolStrip(WindowsAppFriend app, AppVar windowHandle)
            : base(app, windowHandle) { }

        /// <summary>
        /// �q�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="indexs">�C���f�b�N�X�B</param>
        /// <returns>�q�A�C�e��</returns>
        public FormsToolStripItem GetItem(params int[] indexs)
        {
            return new FormsToolStripItem(App, App[GetType(), "GetItemInTarget"](AppVar, indexs));
        }

        /// <summary>
        /// �q�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="keys">�L�[�ƂȂ�C���f�b�N�X�ł��B</param>
        /// <returns>�q�A�C�e��</returns>
        public FormsToolStripItem GetItem(params string[] keys)
        {
            return new FormsToolStripItem(App, App[GetType(), "GetItemInTarget"](AppVar, keys));
        }

        /// <summary>
        /// �\�������񂩂�A�C�e�����������܂��B
        /// </summary>
        /// <param name="texts">�\��������B</param>
        /// <returns>�\��������B</returns>
        public FormsToolStripItem FindItem(params string[] texts)
        {
            return new FormsToolStripItem(App, App[GetType(), "FindItemInTarget"](AppVar, texts));
        }

        /// <summary>
        /// �A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="toolStrip">�c�[���X�g���b�v�B</param>
        /// <param name="indexs">�C���f�b�N�X�B</param>
        /// <returns>�A�C�e���B</returns>
        static ToolStripItem GetItemInTarget(ToolStrip toolStrip, params int[] indexs)
        {
            int currentIndex = 0;
            ToolStripItemCollection items = toolStrip.Items;
            while (true)
            {
                ToolStripItem current = items[indexs[currentIndex]];
                if (indexs.Length - 1 == currentIndex)
                {
                    return current;
                }
                else
                {
                    currentIndex++;
                }
                ToolStripDropDownItem dropDown = current as ToolStripDropDownItem;
                if (dropDown == null)
                {
                    return null;
                }
                items = dropDown.DropDownItems;
            }
        }

        /// <summary>
        /// �A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="toolStrip">�c�[���X�g���b�v�B</param>
        /// <param name="keys">�C���f�b�N�X�B</param>
        /// <returns>�A�C�e���B</returns>
        static ToolStripItem GetItemInTarget(ToolStrip toolStrip, params string[] keys)
        {
            int currentIndex = 0;
            ToolStripItemCollection items = toolStrip.Items;
            while (true)
            {
                ToolStripItem current = items[keys[currentIndex]];
                if (keys.Length - 1 == currentIndex)
                {
                    return current;
                }
                else
                {
                    currentIndex++;
                }
                ToolStripDropDownItem dropDown = current as ToolStripDropDownItem;
                if (dropDown == null)
                {
                    return null;
                }
                items = dropDown.DropDownItems;
            }
        }

        /// <summary>
        /// �\�������񂩂�A�C�e�����������܂��B
        /// </summary>
        /// <param name="toolStrip">�c�[���X�g���b�v�B</param>
        /// <param name="texts">�\��������B</param>
        /// <returns>�A�C�e���B</returns>
        static ToolStripItem FindItemInTarget(ToolStrip toolStrip, string[] texts)
        {
            int currentIndex = 0;
            ToolStripItemCollection items = toolStrip.Items;
            while (true)
            {
                ToolStripItem current = null;
                foreach (ToolStripItem element in items)
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
                ToolStripDropDownItem dropDown = current as ToolStripDropDownItem;
                if (dropDown == null)
                {
                    return null;
                }
                items = dropDown.DropDownItems;
            }
        }
    }
}
