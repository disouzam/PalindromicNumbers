@echo off
@echo ======================================================
@echo ConsoleAppTests - Remove bin and obj folders
@echo ======================================================
@echo off
@echo.
@echo.

cd ..\
md log
cd ..\
cd ConsoleAppTests
dir /b /s > ..\.vscode\log\ConsoleAppTests-Files-0-before.txt
@echo on
rd /S /Q bin
rd /S /Q obj
@echo off
dir /b /s > ..\.vscode\log\ConsoleAppTests-Files-1-after.txt
cd ..\
@REM pause