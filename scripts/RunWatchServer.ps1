. $PSScriptRoot/Environment.ps1
. $PSScriptRoot/Functions.ps1

Write-SectionHeader "Running project with watch"

dotnet watch -p src/$env:MAIN_PROJECT/$env:MAIN_PROJECT.csproj run
