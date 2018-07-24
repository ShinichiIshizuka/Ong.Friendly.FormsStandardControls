using Codeer.TestAssistant.GeneratorToolKit;
using System;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls.Generator
{
#if ENG
    /// <summary>
    /// This class generates operation codes for FormsMdiClient.
    /// </summary>
#else
    /// <summary>
    /// FormsMdiClientの操作コードを生成します。
    /// </summary>
#endif
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsMdiClient")]
    public class FormsMdiClientGenerator : CaptureCodeGeneratorBase
    {
        Form _form;

#if ENG
        /// <summary>
        /// Attach.
        /// </summary>
#else
        /// <summary>
        /// アタッチ。
        /// </summary>
#endif
        protected override void Attach()
        {
            _form = GetParentForm((Control)ControlObject);
            _form.MdiChildActivate += MdiChildActivate;
        }

#if ENG
        /// <summary>
        /// Detach.
        /// </summary>
#else
        /// <summary>
        /// ディタッチ。
        /// </summary>
#endif
        protected override void Detach()
        {
            _form.MdiChildActivate -= MdiChildActivate;
        }

        static Form GetParentForm(Control c)
        {
            while (c != null && !(c is Form)) c = c.Parent;
            return c as Form;
        }

        void MdiChildActivate(object sender, EventArgs e)
        {
            if (_form.ActiveMdiChild == null) return;

            int index = -1;
            bool textMode = true;
            for (int i = 0; i < _form.MdiChildren.Length; i++)
            {
                if (ReferenceEquals(_form.ActiveMdiChild, _form.MdiChildren[i]))
                {
                    index = i;
                }
                else
                {
                    if (_form.MdiChildren[i].Text == _form.ActiveMdiChild.Text)
                    {
                        textMode = false;
                    }
                }
            }
            if (textMode)
            {
                AddSentence(new TokenName(), ".EmulateChangeActiveMdiChild(", "\"" + _form.ActiveMdiChild.Text + "\"", new TokenAsync(CommaType.Before), ");");
            }
            else
            {
                AddSentence(new TokenName(), ".EmulateChangeActiveMdiChild(", index, new TokenAsync(CommaType.Before), ");");
            }
        } 
    }
}
