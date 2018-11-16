# Copyright (c) 2018 The nanoFramework project contributors
# See LICENSE file in the project root for full license information.

$vsixPath = ""

# try downloading from VS marketplace
try
{
    $vsixPath = "$($env:USERPROFILE)\nanoFramework.Tools.VS2017.Extension.vsix"
    (New-Object Net.WebClient).DownloadFile('https://marketplace.visualstudio.com/_apis/public/gallery/publishers/vs-publisher-1470366/vsextensions/nanoFrameworkVS2017Extension/0/vspackage', $vsixPath)        
}
catch
{
    # download failed, try fron MyGet feed
    $vsixPath = "$($env:USERPROFILE)\47973986-ed3c-4b64-ba40-a9da73b44ef7-1.0.1.0.vsix"
    (New-Object Net.WebClient).DownloadFile('https://www.myget.org/F/nanoframework-dev/vsix/47973986-ed3c-4b64-ba40-a9da73b44ef7-1.0.1.0.vsix', $vsixPath)
}

"`"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\VSIXInstaller.exe`" /q /a $vsixPath" | out-file ".\install-vsix.cmd" -Encoding ASCII

'Installing nanoFramework VS extension ...' | Write-Host -ForegroundColor White -NoNewline

& .\install-vsix.cmd > $null

'OK' | Write-Host -ForegroundColor Green
