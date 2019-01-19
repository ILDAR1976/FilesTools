set DOT_NET=C:\Windows\Microsoft.NET\Framework64\v4.0.30319
set PATH=%PATH%;%DOT_NET%
set selector=2

if "%selector%"=="1" (
	msbuild FilesTools.sln /t:Rebuild /p:Configuration=Release
)

if "%selector%"=="2" (
	csc  /r:%DOT_NET%\System.Windows.Forms.dll;%DOT_NET%\System.Drawing.dll /out:hello.exe *.cs 
)
