using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.ToolStrip.
    /// </summary>
#else
    /// <summary>
    /// �c�[���X�g���b�v�ł��B
    /// </summary>
#endif
    public class FormsToolStrip : FormsControlBase
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
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł��B</param>
#endif
        public FormsToolStrip(WindowControl src)
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
        public FormsToolStrip(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

#if ENG
        /// <summary>
        /// Retrieves the item matching the specified series of key indices values.
        /// </summary>
        /// <param name="indexes">Series of indices leading to the item to retrieve.</param>
        /// <returns>Found child item.</returns>
#else
        /// <summary>
        /// �q�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="indexes">�C���f�b�N�X�B</param>
        /// <returns>�q�A�C�e��</returns>
#endif
        public FormsToolStripItem GetItem(params int[] indexes)
        {
            return new FormsToolStripItem(App, App[GetType(), "GetItemInTarget"](AppVar, indexes));
        }

#if ENG
        /// <summary>
        /// Retrieves the item matching the specified series of key values.
        /// </summary>
        /// <param name="keys">Key values.</param>
        /// <returns>Found child item.</returns>
#else
        /// <summary>
        /// �q�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="keys">�L�[�ƂȂ镶����ł��B</param>
        /// <returns>�q�A�C�e���B</returns>
#endif
        public FormsToolStripItem GetItem(params string[] keys)
        {
            return new FormsToolStripItem(App, App[GetType(), "GetItemInTarget"](AppVar, keys));
        }

#if ENG
        /// <summary>
        /// Retrieves the item matching the specified series of display values.
        /// </summary>
        /// <param name="texts">Display values.</param>
        /// <returns>Found child item.</returns>
#else
        /// <summary>
        /// �\�������񂩂�A�C�e�����������܂��B
        /// </summary>
        /// <param name="texts">�\��������B</param>
        /// <returns>�\��������B</returns>
#endif
        public FormsToolStripItem FindItem(params string[] texts)
        {
            return new FormsToolStripItem(App, App[GetType(), "FindItemInTarget"](AppVar, texts));
        }

        /// <summary>
        /// �A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="toolStrip">�c�[���X�g���b�v�B</param>
        /// <param name="indexes">�C���f�b�N�X�B</param>
        /// <returns>�A�C�e���B</returns>
        static ToolStripItem GetItemInTarget(ToolStrip toolStrip, params int[] indexes)
        {
            int currentIndex = 0;
            ToolStripItemCollection items = toolStrip.Items;
            while (true)
            {
                ToolStripItem current = items[indexes[currentIndex]];
                if (indexes.Length - 1 == currentIndex)
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
