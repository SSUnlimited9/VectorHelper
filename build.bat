@echo off
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" VectorHelper.sln
if "%1"=="run" goto e
exit
:e
..\..\Celeste.exe