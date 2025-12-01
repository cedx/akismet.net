namespace Belin.Akismet.Cmdlets;

using System.Net;

/// <summary>
/// Creates a new author.
/// </summary>
[Cmdlet(VerbsCommon.New, "Author")]
[OutputType(typeof(Author))]
public class NewAuthor: Cmdlet {

	/// <summary>
	/// The author's mail address. If you set it to `"akismet-guaranteed-spam@example.com"`, Akismet will always return `$true`.
	/// </summary>
	[Parameter]
	public string Email { get; set; } = "";

	/// <summary>
	/// The author's IP address.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required IPAddress IPAddress { get; set; }

	/// <summary>
	/// The author's name. If you set it to `"viagra-test-123"`, Akismet will always return `$true`.
	/// </summary>
	[Parameter(Position = 0)]
	public string Name { get; set; } = "";

	/// <summary>
	/// The author's role. If you set it to `"administrator"`, Akismet will always return `$false`.
	/// </summary>
	[Parameter]
	public string Role { get; set; } = "";

	/// <summary>
	/// The URL of the author's website.
	/// </summary>
	[Parameter]
	public Uri? Url { get; set; }

	/// <summary>
	/// The author's user agent, that is the string identifying the Web browser used to submit comments.
	/// </summary>
	[Parameter]
	public string UserAgent { get; set; } = "";

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => WriteObject(new Author(IPAddress) {
		Email = Email,
		Name = Name,
		Role = Role,
		Url = Url,
		UserAgent = UserAgent
	});
}
