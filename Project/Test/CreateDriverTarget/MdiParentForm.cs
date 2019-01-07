using System;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using Ong.Friendly.FormsStandardControls.Generator.CreateDriver;

namespace CreateDriverTarget
{
    public partial class MdiParentForm : Form
    {
        public MdiParentForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            new SingleForm { MdiParent = this }.Show();
            using (var dom = CodeDomProvider.CreateProvider("CSharp"))
            {
                new WinFormsDriverCreator(dom).CreateDriver(this);
            }

            Close();
        }
    }
}
