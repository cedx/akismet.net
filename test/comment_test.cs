namespace Belin.Akismet;

/// <summary>
/// Tests the features of the <see cref="Comment"/> class.
/// </summary>
[TestClass]
public sealed class CommentTest {

	[TestMethod]
	public void ToDictionary() {
		// It should return only the author info with a newly created instance.
		var map = new Comment(new Author(ipAddress: "127.0.0.1")).ToDictionary();
		AreEqual(1, map.Count);
		AreEqual("127.0.0.1", map["user_ip"]);

		// It should return a non-empty map with an initialized instance.
		var author = new Author(ipAddress: "127.0.0.1") {
			Name = "Cédric Belin",
			UserAgent = "Doom/6.6.6"
		};

		var comment = new Comment(author) {
			Content = "A user comment.",
			Date = DateTime.Parse("2000-01-01T00:00:00.000Z"),
			Referrer = new Uri("https://belin.io"),
			Type = "blog-post"
		};

		map = comment.ToDictionary();
		AreEqual(7, map.Count);
		AreEqual("Cédric Belin", map["comment_author"]);
		AreEqual("A user comment.", map["comment_content"]);
		AreEqual("2000-01-01T00:00:00Z", map["comment_date_gmt"]);
		AreEqual("blog-post", map["comment_type"]);
		AreEqual("https://belin.io/", map["referrer"]);
		AreEqual("Doom/6.6.6", map["user_agent"]);
		AreEqual("127.0.0.1", map["user_ip"]);
	}
}
