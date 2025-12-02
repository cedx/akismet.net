namespace Belin.Akismet.Cmdlets;

/// <summary>
/// Creates a new comment.
/// </summary>
[Cmdlet(VerbsCommon.New, "Comment")]
[OutputType(typeof(Comment))]
public class NewCommentCommand: Cmdlet {

	/// <summary>
	/// The comment's author.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required Author Author { get; set; }

	/// <summary>
	/// The comment's content.
	/// </summary>
	[Parameter(Position = 0)]
	public string Content { get; set; } = "";

	/// <summary>
	/// The context in which this comment was posted.
	/// </summary>
	[Parameter]
	public string[] Context { get; set; } = [];

	/// <summary>
	/// The UTC timestamp of the creation of the comment.
	/// </summary>
	[Parameter]
	public DateTime? Date { get; set; }

	/// <summary>
	/// The permanent location of the entry the comment is submitted to.
	/// </summary>
	[Parameter]
	public Uri? Permalink { get; set; }

	/// <summary>
	/// The UTC timestamp of the publication time for the post, page or thread on which the comment was posted.
	/// </summary>
	[Parameter]
	public DateTime? PostModified { get; set; }

	/// <summary>
	/// A string describing why the content is being rechecked.
	/// </summary>
	[Parameter]
	public string RecheckReason { get; set; } = "";

	/// <summary>
	/// The URL of the webpage that linked to the entry being requested.
	/// </summary>
	[Parameter]
	public Uri? Referrer { get; set; }

	/// <summary>
	/// The comment's type.
	/// </summary>
	[Parameter]
	public string Type { get; set; } = "";

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => WriteObject(new Comment(Author) {
		Content = Content,
		Context = Context,
		Date = Date,
		Permalink = Permalink,
		PostModified = PostModified,
		RecheckReason = RecheckReason,
		Referrer = Referrer,
		Type = Type
	});
}
