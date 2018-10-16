$vsixPath = "$($env:USERPROFILE)\nanoFramework.Tools.VS2017.Extension.vsix"
(New-Object Net.WebClient).DownloadFile('https://marketplace.visualstudio.com/_apis/public/gallery/publishers/vs-publisher-1470366/vsextensions/nanoFrameworkVS2017Extension/0/vspackage', $vsixPath)
"`"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\VSIXInstaller.exe`" /q /a $vsixPath" | out-file ".\install-vsix.cmd" -Encoding ASCII

'Installing nanoFramework VS extension ...' | Write-Host -ForegroundColor White -NoNewline

& .\install-vsix.cmd --quiet --no-verbose > $null

'OK' | Write-Host -ForegroundColor Green
