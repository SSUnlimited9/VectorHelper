@echo off
:: Clean up the Workspace
:: Add anything else too this that needs to be deleted that is useless while developing

if exist out (
    rmdir out /s /q
)

:: Dont know why I added this but here it is (deletes the dll and its subfolder)
cd VectorHelper
if exist bin (
    if "%1"=="d" (
        rmdir bin /s /q
    )
)