namespace Belin.Akismet;

using System.Text;

/// <summary>
/// Tests the features of the <see cref="Blog"/> class.
/// </summary>
[TestClass]
public sealed class BlogTests {

	[TestMethod]
	public void ToDictionary() {
		// It should return only the blog URL with a newly created instance.
		var dictionary = (Dictionary<string, string>) new Blog("https://github.com/cedx/akismet.net");
		HasCount(1, dictionary);
		AreEqual("https://github.com/cedx/akismet.net", dictionary["blog"]);

		// It should return a non-empty map with an initialized instance.
		dictionary = (Dictionary<string, string>) new Blog("https://github.com/cedx/akismet.net") { Charset = Encoding.UTF8, Languages = ["en", "fr"] };
		HasCount(3, dictionary);
		AreEqual("https://github.com/cedx/akismet.net", dictionary["blog"]);
		AreEqual("utf-8", dictionary["blog_charset"]);
		AreEqual("en,fr", dictionary["blog_lang"]);
	}
}
