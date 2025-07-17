namespace Belin.Akismet;

/// <summary>
/// Tests the features of the <see cref="Author"/> class.
/// </summary>
[TestClass]
public sealed class AuthorTest {

	[TestMethod]
	public void ToDictionary() {
		// It should return only the IP address with a newly created instance.
		var map = new Author(ipAddress: "127.0.0.1").ToDictionary();
		HasCount(1, map);
		AreEqual("127.0.0.1", map["user_ip"]);

		// It should return a non-empty map with an initialized instance.
		var author = new Author(ipAddress: "192.168.0.1") {
			Name = "Cédric Belin",
			Email = "cedx@outlook.com",
			Url = new Uri("https://belin.io"),
			UserAgent = "Mozilla/5.0"
		};

		map = author.ToDictionary();
		HasCount(5, map);
		AreEqual("Cédric Belin", map["comment_author"]);
		AreEqual("cedx@outlook.com", map["comment_author_email"]);
		AreEqual("https://belin.io/", map["comment_author_url"]);
		AreEqual("Mozilla/5.0", map["user_agent"]);
		AreEqual("192.168.0.1", map["user_ip"]);
	}
}
