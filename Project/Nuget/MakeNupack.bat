rd /s /q "../Src/ReleaseBinary"
"%DevEnvDir%devenv.exe" "../Src/Ong.Friendly.FormsStandardControls.sln" /rebuild Release
"%DevEnvDir%devenv.exe" "../Src/Ong.Friendly.FormsStandardControls.sln" /rebuild Release-Eng
nuget pack friendly.formsstandardcontrols.nuspec