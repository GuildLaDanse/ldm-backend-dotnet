. $PSScriptRoot/Environment.ps1
. $PSScriptRoot/Functions.ps1

Write-SectionHeader "Running NuKeeper to update packages"

NuKeeper update -m 10 -c Minor
