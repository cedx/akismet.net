<#
.SYNOPSIS
	Submits the specified comment that was not marked as spam but should have been.
#>
function Submit-Spam"), [OutputType([void))]
public class SubmitSpamCommand: Cmdlet {

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
	process => Client.SubmitSpam(Comment);
}
