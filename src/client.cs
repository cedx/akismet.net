namespace Belin.Akismet;

/// <summary>
/// Submits comments to the Akismet service.
/// </summary>
/// <param name="apiKey">The Akismet API key.</param>
/// <param name="blog">The front page or home URL of the instance making requests.</param>
/// <param name="baseUrl">The base URL of the remote API endpoint.</param>
public class Client(string apiKey, Blog blog, string baseUrl = "https://rest.akismet.com") {

	/// <summary>
	/// The response returned by the `submit-ham` and `submit-spam` endpoints when the outcome is a success.
	/// </summary>
	private const string Success = "Thanks for making the web a better place.";

	/// <summary>
	/// The package version.
	/// </summary>
	private const string Version = "1.0.0";

	/// <summary>
	/// The Akismet API key.
	/// </summary>
	public string ApiKey { get; private set; } = apiKey;

	/// <summary>
	/// The base URL of the remote API endpoint.
	/// </summary>
	public Uri BaseUrl { get; private set; } = new Uri(baseUrl.EndsWith('/') ? baseUrl : $"{baseUrl}/");

	/// <summary>
	/// The front page or home URL of the instance making requests.
	/// </summary>
	public Blog Blog { get; private set; } = blog;

	/// <summary>
	/// Value indicating whether the client operates in test mode.
	/// </summary>
	public bool IsTest { get; init; } = false;

	/// <summary>
	/// The user agent string to use when making requests.
	/// </summary>
	public string UserAgent { get; init; } = $".NET/{Environment.Version} | Akismet/{Version}";
}
