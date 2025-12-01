<#
.SYNOPSIS
	Tests the features of the `Test-ApiKey` cmdlet.
#>
Describe "Test-ApiKey" {
	BeforeAll {
		. "$PSScriptRoot/BeforeAll.ps1"
	}

	It "should return `$true for a valid API key" {
		$client.ApiKey | Test-AkismetApiKey -Blog $client.Blog | Should -BeTrue
	}

	It "should return `$false for an invalid API key" {
		"0123456789-ABCDEF" | Test-AkismetApiKey -Blog $client.Blog | Should -BeFalse
	}
}
