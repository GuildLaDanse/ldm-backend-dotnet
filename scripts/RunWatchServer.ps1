. $PSScriptRoot/Environment.ps1
. $PSScriptRoot/Functions.ps1

Push-Location src/WebAPI

Write-SectionHeader "Running project with watch"

dotnet watch run
