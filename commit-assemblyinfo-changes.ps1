# only need to commit assembly info changes when build is NOT for a pull-request
if ($env:appveyor_pull_request_number)
{
    'Skip committing assembly info changes as this is a PR build...' | Write-Host -ForegroundColor White
}
else
{
    # updated assembly info files
    git add "source\System\AssemblyInfo2.cs"
    git commit -m "Update assembly info file for v$env:GitVersion_NuGetVersionV2"
    # need to wrap the git command bellow so it doesn't throw an error because of redirecting the output to stderr
    "$(git push origin)"
}
