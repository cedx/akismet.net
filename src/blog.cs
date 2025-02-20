namespace Belin.Akismet;

/// <summary>
/// Represents the front page or home URL transmitted when making requests.
/// </summary>
/// <param name="url">The blog or site URL.</param>
public class Blog(string url) {

	/// <summary>
	/// The character encoding for the values included in comments.
	/// </summary>
	public string Charset { get; set; } = string.Empty;

	/// <summary>
	/// The languages in use on the blog or site, in ISO 639-1 format.
	/// </summary>
	public IList<string> Languages { get; set; } = [];

	/// <summary>
	/// The blog or site URL.
	/// </summary>
	public Uri Url { get; set; } = new Uri(url);
}
