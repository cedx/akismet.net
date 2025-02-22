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
	public DateTime? Date { get; set; }

	/// <summary>
	/// The permanent location of the entry the comment is submitted to.
	/// </summary>
	public Uri? Permalink { get; set; }

	/// <summary>
	/// The UTC timestamp of the publication time for the post, page or thread on which the comment was posted.
	/// </summary>
	public DateTime? PostModified { get; set; }

	/// <summary>
	/// A string describing why the content is being rechecked.
	/// </summary>
	public string RecheckReason { get; set; } = string.Empty;

	/// <summary>
	/// The URL of the webpage that linked to the entry being requested.
	/// </summary>
	public Uri? Referrer { get; set; }

	/// <summary>
	/// The comment's type.
	/// </summary>
	public string Type { get; set; } = string.Empty;

	/// <summary>
	/// Returns a JSON representation of this object.
	/// </summary>
	/// <returns>The JSON representation of this object.</returns>
	internal IDictionary<string, string> ToJson() {
		var map = Author.ToJson();
		if (!string.IsNullOrWhiteSpace(Content)) map["comment_content"] = Content;
		// TODO if (Context.Count > 0) map["comment_context"] = string.Join(',', Context);
		if (Date is not null) map["comment_date_gmt"] = Date?.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")!;
		if (Permalink is not null) map["permalink"] = Permalink.ToString();
		if (PostModified is not null) map["comment_post_modified_gmt"] = PostModified?.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")!;
		if (!string.IsNullOrWhiteSpace(RecheckReason)) map["recheck_reason"] = RecheckReason;
		if (Referrer is not null) map["referrer"] = Referrer.ToString();
		if (!string.IsNullOrWhiteSpace(Type)) map["comment_type"] = Type;
		return map;
	}
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
