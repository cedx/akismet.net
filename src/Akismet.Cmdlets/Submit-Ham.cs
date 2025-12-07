namespace Belin.Akismet.Cmdlets;

/// <summary>
/// Submits the specified comment that was incorrectly marked as spam but should not have been.
/// </summary>
[Cmdlet(VerbsLifecycle.Submit, "Ham")]
[OutputType(typeof(void))]
public class SubmitHamCommand: Cmdlet {

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
	protected override void ProcessRecord() => Client.SubmitHamAsync(Comment).Wait();
}
