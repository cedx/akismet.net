<#
.SYNOPSIS
	Tests the features of the `Submit-Ham` cmdlet.
#>
Describe "Submit-Ham" {
	BeforeAll {
		. "$PSScriptRoot/BeforeAll.ps1"
	}

	It "should complete without any error" {
		{ $ham | Submit-AkismetHam -Client $client } | Should -Not -Throw
	}
}
