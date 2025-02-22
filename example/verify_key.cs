using Belin.Akismet;
using System;
using System.Net.Http;

// Verifies an Akismet API key.
try {
	var client = new Client("123YourAPIKey", new Blog("https://www.yourblog.com"));
	var isValid = await client.VerifyKey();
	Console.WriteLine(isValid ? "The API key is valid." : "The API key is invalid.");
}
catch (HttpRequestException e) {
	Console.Error.WriteLine($"An error occurred: {e.Message}");
}
