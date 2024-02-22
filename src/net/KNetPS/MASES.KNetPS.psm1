#
# Script module for module 'MASES.KNetPS'
#
Set-StrictMode -Version Latest

# Set up some helper variables to make it easier to work with the module
$PSModule = $ExecutionContext.SessionState.Module
$PSModuleRoot = $PSModule.ModuleBase

# Import the appropriate nested binary module based on the current PowerShell version
$binaryModuleRoot = $PSModuleRoot

if (($PSVersionTable.Keys -contains "PSEdition") -and ($PSVersionTable.PSEdition -ne 'Desktop')) {
   $binaryModuleFileName = 'MASES.KNetPSCore.psd1'
   $binaryModuleRoot = Join-Path -Path $PSModuleRoot -ChildPath 'net8.0'
}
else {
   $binaryModuleFileName = 'MASES.KNetPSFramework.psd1'
   $binaryModuleRoot = Join-Path -Path $PSModuleRoot -ChildPath 'net462'
}

$binaryModulePath = Join-Path -Path $binaryModuleRoot -ChildPath $binaryModuleFileName
$binaryModule = Import-Module -Name $binaryModulePath -PassThru

# When the module is unloaded, remove the nested binary module that was loaded with it
$PSModule.OnRemove = {
   Remove-Module -ModuleInfo $binaryModule
}