namespace Belin.Akismet;

using System.Net;

/// <summary>
/// Represents the author of a comment.
/// </summary>
/// <param name="ipAddress">The author's IP address.</param>
public sealed class Author(string ipAddress) {

	/// <summary>
	/// The author's mail address. If you set it to <c>"akismet-guaranteed-spam@example.com"</c>, Akismet will always return <see langword="true"/>.
	/// </summary>
	public string Email { get; set; } = string.Empty;

	/// <summary>
	/// The author's IP address.
	/// </summary>
	public IPAddress IPAddress { get; set; } = IPAddress.Parse(ipAddress);

	/// <summary>
	/// The author's name. If you set it to <c>"viagra-test-123"</c>, Akismet will always return <see langword="true"/>.
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// The author's role. If you set it to <c>"administrator"</c>, Akismet will always return <see langword="false"/>.
	/// </summary>
	public string Role { get; set; } = string.Empty;

	/// <summary>
	/// The URL of the author's website.
	/// </summary>
	public Uri? Url { get; set; }

	/// <summary>
	/// The author's user agent, that is the string identifying the Web browser used to submit comments.
	/// </summary>
	public string UserAgent { get; set; } = string.Empty;

	/// <summary>
	/// Converts this object into a dictionary.
	/// </summary>
	/// <returns>The dictionary corresponding to this object.</returns>
	internal IDictionary<string, string> ToDictionary() {
		var map = new Dictionary<string, string> { ["user_ip"] = IPAddress.ToString() };
		if (!string.IsNullOrWhiteSpace(Email)) map["comment_author_email"] = Email;
		if (!string.IsNullOrWhiteSpace(Name)) map["comment_author"] = Name;
		if (!string.IsNullOrWhiteSpace(Role)) map["user_role"] = Role;
		if (Url is not null) map["comment_author_url"] = Url.ToString();
		if (!string.IsNullOrWhiteSpace(UserAgent)) map["user_agent"] = UserAgent;
		return map;
	}
}

/// <summary>
/// Specifies the role of an author.
/// </summary>
public static class AuthorRole {

	/// <summary>
	/// The author is an administrator.
	/// </summary>
	public const string Administrator = "administrator";
}
