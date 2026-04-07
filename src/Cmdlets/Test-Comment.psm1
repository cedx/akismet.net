<#
.SYNOPSIS
	Checks the specified comment against the service database, and returns a value indicating whether it is spam.
#>
function Test-Comment"), [OutputType([CheckResult))]
public class TestCommentCommand: Cmdlet {

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
	process => WriteObject(Client.CheckComment(Comment));
}
