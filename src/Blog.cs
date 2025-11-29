namespace Belin.Akismet;

using System.Diagnostics.CodeAnalysis;
using System.Text;

/// <summary>
/// Represents the front page or home URL transmitted when making requests.
/// </summary>
/// <param name="url">The blog or site URL.</param>
public sealed class Blog(Uri url) {

	/// <summary>
	/// The character encoding for the values included in comments.
	/// </summary>
	public Encoding? Charset { get; set; }

	/// <summary>
	/// The languages in use on the blog or site, in ISO 639-1 format.
	/// </summary>
	public IList<string> Languages { get; set; } = [];

	/// <summary>
	/// The blog or site URL.
	/// </summary>
	public Uri Url { get; set; } = url;

	/// <summary>
	/// Creates a new blog.
	/// </summary>
	/// <param name="url">The blog or site URL.</param>
	public Blog([StringSyntax(StringSyntaxAttribute.Uri)] string url): this(new Uri(url, UriKind.Absolute)) {}

	/// <summary>
	/// Creates a new blog from the specified string.
	/// </summary>
	/// <param name="url">The blog or site URL.</param>
	/// <returns>The blog corresponding to the specified string.</returns>
	public static implicit operator Blog(string url) => new(url);

	/// <summary>
	/// Converts this object into a dictionary.
	/// </summary>
	/// <returns>The dictionary corresponding to this object.</returns>
	internal Dictionary<string, string> ToDictionary() {
		var map = new Dictionary<string, string> { ["blog"] = Url.ToString() };
		if (Charset is not null) map["blog_charset"] = Charset.WebName;
		if (Languages.Count > 0) map["blog_lang"] = string.Join(',', Languages);
		return map;
	}
}
