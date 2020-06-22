Friendly.FormsStandardControls
============================

This library is a layer on top of
Friendly, so you must learn that first.
But it is very easy to learn.

https://github.com/Codeer-Software/Friendly

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
The control driver is implemented using processing that uses the basic functions of Friendly.<br>
If you are using non-standard controls such as 3rd party controls you will need to create a new one.<br>
Knowledge of Friendly and its controls should not be so difficult.<br>
When you make ControlDriver, it is better not to refer to the implementation of FormsStandard Controls.<br>
It is difficult to read because there are many special writing methods that include support for .Net 4.0 and earlier.<br>
Normally, it is not necessary to support .Net 4.0 or earlier, so it is better to write it differently.<br>
Please refer to this as it is relatively easy to read.<br>
It is 3rd party control driver.<br>
https://github.com/Codeer-Software/Friendly.XamControls<br>

***
For other GUI types, use the following libraries:

* For Win32.  
https://www.nuget.org/packages/Codeer.Friendly.Windows.NativeStandardControls/  

* For WPF.  
https://www.nuget.org/packages/RM.Friendly.WPFStandardControls/

* For getting the target window.  
https://www.nuget.org/packages/Codeer.Friendly.Windows.Grasp/  

* CefSharp
https://github.com/Codeer-Software/Selenium.CefSharp.Driver/
