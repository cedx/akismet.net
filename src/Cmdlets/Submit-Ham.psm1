using namespace Belin.Akismet

<#
.SYNOPSIS
	Submits the specified comment that was incorrectly marked as spam but should not have been.
.INPUTS
	The comment to be submitted.
#>
function Submit-Ham {
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

	$Client.SubmitHam($Comment)
}
