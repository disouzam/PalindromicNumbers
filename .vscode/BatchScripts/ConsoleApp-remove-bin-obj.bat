@echo off
@echo ======================================================
@echo ConsoleApp - Remove bin and obj folders
@echo ======================================================
@echo off
@echo.
@echo.

cd ..\
md log
cd ..\
cd ConsoleApp
dir /b /s > ..\.vscode\log\ConsoleApp-Files-0-before.txt
@echo on
rd /S /Q bin
rd /S /Q obj
@echo off
dir /b /s > ..\.vscode\log\ConsoleApp-Files-1-after.txt
cd ..\
@REM pause