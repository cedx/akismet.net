"Performing the static analysis of source code..."
Import-Module PSScriptAnalyzer
$PSScriptRoot, "test" | Invoke-ScriptAnalyzer -Recurse
Test-ModuleManifest Akismet.psd1 | Out-Null
