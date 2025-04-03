namespace Belin.Akismet;

using System.Text;

/// <summary>
/// Represents the front page or home URL transmitted when making requests.
/// </summary>
/// <param name="url">The blog or site URL.</param>
public sealed class Blog(string url) {

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
	public Uri Url { get; set; } = new Uri(url);

	/// <summary>
	/// Converts this object into a dictionary.
	/// </summary>
	/// <returns>The dictionary corresponding to this object.</returns>
	internal Dictionary<string, string> ToDictionary() {
		var map = new Dictionary<string, string> { ["blog"] = Url.ToString() };
		if (Charset is not null) map["blog_charset"] = Charset.WebName;
		if (Languages.Count != 0) map["blog_lang"] = string.Join(',', Languages);
		return map;
	}
}
