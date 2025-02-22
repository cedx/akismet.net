using Belin.Akismet;
using System;
using System.Net.Http;

// Submits spam to the Akismet service.
try {
	var author = new Author(ipAddress: "192.168.123.456") { UserAgent = "Spam Bot/6.6.6" };
	var comment = new Comment(author) { Content = "Spam!" };

	var client = new Client("123YourAPIKey", new Blog("https://www.yourblog.com"));
	await client.SubmitSpam(comment);

	Console.WriteLine("The comment was successfully submitted as spam.");
}
catch (HttpRequestException e) {
	Console.Error.WriteLine($"An error occurred: {e.Message}");
}
