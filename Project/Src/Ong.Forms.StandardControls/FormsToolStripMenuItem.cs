using Codeer.Friendly;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// �c�[���X�g���b�v�A�C�e������N���X
    /// </summary>
    public class FormsToolStripMenuItem : FormsToolStripItem
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="appVar">�ΏۃA�v���P�[�V�������ϐ�����N���X</param>
        public FormsToolStripMenuItem(AppVar appVar) : base(appVar) { }

        /// <summary>
        /// �q�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X�B</param>
        /// <returns></returns>
        public FormsToolStripItem GetItem(int index)
        {
            return new FormsToolStripItem(this["DropDownItems"](index));
        }

        /// <summary>
        /// �q�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="key">�L�[�ƂȂ�C���f�b�N�X�ł��B</param>
        /// <returns></returns>
        public FormsToolStripMenuItem GetItem(string key)
        {
            return new FormsToolStripMenuItem(this["DropDownItems"](key));
        }

        /// <summary>
        /// �\�������񂩂�A�C�e�����������܂��B
        /// </summary>
        /// <param name="text">�\��������</param>
        /// <returns>�\��������</returns>
        public FormsToolStripMenuItem FindItem(string text)
        {
            foreach (AppVar element in new Enumerate(this["DropDownItems"]()))
            {
                if (element["Text"]().ToString() == text)
                {
                    return new FormsToolStripMenuItem(element);
                }
            }
            return null;
        }
    }
}
