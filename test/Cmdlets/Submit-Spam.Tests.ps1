<#
.SYNOPSIS
	Tests the features of the `Submit-Spam` cmdlet.
#>
Describe "Submit-Spam" {
	BeforeAll {
		. "$PSScriptRoot/BeforeAll.ps1"
	}

	It "should complete without any error" {
		{ $spam | Submit-AkismetSpam -Client $client -ErrorAction Stop } | Should -Not -Throw
	}
}
