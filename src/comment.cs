namespace Belin.Akismet;

/// <summary>
/// Represents a comment submitted by an author.
/// </summary>
/// <param name="author">The comment's author.</param>
public class Comment(Author author) {

	/// <summary>
	/// The comment's author.
	/// </summary>
	public Author Author { get; set; } = author;

	/// <summary>
	/// The comment's content.
	/// </summary>
	public string Content { get; set; } = string.Empty;

	/// <summary>
	/// The context in which this comment was posted.
	/// </summary>
	public IList<string> Context { get; set; } = [];

	/// <summary>
	/// The UTC timestamp of the creation of the comment.
	/// </summary>
	public DateTime? Date { get; set; } = null;

	/// <summary>
	/// The permanent location of the entry the comment is submitted to.
	/// </summary>
	public Uri? Permalink { get; set; } = null;

	/// <summary>
	/// The UTC timestamp of the publication time for the post, page or thread on which the comment was posted.
	/// </summary>
	public DateTime? PostModified { get; set; } = null;

	/// <summary>
	/// A string describing why the content is being rechecked.
	/// </summary>
	public string RecheckReason { get; set; } = string.Empty;

	/// <summary>
	/// The URL of the webpage that linked to the entry being requested.
	/// </summary>
	public Uri? Referrer { get; set; } = null;

	/// <summary>
	/// The comment's type.
	/// </summary>
	public string Type { get; set; } = string.Empty;
}

/// <summary>
/// Specifies the type of a comment.
/// </summary>
public static class CommentType {

	/// <summary>
	/// A blog post.
	/// </summary>
	public const string BlogPost = "blog-post";

	/// <summary>
	/// A blog comment.
	/// </summary>
	public const string Comment = "comment";

	/// <summary>
	/// A contact form or feedback form submission.
	/// </summary>
	public const string ContactForm = "contact-form";

	/// <summary>
	/// A top-level forum post.
	/// </summary>
	public const string ForumPost = "forum-post";

	/// <summary>
	/// A message sent between just a few users.
	/// </summary>
	public const string Message = "message";

	/// <summary>
	/// A reply to a top-level forum post.
	/// </summary>
	public const string Reply = "reply";

	/// <summary>
	/// A new user account.
	/// </summary>
	public const string Signup = "signup";
}
