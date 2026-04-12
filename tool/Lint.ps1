"Performing the static analysis of source code..."
Import-Module PSScriptAnalyzer
$PSScriptRoot, "src", "test" | Invoke-ScriptAnalyzer -ExcludeRule PSUseShouldProcessForStateChangingFunctions -Recurse
Test-ModuleManifest Akismet.psd1 | Out-Null
