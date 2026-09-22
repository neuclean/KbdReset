@echo off
setlocal
msbuild KbdReset.csproj /t:Rebuild /p:Configuration=Release
if errorlevel 1 (
    echo.
    echo Build failed. Run this from a Visual Studio Developer Command Prompt
    echo with the .NET Framework 4.8 targeting pack installed.
    exit /b 1
)
echo.
echo Built: bin\Release\KbdReset.exe
