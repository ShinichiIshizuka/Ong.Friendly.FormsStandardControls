rd /s /q "../Src/ReleaseBinary"
"C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\devenv.exe" "../Src/Ong.Friendly.FormsStandardControls.sln" /rebuild Release
"C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\devenv.exe" "../Src/Ong.Friendly.FormsStandardControls.sln" /rebuild Release-Eng
nuget pack friendly.formsstandardcontrols.nuspec