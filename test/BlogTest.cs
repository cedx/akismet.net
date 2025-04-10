namespace Belin.Akismet;

using System.Text;

/// <summary>
/// Tests the features of the <see cref="Blog"/> class.
/// </summary>
[TestClass]
public sealed class BlogTest {

	[TestMethod]
	public void ToDictionary() {
		// It should return only the blog URL with a newly created instance.
		var map = new Blog(url: "https://github.com/cedx/akismet.net").ToDictionary();
		AreEqual(1, map.Count);
		AreEqual("https://github.com/cedx/akismet.net", map["blog"]);

		// It should return a non-empty map with an initialized instance.
		map = new Blog(url: "https://github.com/cedx/akismet.net") { Charset = Encoding.UTF8, Languages = ["en", "fr"] }.ToDictionary();
		AreEqual(3, map.Count);
		AreEqual("https://github.com/cedx/akismet.net", map["blog"]);
		AreEqual("utf-8", map["blog_charset"]);
		AreEqual("en,fr", map["blog_lang"]);
	}
}
