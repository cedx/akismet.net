namespace Belin.Akismet.Cmdlets;

/// <summary>
/// Submits the specified comment that was not marked as spam but should have been.
/// </summary>
[Cmdlet(VerbsLifecycle.Submit, "Spam"), OutputType(typeof(void))]
public class SubmitSpamCommand: Cmdlet {

	/// <summary>
	/// The Akismet client used to submit the comment.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required Client Client { get; set; }

	/// <summary>
	/// The comment to be submitted.
	/// </summary>
	[Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
	public required Comment Comment { get; set; }

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => Client.SubmitSpam(Comment);
}
