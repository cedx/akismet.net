using namespace Belin.Akismet

<#
.SYNOPSIS
	Creates a new Akismet client.
.OUTPUTS
	The newly created client.
#>
function New-Client {
	[CmdletBinding()]
	[OutputType([Belin.Akismet.Client])]
	param (
		# The Akismet API key.
		[Parameter(Mandatory, Position = 0)]
		[string] $ApiKey,

		# The front page or home URL of the instance making requests.
		[Parameter(Mandatory)]
		[Blog] $Blog,

		# The user agent string to use when making requests.
		[ValidateNotNullOrWhiteSpace()]
		[string] $UserAgent = "PowerShell/$($PSVersionTable.PSVersion) | Belin.Akismet/$([Client]::Version.ToString(3))",

		# The base URL of the remote API endpoint.
		[uri] $Uri,

		# Value indicating whether the client operates in test mode.
		[switch] $WhatIf
	)

	$client = [Client]::new($ApiKey, $Blog, $Uri)
	$client.IsTest = $WhatIf
	$client.UserAgent = $UserAgent
	$client
}
