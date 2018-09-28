# generate cahnge log on tag commit OR when building in master (for releases)
if ($env:appveyor_repo_tag -eq "true" -or $env:appveyor_repo_branch -eq "master")
{
    # need this to keep ruby happy
    md c:\tmp

    # generate change log
    if ($env:appveyor_repo_tag -eq "true")
    {   
        # version includes commits
        bundle exec github_changelog_generator --token $env:GitHubToken --future-release "v$env:GitVersion_MajorMinorPatch.$env:GitVersion_CommitsSinceVersionSource"
    }
    else
    {
        # release version, just the regular version format
        bundle exec github_changelog_generator --token $env:GitHubToken --future-release "v$env:GitVersion_MajorMinorPatch"
    }

    # updated changelog and the updated assembly info files
    git add CHANGELOG.md
    git commit -m "Update CHANGELOG for v$env:GitVersion_MajorMinorPatch.$env:GitVersion_CommitsSinceVersionSource"
    # need to wrap the git command bellow so it doesn't throw an error because of redirecting the output to stderr
    "$(git push origin)"
}
