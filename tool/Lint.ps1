"Performing the static analysis of source code..."
Import-Module PSScriptAnalyzer
Invoke-ScriptAnalyzer $PSScriptRoot -Recurse
Test-ModuleManifest Akismet.psd1 | Out-Null
