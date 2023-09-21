@echo off
@echo ======================================================
@echo PalindromicLibTests - Remove bin and obj folders
@echo ======================================================
@echo off
@echo.
@echo.

cd ..\
md log
cd ..\
cd PalindromicLibTests
dir /b /s > ..\.vscode\log\PalindromicLibTests-Files-0-before.txt
@echo on
rd /S /Q bin
rd /S /Q obj
@echo off
dir /b /s > ..\.vscode\log\PalindromicLibTests-Files-1-after.txt
cd ..\
@REM pause