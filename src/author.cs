namespace Belin.Akismet;

using System.Net;

/// <summary>
/// Represents the author of a comment.
/// </summary>
/// <param name="ipAddress">The author's IP address.</param>
public class Author(string ipAddress) {

	/// <summary>
	/// The author's mail address. If you set it to `"akismet-guaranteed-spam@example.com"`, Akismet will always return `true`.
	/// </summary>
	public string Email { get; set; } = string.Empty;

	/// <summary>
	/// The author's IP address.
	/// </summary>
	public IPAddress IPAddress { get; set; } = IPAddress.Parse(ipAddress);

	/// <summary>
	/// The author's name. If you set it to `"viagra-test-123"`, Akismet will always return `true`.
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// The author's role. If you set it to `"administrator"`, Akismet will always return `false`.
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
