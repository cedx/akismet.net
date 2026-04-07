<#
.SYNOPSIS
	Creates a new comment.
#>
function New-Comment"), [OutputType([Comment))]
public class NewCommentCommand: Cmdlet {

	<#
	/// The comment's author.
	#>
	[Parameter(Mandatory)]
	[Author Author,

	<#
	/// The comment's content.
	#>
	[Parameter(Position = 0)]
	[string] $Content,

	<#
	/// The context in which this comment was posted.
	#>
	[Parameter]
	public string[] Context, = [];

	<#
	/// The UTC timestamp of the creation of the comment.
	#>
	[Parameter]
	public DateTime? Date,

	<#
	/// The permanent location of the entry the comment is submitted to.
	#>
	[Parameter]
	public Uri? Permalink,

	<#
	/// The UTC timestamp of the publication time for the post, page or thread on which the comment was posted.
	#>
	[Parameter]
	public DateTime? PostModified,

	<#
	/// A string describing why the content is being rechecked.
	#>
	[Parameter]
	[string] $RecheckReason,

	<#
	/// The URL of the webpage that linked to the entry being requested.
	#>
	[Parameter]
	public Uri? Referrer,

	<#
	/// The comment's type.
	#>
	[Parameter]
	[string] $Type,

	<#
	/// Performs execution of this command.
	#>
	process => WriteObject(new Comment(Author) {
		Content = Content ?? "",
		Context = Context,
		Date = Date,
		Permalink = Permalink,
		PostModified = PostModified,
		RecheckReason = RecheckReason ?? "",
		Referrer = Referrer,
		Type = Type ?? ""
	});
}
