namespace Belin.Akismet.Cmdlets;

/// <summary>
/// Checks the specified comment against the service database, and returns a value indicating whether it is spam.
/// </summary>
[Cmdlet(VerbsDiagnostic.Test, "Comment")]
[OutputType(typeof(CheckResult))]
public class TestCommentCommand: Cmdlet {

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
	protected override void ProcessRecord() =>
		WriteObject(Client.CheckComment(Comment).GetAwaiter().GetResult());
}
