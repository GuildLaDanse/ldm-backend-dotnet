. $PSScriptRoot/Environment.ps1
. $PSScriptRoot/Functions.ps1

Push-Location src/Hermes.WebUI

Write-SectionHeader "Running project with watch"

dotnet watch run
