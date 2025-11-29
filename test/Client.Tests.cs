namespace Belin.Akismet;

/// <summary>
/// Tests the features of the <see cref="Client"/> class.
/// </summary>
[TestClass]
public sealed class ClientTests {

	/// <summary>
	/// The client used to query the remote API.
	/// </summary>
	private readonly Client client;

	/// <summary>
	/// A comment with content marked as ham.
	/// </summary>
	private readonly Comment ham;

	/// <summary>
	/// A comment with content marked as spam.
	/// </summary>
	private readonly Comment spam;

	/// <summary>
	/// The test context.
	/// </summary>
	private readonly TestContext testContext;

	/// <summary>
	/// Creates a new test.
	/// </summary>
	/// <param name="testContext">The test context.</param>
	public ClientTests(TestContext testContext) {
		client = new Client(Environment.GetEnvironmentVariable("AKISMET_API_KEY")!, "https://github.com/cedx/akismet.net") { IsTest = true };
		this.testContext = testContext;

		var hamAuthor = new Author(ipAddress: "192.168.0.1") {
			Name = "Akismet",
			Role = AuthorRole.Administrator,
			Url = new Uri("https://cedric-belin.fr"),
			UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36 Edg/142.0.0.0"
		};

		ham = new Comment(hamAuthor) {
			Content = "I'm testing out the Service API.",
			Referrer = new Uri("https://www.nuget.org/packages/Belin.Akismet"),
			Type = CommentType.Comment
		};

		var spamAuthor = new Author(ipAddress: "127.0.0.1") {
			Email = "akismet-guaranteed-spam@example.com",
			Name = "viagra-test-123",
			UserAgent = "Spam Bot/6.6.6"
		};

		spam = new Comment(spamAuthor) {
			Content = "Spam!",
			Date = DateTime.Now,
			Type = CommentType.BlogPost
		};
	}

	[TestMethod]
	public async Task CheckComment() {
		AreEqual(CheckResult.Ham, await client.CheckComment(ham, testContext.CancellationToken));

		var result = await client.CheckComment(spam, testContext.CancellationToken);
		IsTrue(result == CheckResult.Spam || result == CheckResult.PervasiveSpam);
	}

	[TestMethod]
	public async Task SubmitHam() =>
		await client.SubmitHam(ham, testContext.CancellationToken);

	[TestMethod]
	public async Task SubmitSpam() =>
		await client.SubmitSpam(spam, testContext.CancellationToken);

	[TestMethod]
	public async Task VerifyKey() {
		IsTrue(await client.VerifyKey(testContext.CancellationToken));

		var newClient = new Client("0123456789-ABCDEF", client.Blog) { IsTest = true };
		IsFalse(await newClient.VerifyKey(testContext.CancellationToken));
	}
}
