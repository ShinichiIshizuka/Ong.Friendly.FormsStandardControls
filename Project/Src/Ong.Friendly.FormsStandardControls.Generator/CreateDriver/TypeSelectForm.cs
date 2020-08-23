using System;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls.Generator.CreateDriver
{
    /// <summary>
    /// TypeSelectForm
    /// </summary>
    public partial class TypeSelectForm : Form
    {
        /// <summary>
        /// SelectedType
        /// </summary>
        public Type SelectedType => (Type)_listBox.SelectedItem;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="types">Types.</param>
        public TypeSelectForm(Type[] types)
        {
            InitializeComponent();
            _listBox.Items.AddRange(types);
            _listBox.SelectedIndex = 0;
        }

        void ListBoxMouseDoubleClick(object sender, MouseEventArgs e)
            => DialogResult = DialogResult.OK;
    }
}
