rd /s /q "../Src/ReleaseBinary"
"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\devenv.exe" "../Src/Ong.Friendly.FormsStandardControls.sln" /rebuild Release
"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\devenv.exe" "../Src/Ong.Friendly.FormsStandardControls.sln" /rebuild Release-Eng
nuget pack friendly.formsstandardcontrols.nuspec