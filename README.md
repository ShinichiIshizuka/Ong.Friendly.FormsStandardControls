Friendly.FormsStandardControls
============================

This library is a layer on top of
Friendly, so you must learn that first.
But it is very easy to learn.

https://github.com/Codeer-Software/Friendly.Windows

## Getting Started
Install Friendly.FormsStandardControls from NuGet

    Install-Package Ong.Friendly.FormsStandardControls
https://www.nuget.org/packages/Ong.Friendly.FormsStandardControls/

***
Friendly.FormsStandardControls defines the following classes.   
They can operate WinForms control easily from a separate process.  

* FormsButton
* FormsCheckBox
* FormsCheckedListBox
* FormsComboBox
* FormsControlBase
* FormsDataGridView
* FormsDateTimePicker
* FormsLinkLabel
* FormsListBox
* FormsListView
* FormsMaskedTextBox
* FormsMonthCalendar
* FormsNumericUpDown
* FormsProgressBar
* FormsRadioButton
* FormsRichTextBox
* FormsTabControl
* FormsTextBox
* FormsToolStrip
* FormsToolStripButton
* FormsToolStripComboBox
* FormsToolStripItem
* FormsToolStripTextBox
* FormsTrackBar
* FormsTreeView

***
```cs  
//sample  
var process = Process.GetProcessesByName("WPFTarget")[0];  
using (var app = new WindowsAppFriend(process))  
{  
    dynamic main = app.Type(typeof(Application)).OpenForms[0];  
    var grid = new FormsDataGridView(main._grid);  
    grid.EmulateChangeCellText(0, 0, "abc");  
    grid.EmulateChangeCellComboSelect(1, 0, 2);  
    grid.EmulateCellCheck(2, 0, true);  
}  
```
### More samples.
https://github.com/ShinichiIshizuka/Ong.Friendly.FormsStandardControls/tree/master/Project/Test/FormsTest

***
For other GUI types, use the following libraries:

* For Win32.  
https://www.nuget.org/packages/Codeer.Friendly.Windows.NativeStandardControls/  

* For WPF.  
https://www.nuget.org/packages/RM.Friendly.WPFStandardControls/

* For getting the target window.  
https://www.nuget.org/packages/Codeer.Friendly.Windows.Grasp/  

***
If you use PinInterface, you map control simple.  
https://www.nuget.org/packages/VSHTC.Friendly.PinInterface/



