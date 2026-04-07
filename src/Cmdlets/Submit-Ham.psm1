<#
.SYNOPSIS
	Submits the specified comment that was incorrectly marked as spam but should not have been.
#>
function Submit-Ham"), [OutputType([void))]
public class SubmitHamCommand: Cmdlet {

	<#
	/// The Akismet client used to submit the comment.
	#>
	[Parameter(Mandatory)]
	[Client Client,

	<#
	/// The comment to be submitted.
	#>
	[Parameter(Mandatory, Position = 0, ValueFromPipeline)]
	[Comment Comment,

	<#
	/// Performs execution of this command.
	#>
	process => Client.SubmitHam(Comment);
}
