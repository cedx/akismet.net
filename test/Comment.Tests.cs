namespace Belin.Akismet;

using System.Globalization;

/// <summary>
/// Tests the features of the <see cref="Comment"/> class.
/// </summary>
[TestClass]
public sealed class CommentTests {

	[TestMethod]
	public void ToDictionary() {
		// It should return only the author info with a newly created instance.
		var map = new Comment(new Author(ipAddress: "127.0.0.1")).ToDictionary();
		HasCount(1, map);
		AreEqual("127.0.0.1", map["user_ip"]);

		// It should return a non-empty map with an initialized instance.
		var author = new Author(ipAddress: "127.0.0.1") {
			Name = "Cédric Belin",
			UserAgent = "Doom/6.6.6"
		};

		var comment = new Comment(author) {
			Content = "A user comment.",
			Date = DateTime.Parse("2000-01-01T00:00:00Z", styles: DateTimeStyles.RoundtripKind),
			Referrer = new Uri("https://cedric-belin.fr"),
			Type = CommentType.BlogPost
		};

		map = comment.ToDictionary();
		HasCount(7, map);
		AreEqual("Cédric Belin", map["comment_author"]);
		AreEqual("A user comment.", map["comment_content"]);
		AreEqual("2000-01-01T00:00:00.0000000Z", map["comment_date_gmt"]);
		AreEqual("blog-post", map["comment_type"]);
		AreEqual("https://cedric-belin.fr/", map["referrer"]);
		AreEqual("Doom/6.6.6", map["user_agent"]);
		AreEqual("127.0.0.1", map["user_ip"]);
	}
}
