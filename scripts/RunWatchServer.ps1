. $PSScriptRoot/Environment.ps1
. $PSScriptRoot/Functions.ps1

Write-SectionHeader "Compiling SCSS stylesheets"

sass .\src\WebUI\Styles\app.scss:.\src\WebUI\wwwroot\css\app.css

Write-SectionHeader "Running project with watch"

dotnet watch -p src/WebUI/WebUI.csproj run
