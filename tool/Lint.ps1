Import-Module PSScriptAnalyzer

"Performing the static analysis of source code..."
$PSScriptRoot, "src", "test" | Invoke-ScriptAnalyzer -ExcludeRule PSUseShouldProcessForStateChangingFunctions -Recurse
Test-ModuleManifest Akismet.psd1 | Out-Null
