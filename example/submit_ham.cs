using Belin.Akismet;
using System;
using System.Net.Http;

// Submits ham to the Akismet service.
try {
	var author = new Author(ipAddress: "192.168.123.456") {
		UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/133.0.0.0 Safari/537.36 Edg/133.0.0.0"
	};

	var comment = new Comment(author) { Content = "I'm testing out the Service API." };
	var client = new Client("123YourAPIKey", new Blog("https://www.yourblog.com"));
	await client.SubmitHam(comment);

	Console.WriteLine("The comment was successfully submitted as ham.");
}
catch (HttpRequestException e) {
	Console.Error.WriteLine($"An error occurred: {e.Message}");
}
