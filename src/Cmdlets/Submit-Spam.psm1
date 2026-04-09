using namespace Belin.Akismet
using namespace System.Net.Http

<#
.SYNOPSIS
	Submits the specified comment that was not marked as spam but should have been.
.INPUTS
	The comment to be submitted.
#>
function Submit-Spam {
	[CmdletBinding()]
	[OutputType([void])]
	param (
		# The comment to be submitted.
		[Parameter(Mandatory, Position = 0, ValueFromPipeline)]
		[Comment] $Comment,

		# The Akismet client used to submit the comment.
		[Parameter(Mandatory)]
		[Client] $Client
	)

	process {
		try { $Client.SubmitSpam($Comment) }
		catch [HttpRequestException] { Write-Error $_.Exception }
	}
}
