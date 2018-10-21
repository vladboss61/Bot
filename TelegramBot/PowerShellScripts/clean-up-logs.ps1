$currentPath = Split-Path $MyInvocation.MyCommand.Path;
$LogsFoldr =  "$currentPath/../Logs/"

foreach($element in (Get-ChildItem -Path $LogsFoldr))
{     
    Write-Host "Log Item: $element" 
    Remove-Item $element -Force -Recurse
}