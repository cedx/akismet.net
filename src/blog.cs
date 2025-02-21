namespace Belin.Akismet;

using System.Text;

/// <summary>
/// Represents the front page or home URL transmitted when making requests.
/// </summary>
/// <param name="url">The blog or site URL.</param>
public class Blog(Uri url) {

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
	/// Returns a JSON representation of this object.
	/// </summary>
	/// <returns>The JSON representation of this object.</returns>
	public IDictionary<string, string> ToJson() {
		var map = new Dictionary<string, string> { ["blog"] = Url.ToString() };
		if (Charset != null) map["blog_charset"] = Charset.WebName;
		if (Languages.Count != 0) map["blog_lang"] = string.Join(',', Languages);
		return map;
	}
}
