<#
.SYNOPSIS
	Verifies an Akismet API key.
#>
Import-Module Akismet

$isValid = Test-AkismetApiKey "123YourAPIKey" -Blog "https://www.yourblog.com"
Write-Output ($isValid ? "The API key is valid." : "The API key is invalid.")
