# only need to commit assembly info changes when build is NOT for a pull-request
if ($env:appveyor_pull_request_number)
{
    'Skip committing assembly info changes as this is a PR build...' | Write-Host -ForegroundColor White
}
else
{
    # updated assembly info files   
    git add "source\nanoFramework.CoreLibrary\System\AssemblyInfo2.cs"
    git commit -m "Update assembly info file for v$env:GitVersion_NuGetVersionV2" -m"[version update]"
    git push origin --porcelain -q > $null
    
    'Updated assembly info...' | Write-Host -ForegroundColor White -NoNewline
    'OK' | Write-Host -ForegroundColor Green

    # clone nf-interpreter repo (only a shallow clone with last commit)
    git clone https://github.com/nanoframework/nf-interpreter -b develop --depth 1 -q
    cd nf-interpreter

    # new branch name
    $newBranch = "$env:APPVEYOR_REPO_BRANCH-nfbot/update-version/nanoFramework.CorLib/$env:GitVersion_NuGetVersionV2"

    # create branch to perform updates
    git checkout -b "$newBranch" develop -q
    
    # replace version in assembly declaration
    $newVersion = $env:GitVersion_AssemblySemFileVer -replace "\." , ", "
    $newVersion = "{ $newVersion }"
    
    $versionRegex = "\{\s*\d+\,\s*\d+\,\s*\d+\,\s*\d+\s*}"
    $assemblyFiles = (Get-ChildItem ".\src\CLR\CorLib\corlib_native.cpp" -Recurse)

    foreach($file in $assemblyFiles)
    {
        $filecontent = Get-Content($file)
        attrib $file -r
        $filecontent -replace $versionRegex, $newVersion | Out-File $file -Encoding utf8
    }

    # check if anything was changed
    $repoStatus = "$(git status --short --porcelain)"

    if ($repoStatus -eq "") 
    {
        # nothing changed
        &  cd .. > $null
    }
    else
    {
        $commitMessage = "Update nanoFramework.CorLib version to $env:GitVersion_NuGetVersionV2"

        # commit changes
        git add -A 2>&1
        git commit -m"$commitMessage" -m"[version update]" -q
        git push --set-upstream origin "$newBranch" --porcelain -q > $null
    
        # start PR
        $prRequestBody = @{title="$commitMessage";body="$commitMessage`nStarted with https://github.com/$env:APPVEYOR_REPO_NAME/commit/$env:APPVEYOR_REPO_COMMIT`n[version update]";head="$newBranch";base="develop"} | ConvertTo-Json
        $githubApiEndpoint = "https://api.github.com/repos/nanoframework/nf-interpreter/pulls"
        [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

        try 
        {
            $result = Invoke-RestMethod -Method Post -UserAgent [Microsoft.PowerShell.Commands.PSUserAgent]::InternetExplorer -Uri  $githubApiEndpoint -Header @{"Authorization"="Basic $env:GitRestAuth"} -ContentType "application/json" -Body $prRequestBody
            'Started PR with version update...' | Write-Host -ForegroundColor White -NoNewline
            'OK' | Write-Host -ForegroundColor Green
        }
        catch 
        {
            $result = $_.Exception.Response.GetResponseStream()
            $reader = New-Object System.IO.StreamReader($result)
            $reader.BaseStream.Position = 0
            $reader.DiscardBufferedData()
            $responseBody = $reader.ReadToEnd();

            "Error starting PR: $responseBody" | Write-Host -ForegroundColor Red
        }

        # move back to home folder
        &  cd .. > $null
    }
}
