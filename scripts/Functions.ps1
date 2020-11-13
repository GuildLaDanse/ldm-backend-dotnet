function Write-SectionHeader 
{
    param( [string]$Message )
    
    Write-Host ""
    Write-Host "##################################################" -ForegroundColor Green
    Write-Host "#" -ForegroundColor Green
    Write-Host "#"  $Message -ForegroundColor Green
    Write-Host "#" -ForegroundColor Green
    Write-Host "##################################################" -ForegroundColor Green
    Write-Host ""
}
