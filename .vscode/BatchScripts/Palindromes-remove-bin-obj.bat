@echo off
@echo ======================================================
@echo Palindromes - Remove bin and obj folders
@echo ======================================================
@echo off
@echo.
@echo.

cd ..\
md log
cd ..\
cd Palindromes
dir /b /s > ..\.vscode\log\Palindromes-Files-0-before.txt
@echo on
rd /S /Q bin
rd /S /Q obj
@echo off
dir /b /s > ..\.vscode\log\Palindromes-Files-1-after.txt
cd ..\
@REM pause