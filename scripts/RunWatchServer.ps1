. $PSScriptRoot/Environment.ps1
. $PSScriptRoot/Functions.ps1

Write-SectionHeader "Running project with watch"

dotnet watch -p src/WebAPI/WebAPI.csproj run
