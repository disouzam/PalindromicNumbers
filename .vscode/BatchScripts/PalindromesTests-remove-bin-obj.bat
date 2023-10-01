@echo off
@echo ======================================================
@echo PalindromesTests - Remove bin and obj folders
@echo ======================================================
@echo off
@echo.
@echo.

cd ..\
md log
cd ..\
cd PalindromesTests
dir /b /s > ..\.vscode\log\PalindromesTests-Files-0-before.txt
@echo on
rd /S /Q bin
rd /S /Q obj
@echo off
dir /b /s > ..\.vscode\log\PalindromesTests-Files-1-after.txt
cd ..\
@REM pause