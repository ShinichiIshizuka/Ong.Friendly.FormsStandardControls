using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows;
using Codeer.Friendly;
using Ong.Friendly.FormsStandardControls.Inside;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// Type��System.Windows.Forms.ListBox�̃E�B���h�E�ɑΉ����������񋟂��܂�
    /// </summary>
    public class FormsListBox : FormsControlBase
    {
        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="src">���ƂȂ�E�B���h�E�R���g���[���ł�</param>
        public FormsListBox(WindowControl src)
            : base(src)
        {
            Initializer.Initialize(App, GetType());
        }

        /// <summary>
        /// �R���X�g���N�^�ł�
        /// </summary>
        /// <param name="app">�A�v���P�[�V��������N���X</param>
        /// <param name="appVar">�A�v���P�[�V�������ϐ�</param>
        public FormsListBox(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar)
        {
            Initializer.Initialize(app, GetType());
        }

        /// <summary>
        /// �ꗗ�̃A�C�e�������擾���܂�
        /// </summary>
        public int ItemCount
        {
            get 
            {
                return (int)(this["Items"]()["Count"]().Core);
            }
        }

        /// <summary>
        /// ���ݑI������Ă���A�C�e���̃C���f�b�N�X���擾���܂�
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return (int)(this["SelectedIndex"]().Core);
            }
        }
        
        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂�
        /// </summary>
        public void EmulateChangeSelectedIndex(int Index)
        {
            this["SelectedIndex"](Index);
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂�
        /// �񓯊��Ɏ��s���܂�
        /// </summary>
        /// <param name="Index">�C���f�b�N�X</param>
        /// <param name="async">�񓯊����s�I�u�W�F�N�g</param>
        public void EmulateChangeSelectedIndex(int Index, Async async)
        {
            this["SelectedIndex", async](Index);
        }

        /// <summary>
        /// �A�C�e�����w�肳�ꂽ�e�L�X�g�Ō������܂�
        /// </summary>
        /// <param name="ItemText">�e�m�[�h�̃e�L�X�g</param>
        /// <returns>�������ꂽ�m�[�h�̃A�C�e���n���h���B����������null���Ԃ�܂�</returns>
        public int FindListIndex(string ItemText)
        {
            return (int)(this["FindString"](ItemText).Core);
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂�
        /// </summary>
        /// <param name="indexs">�A�C�e���ԍ�</param>
        /// <param name="async">�񓯊��I�u�W�F�N�g</param>
        public void EmulateChangeSelectedIndexes(int[] indexs, Async async)
        {
            App[GetType(), "ChangeSelectedIndexesTarget", async](AppVar, indexs);
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X�ɊY������A�C�e����I����Ԃɂ��܂�
        /// </summary>
        public void EmulateChangeSelectedIndexes(int[] indexs)
        {
            App[GetType(), "ChangeSelectedIndexesTarget"](AppVar, indexs);
        }

        /// <summary>
        /// ���X�g�A�C�e���I���i�����j
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="indexs"></param>
        private static void ChangeSelectedIndexesTarget(ListBox listbox, int[] indexs)
        {
            for (int i = 0; i < indexs.Length; i ++)
            {
                listbox.SetSelected(indexs[i], true);
            }
        }

        /// <summary>
        /// �I����Ԃ̃��X�g���ڈꗗ���擾���܂�
        /// </summary>
        public int[] EmulateGetSelectedIndexes()
        {
            return (int[])(App[GetType(), "GetSelectedIndexesTarget"](AppVar).Core);
        }

        /// <summary>
        /// ���X�g�A�C�e���I���i�����j
        /// </summary>
        /// <param name="listbox"></param>
        private static int[] GetSelectedIndexesTarget(ListBox listbox)
        {
            List<int> list = new List<int>();
            ListBox.SelectedIndexCollection collection = listbox.SelectedIndices;
            for (int index = 0; index < collection.Count; index++)
            {
                list.Add(collection[index]);
            }
            return list.ToArray();
        }
    }
}
