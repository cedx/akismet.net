<#
.SYNOPSIS
	Tests the features of the `Test-Comment` cmdlet.
#>
Describe "Test-Comment" {
	BeforeAll {
		. "$PSScriptRoot/BeforeAll.ps1"
	}

	It "should return [CheckResult]::Ham for valid comment (e.g. ham)" {
		$ham | Test-AkismetComment -Client $client | Should -Be "Ham"
	}

	It "should return [CheckResult]::Spam for invalid comment (e.g. spam)" {
		$spam | Test-AkismetComment -Client $client | Should -BeIn "Spam", "PervasiveSpam"
	}
}
