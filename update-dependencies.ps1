# Copyright (c) 2018 The nanoFramework project contributors
# See LICENSE file in the project root for full license information.

# only need to update dependencies when build is a tag
if ($env:appveyor_pull_request_number -or $env:APPVEYOR_REPO_TAG -eq "false")
{
    'Skip updating dependencies...' | Write-Host -ForegroundColor White
}
else
{
    # update dependencies for class libraries that depend ONLY on mscorlib

    # because it can take sometime for the package to become available on the NuGet providers
    # need to hang here for 5 minutes (5 * 60)
    "Waiting 5 minutes to let package process flow in NuGet providers..." | Write-Host -ForegroundColor White

    For ($i=300; $i -gt 0; $i--) 
    {  
        Write-Host "`r$i seconds remaining   " -NoNewLine
        Start-Sleep -Seconds 1 
    }
    Write-Host     "`r                       "

    $librariesToUpdate =    ("lib-nanoFramework.Runtime.Events", 
                            "lib-nanoFramework.Runtime.Native",
                            "lib-Windows.Storage.Streams",
                            "lib-Windows.Devices.Adc",
                            "lib-Windows.Devices.I2c",
                            "lib-Windows.Devices.Pwm",
                            "lib-Windows.Devices.Spi",
                            "lib-nanoFramework.Networking.Sntp",
                            "lib-nanoFramework.Hardware.Stm32",
                            "lib-nanoFramework.System.Math")

    ForEach($library in $librariesToUpdate)
    {
        # init/reset these
        $commitMessage = ""
        $prTitle = ""
        $projectPath = ""
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

        # find packages.config
        $packagesConfig = (Get-ChildItem -Path ".\" -Include "packages.config" -Recurse)

        # load packages.config as XML doc
        [xml]$packagesDoc = Get-Content $packagesConfig

        $nodes = $packagesDoc.SelectNodes("*").SelectNodes("*")

        $packageList = @(,@())

        foreach ($node in $nodes)
        {
            # filter out Nerdbank.GitVersioning package
            if($node.id -notlike "Nerdbank.GitVersioning*")
            {
                if($packageList)
                {
                    $packageList += , ($node.id,  $node.version)
                }
                else
                {
                    $packageList = , ($node.id,  $node.version)
                }
            }
        }

        if ($packageList.length -gt 0)
        {
            "NuGet packages to update:" | Write-Host -ForegroundColor White
            $packageList | Write-Host -ForegroundColor White

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
                $packageName = $package[0]
                $packageOriginVersion = $package[1]
    
                # update package
                if ($env:APPVEYOR_REPO_BRANCH -like '*release*' -or $env:APPVEYOR_REPO_BRANCH -like '*master*')
                {
                    # don't allow prerelease for release and master branches
                    $updatePackage = nuget update $solutionFile[0].FullName -Source https://api.nuget.org/v3/index.json -Source https://api.nuget.org/v3/index.json 
                }
                else
                {
                    # allow prerelease for all others
                    $updatePackage = nuget update $solutionFile[0].FullName -Source https://www.myget.org/F/nanoframework-dev/api/v3/index.json -Source https://api.nuget.org/v3/index.json -PreRelease
                }

                # need to get target version
                # load packages.config as XML doc
                [xml]$packagesDoc = Get-Content $packagesConfig

                $nodes = $packagesDoc.SelectNodes("*").SelectNodes("*")

                foreach ($node in $nodes)
                {
                    # find this package
                    if($node.id -match $packageName)
                    {
                        $packageTargetVersion = $node.version
                    }
                }

                #  find csproj
                $projectPath = (Get-ChildItem -Path ".\" -Include "*.csproj" -Recurse)

                # replace NFMDP_PE_LoadHints
                $filecontent = Get-Content($projectPath)
                attrib $projectPath -r
                $filecontent -replace "($packageName.$packageOriginVersion)", "$packageName.$packageTargetVersion" | Out-File $projectPath -Encoding utf8

                # update nuspec files, if any
                $nuspecFiles = (Get-ChildItem -Path ".\" -Include "*.nuspec" -Recurse)

                foreach ($nuspec in $nuspecFiles)
                {
                    [xml]$nuspecDoc = Get-Content $nuspec

                    $nodes = $nuspecDoc.SelectNodes("*").SelectNodes("*")

                    foreach ($node in $nodes)
                    {
                        if($node.Name -eq "metadata")
                        {
                            foreach ($metadataItem in $node.ChildNodes)
                            {                          
                                if($metadataItem.Name -eq "dependencies")
                                {
                                    foreach ($dependency in $metadataItem.ChildNodes)
                                    {
                                        if($dependency.Attributes["id"].value -eq $packageName)
                                        {
                                            $dependency.Attributes["version"].value = "[$packageTargetVersion]"
                                        }
                                    }
                                }
                            }
                        }
                    }

                    $nuspecDoc.Save($nuspec[0].FullName)
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
                git commit -m "Update $packageCount NuGet dependencies" -m"$commitMessage" -q

                # fix PR title
                $prTitle = "Update $packageCount NuGet dependencies"
            }
            else 
            {
                git commit -m "$prTitle" -m "$commitMessage" -q
            }

            git push --set-upstream origin $newBranchName --porcelain -q

            # start PR
            # we are hardcoding to develop branch to have a fixed one
            # this is very important for tags (which don't have branch information)
            # considering that the base branch can be changed at the PR ther is no big deal about this 
            $prRequestBody = @{title="$prTitle";body="$commitMessage";head="$newBranchName";base="develop"} | ConvertTo-Json
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
