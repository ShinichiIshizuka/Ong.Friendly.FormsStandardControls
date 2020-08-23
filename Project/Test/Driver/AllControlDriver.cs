using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;
using System.Linq;

namespace Driver
{
    [UserControlDriver(TypeFullName = "DemoApp.AllControl")]
    public class AllControlDriver
    {
        public WindowControl Core { get; }
        public FormsTrackBar trackBar => Core.Dynamic().trackBar; 
        public FormsMaskedTextBox maskedTextBox => Core.Dynamic().maskedTextBox; 
        public FormsNumericUpDown numericUpDown => Core.Dynamic().numericUpDown; 
        public FormsCheckedListBox checkedListBox => Core.Dynamic().checkedListBox; 
        public FormsDateTimePicker dateTimePicker => Core.Dynamic().dateTimePicker; 
        public FormsMonthCalendar monthCalendar => Core.Dynamic().monthCalendar; 
        public FormsProgressBar progressBar => Core.Dynamic().progressBar; 
        public FormsLinkLabel linkLabel => Core.Dynamic().linkLabel; 
        public FormsListView listView => Core.Dynamic().listView; 
        public FormsTabControl tabControl => Core.Dynamic().tabControl; 
        public FormsDataGridView dataGridView => Core.Dynamic().dataGridView; 
        public FormsRichTextBox richTextBox => Core.Dynamic().richTextBox; 
        public FormsTextBox textBox => Core.Dynamic().textBox; 
        public FormsRadioButton radioButton2 => Core.Dynamic().radioButton2; 
        public FormsRadioButton radioButton1 => Core.Dynamic().radioButton1; 
        public FormsListBox listBox => Core.Dynamic().listBox; 
        public FormsComboBox comboBox => Core.Dynamic().comboBox; 
        public FormsTreeView treeView => Core.Dynamic().treeView; 
        public FormsCheckBox checkBox => Core.Dynamic().checkBox; 
        public FormsButton button => Core.Dynamic().button; 
        public FormsToolStrip menuStrip => Core.Dynamic().menuStrip; 
        public FormsToolStrip toolStrip => Core.Dynamic().toolStrip; 
        public FormsToolStrip contextMenuStrip => Core.Dynamic().contextMenuStrip; 

        public AllControlDriver(WindowControl core)
        {
            Core = core;
        }

        public AllControlDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class AllControlDriverExtensions
    {
        [UserControlDriverIdentify]
        public static AllControlDriver AttachAllControl(this WindowsAppFriend app)
            => app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("DemoApp.AllControl")).FirstOrDefault()?.Dynamic();
    }
}