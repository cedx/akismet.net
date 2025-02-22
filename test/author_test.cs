namespace Belin.Akismet;

/// <summary>
/// Tests the features of the <see cref="Author"/> class.
/// </summary>
[TestClass]
public sealed class AuthorTest {

	[TestMethod]
	public void ToJson() {
		// It should return only the IP address with a newly created instance.
		var map = new Author(ipAddress: "127.0.0.1").ToJson();
		AreEqual(1, map.Count);
		AreEqual("127.0.0.1", map["user_ip"]);

		// It should return a non-empty map with an initialized instance.
		var author = new Author(ipAddress: "192.168.0.1") {
			Name = "Cédric Belin",
			Email = "cedric@belin.io",
			Url = new Uri("https://belin.io"),
			UserAgent = "Mozilla/5.0"
		};

		map = author.ToJson();
		AreEqual(5, map.Count);
		AreEqual("Cédric Belin", map["comment_author"]);
		AreEqual("cedric@belin.io", map["comment_author_email"]);
		AreEqual("https://belin.io/", map["comment_author_url"]);
		AreEqual("Mozilla/5.0", map["user_agent"]);
		AreEqual("192.168.0.1", map["user_ip"]);
	}
}
