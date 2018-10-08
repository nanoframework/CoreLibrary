# Copyright (c) 2018 The nanoFramework project contributors
# See LICENSE file in the project root for full license information.

# only need to update dependencies when build is NOT for a pull-request
if ($env:appveyor_pull_request_number)
{
    'Skip updating dependencies as this is a PR build...' | Write-Host -ForegroundColor White
}
else
{
    # update dependencies for class libraries that depend ONLY on mscorlib

    # because it can take sometime for the package to become available on the NuGet providers
    # need to hange here for 5 minutes
    Start-Sleep -Milliseconds 5000 * 60

    $librariesToUpdate =    ("lib-nanoFramework.Runtime.Events", 
                            "lib-nanoFramework.Runtime.Native",
                            "lib-Windows.Storage.Streams",
                            "lib-Windows.Devices.Adc",
                            "lib-Windows.Devices.I2c",
                            "lib-Windows.Devices.Pwm",
                            "lib-Windows.Devices.Spi",
                            "lib-nanoFramework.Networking.Sntp")

    ForEach($library in $librariesToUpdate)
    {
        # init/reset these
        $commitMessage = ""
        $prTitle = ""
        $newBranchName = "$env:APPVEYOR_REPO_BRANCH-nfbot/update-dependencies"
    
        "Updating $library" | Write-Host -ForegroundColor White
   
        # make sure we are in the projects directory
        &  cd "C:\projects" > $null

        # clone library repo and checkout develop branch
        "Cloning $library" | Write-Host -ForegroundColor White
        git clone "https://github.com/nanoframework/$library" -b develop --depth 1 -q
        cd $library
        cd source
    
        # find solution file in repository
        $solutionFile = (Get-ChildItem -Path ".\" -Include "*.sln" -Recurse)

        # run NuKeeper inspect
        $nukeeperInspect = NuKeeper inspect

        $packageCountMatch = [regex]::Match($nukeeperInspect, "Found (\d) possible updates").captures.groups[1].value
        [int]$packageCount = 0
        [int]::TryParse($packageCountMatch, [ref]$packageCount)

        if ($packageCount -gt 0)
        {
            # get packages to update
            $packageListRaw = [regex]::Match($nukeeperInspect, "(?>possible updates([^$]*)Found)").captures.Groups[1].Value;
            [array]$packageList = $packageListRaw.Split([Environment]::NewLine, [StringSplitOptions]::RemoveEmptyEntries).Replace([Environment]::NewLine, "")

            # restore NuGet packages, need to do this before anything else
            nuget restore $solutionFile[0] -Source https://www.myget.org/F/nanoframework-dev/api/v3/index.json -Source https://api.nuget.org/v3/index.json
    
            # rename nfproj files to csproj
            Get-ChildItem -Path ".\" -Include "*.nfproj" -Recurse |
                Foreach-object {
                    $OldName = $_.name; 
                    $NewName = $_.name -replace 'nfproj','csproj'; 
                    Rename-Item  -Path $_.fullname -Newname $NewName; 
                }

            # update all packages
            foreach ($package in $packageList)
            {
                # get package name and target version
                $packageDetails = [regex]::Match($package, "(.*)(( from)(.*)(to )(.*)( in))")
                $packageName = $packageDetails.captures.Groups[1].Value.Trim();
                $packageOriginVersion = $packageDetails.captures.Groups[4].Value.Trim();
                $packageTargetVersion = $packageDetails.captures.Groups[6].Value.Trim();
    
                # update package
                $updatePackage = nuget update $solutionFile[0].FullName -Source https://www.myget.org/F/nanoframework-dev/api/v3/index.json -Source https://api.nuget.org/v3/index.json

                #  grab csproj from update output
                $projectPath = [regex]::Match($updatePackage, "((project ')(.*)(', targeting))").captures.Groups[3].Value

                # replace NFMDP_PE_LoadHints
                $filecontent = Get-Content($projectPath)
                attrib $projectPath -r
                $filecontent -replace "($packageName.$packageOriginVersion)", "$packageName.$packageTargetVersion" | Out-File $projectPath -Encoding utf8

                # update nuproj files, if any
                $nuprojFiles = (Get-ChildItem -Path ".\" -Include "*.nuproj" -Recurse)

                foreach ($nuproj in $nuprojFiles)
                {
                    [xml]$nuprojDoc = Get-Content $nuproj

                    #$nuprojDoc.Project.ItemGroup

                    $nodes = $nuprojDoc.SelectNodes("*").SelectNodes("*")

                    foreach ($node in $nodes)
                    {
                        $name = $node.Name;

                        if(($node.Name -eq "ItemGroup") -and (($node.ChildNodes[0].Name -eq "Dependency") -and $node.ChildNodes[0].Attributes["Include"].value -eq $packageName))
                        {
                            $node.ChildNodes[0].ChildNodes[0].innertext = "[$packageTargetVersion]"
                        }
                    }

                    $nuprojDoc.Save($nuproj[0].FullName)
                }

                #  update branch name
                $tempPackageName = $packageName -replace "(nanoFramework.)", ""
                $newBranchName += "/$tempPackageName.$packageTargetVersion"
                
                # build commit message
                $commitMessage += "Bumps $packageName from $packageOriginVersion to $packageTargetVersion.`n"

                # build PR title
                $prTitle = "Bumps $packageName from $packageOriginVersion to $packageTargetVersion"
            }

            # rename csproj files back to nfproj
            Get-ChildItem -Path ".\" -Include "*.csproj" -Recurse |
            Foreach-object {
                $OldName = $_.name; 
                $NewName = $_.name -replace 'csproj','nfproj'; 
                Rename-Item  -Path $_.fullname -Newname $NewName; 
                }
            
            # need this line so nfbot flags the PR appropriately
            $commitMessage += "`n[version update]`n`n"

            # better add this warning line               
            $commitMessage += "### :warning: This is an automated update. Merge only after all tests pass. :warning:`n"

            # create branch to perform updates
            git branch $newBranchName -q
            
            # checkout branch
            git checkout $newBranchName -q

            # commit changes
            git add -A 2>&1

            # commit message with a different title if one or more dependencies are updated
            if ($packageCount -gt 1)
            {
                git commit -m "Update several NuGet dependencies" -m"$commitMessage" -q

                # fix PR title
                $prTitle = "Update several NuGet dependencies"
            }
            else 
            {
                git commit -m "$prTitle" -m "$commitMessage" -q
            }

            git push --set-upstream origin $newBranchName --porcelain -q

            # start PR
            $prRequestBody = @{title="$prTitle";body="$commitMessage";head="$newBranchName";base="$env:APPVEYOR_REPO_BRANCH"} | ConvertTo-Json
            $githubApiEndpoint = "https://api.github.com/repos/nanoframework/$library/pulls"
            [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

            $headers = @{}
            $headers.Add("Authorization","Basic $env:GitRestAuth")
            $headers.Add("Accept","application/vnd.github.symmetra-preview+json")

            try 
            {
                $result = Invoke-RestMethod -Method Post -UserAgent [Microsoft.PowerShell.Commands.PSUserAgent]::InternetExplorer -Uri  $githubApiEndpoint -Header $headers -ContentType "application/json" -Body $prRequestBody
                'Started PR with dependencies update...' | Write-Host -ForegroundColor White -NoNewline
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
        }
        else
        {
            # nothing to update???
            "Couldn't find anything to update..." | Write-Host -ForegroundColor Black -BackgroundColor Yellow
        }
    }

    # get back to the original build folder
    cd $env:APPVEYOR_BUILD_FOLDER
}
