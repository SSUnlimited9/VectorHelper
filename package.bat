@echo off

set dirs =<pkgInclude


:: Create Package Output Directory
if not exist out\ (
    mkdir out
)

:: Clear Previous Packages
cd out
if exist package\ (
    rmdir /S /Q package
)
mkdir package
if exist VectorHelper.zip (
    rm VectorHelper.zip
)
cd ..

:: Copy needed specified directories out
(FOR /F "tokens=* delims=" %%a in (pkgInclude.txt) DO (
    mkdir out\package\%%a
    robocopy /MIR %%a out\package\%%a
))

:: Copy a few extra files
copy everestPkg.yaml out\package\everestPkg.yaml
copy VectorHelper\obj\Debug\net452\VectorHelper.dll out\package\VectorHelper.dll

:: Archive everything up
cd out\package
..\..\7z\7zC.exe a ..\VectorHelper.zip *