using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// �c�[���X�g���b�v
    /// </summary>
    public class FormsToolStrip : WindowControl
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
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <returns></returns>
        public FormsToolStripItem GetItem(int index)
        {
            return new FormsToolStripItem(this["Items"](index));
        }

        /// <summary>
        /// �q�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="key">�L�[�ƂȂ�C���f�b�N�X�ł��B</param>
        /// <returns></returns>
        public FormsToolStripItem GetItem(string key)
        {
            return new FormsToolStripItem(this["Items"](key));
        }

        /// <summary>
        /// �\�������񂩂�A�C�e�����������܂��B
        /// </summary>
        /// <param name="text">�\��������</param>
        /// <returns>�\��������</returns>
        public FormsToolStripItem FindItem(string text)
        {
            foreach (AppVar element in new Enumerate(this["Items"]()))
            {
                if (element["Text"]().ToString() == text)
                {
                    return new FormsToolStripItem(element);
                }
            }
            return null;
        }
    }
}
