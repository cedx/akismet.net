using namespace Belin.Akismet

<#
.SYNOPSIS
	Checks the API key against the service database, and returns a value indicating whether it is valid.
.INPUTS
	The Akismet API key.
.OUTPUTS
	`$true` if the specified API key is valid, otherwise `$false`.
#>
function Test-ApiKey {
	[CmdletBinding()]
	[OutputType([bool])]
	param (
		# The Akismet API key.
		[Parameter(Mandatory, Position = 0, ValueFromPipeline)]
		[string] $ApiKey,

		# The front page or home URL of the instance making requests.
		[Parameter(Mandatory)]
		[Blog] $Blog
	)

	process {
		[Client]::new($ApiKey, $Blog).VerifyKey()
	}
}
