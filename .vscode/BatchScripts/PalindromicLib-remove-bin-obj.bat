@echo off
@echo ======================================================
@echo PalindromicLib - Remove bin and obj folders
@echo ======================================================
@echo off
@echo.
@echo.

cd ..\
md log
cd ..\
cd PalindromicLib
dir /b /s > ..\.vscode\log\PalindromicLib-Files-0-before.txt
@echo on
rd /S /Q bin
rd /S /Q obj
@echo off
dir /b /s > ..\.vscode\log\PalindromicLib-Files-1-after.txt
cd ..\
@REM pause