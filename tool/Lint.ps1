using module PSScriptAnalyzer

"Performing the static analysis of source code..."
Invoke-ScriptAnalyzer $PSScriptRoot -Recurse
Test-ModuleManifest Akismet.psd1 | Out-Null
