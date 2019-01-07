using System;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using Ong.Friendly.FormsStandardControls.Generator.CreateDriver;

namespace CreateDriverTarget
{
    public partial class UserControlForm : Form
    {
        public UserControlForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            using (var dom = CodeDomProvider.CreateProvider("CSharp"))
            {
                new WinFormsDriverCreator(dom).CreateDriver(this);
            }

            Close();
        }
    }
}
