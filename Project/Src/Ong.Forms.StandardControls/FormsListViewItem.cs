using System;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// ���X�g�A�C�e��
    /// </summary>
    public class FormsListViewItem:AppVarWrapper
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsListViewItem(AppVar appVar)
            : base(appVar)
        {
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
        /// �s���擾���܂�
        /// </summary>
        /// <returns>�s�ԍ�</returns>
        public int RowIndex
        {
            get { return (int)this["Index"]().Core; }
        }
    }
}
