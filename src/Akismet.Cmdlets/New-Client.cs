namespace Belin.Akismet.Cmdlets;

/// <summary>
/// Creates a new Akismet client.
/// </summary>
[Cmdlet(VerbsCommon.New, "Client")]
[OutputType(typeof(Client))]
public class NewClientCommand: Cmdlet {

	/// <summary>
	/// The Akismet API key.
	/// </summary>
	[Parameter(Mandatory = true, Position = 0)]
	public required string ApiKey { get; set; }

	/// <summary>
	/// The front page or home URL of the instance making requests.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required Blog Blog { get; set; }

	/// <summary>
	/// Value indicating whether the client operates in test mode.
	/// </summary>
	[Parameter]
	public SwitchParameter WhatIf { get; set; }

	/// <summary>
	/// The base URL of the remote API endpoint.
	/// </summary>
	[Parameter]
	public Uri? Uri { get; set; }

	/// <summary>
	/// The user agent string to use when making requests.
	/// </summary>
	[Parameter, ValidateNotNullOrWhiteSpace]
	public string UserAgent { get; set; } = $"PowerShell/{PSVersionInfo.PSVersion.ToString(3)} | Akismet/{Client.Version.ToString(3)}";

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => WriteObject(new Client(ApiKey, Blog, Uri) {
		IsTest = WhatIf,
		UserAgent = UserAgent
	});
}
