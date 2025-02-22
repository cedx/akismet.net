namespace Belin.Akismet;

using System.Text;

/// <summary>
/// Tests the features of the <see cref="Blog"/> class.
/// </summary>
[TestClass]
public sealed class BlogTest {

	[TestMethod]
	public void ToJson() {
		// It should return only the blog URL with a newly created instance.
		var map = new Blog(url: "https://github.com/cedx/akismet.cs").ToJson();
		AreEqual(1, map.Count);
		AreEqual("https://github.com/cedx/akismet.cs", map["blog"]);

		// It should return a non-empty map with an initialized instance.
		map = new Blog(url: "https://github.com/cedx/akismet.cs") { Charset = Encoding.UTF8, Languages = ["en", "fr"] }.ToJson();
		AreEqual(3, map.Count);
		AreEqual("https://github.com/cedx/akismet.cs", map["blog"]);
		AreEqual("utf-8", map["blog_charset"]);
		AreEqual("en,fr", map["blog_lang"]);
	}
}
