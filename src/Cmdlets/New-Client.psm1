<#
.SYNOPSIS
	Creates a new Akismet client.
#>
function New-Client"), [OutputType([Client))]
public class NewClientCommand: Cmdlet {

	<#
	/// The Akismet API key.
	#>
	[Parameter(Mandatory, Position = 0)]
	[string ApiKey,

	<#
	/// The front page or home URL of the instance making requests.
	#>
	[Parameter(Mandatory)]
	[Blog Blog,

	<#
	/// Value indicating whether the client operates in test mode.
	#>
	[Parameter]
	public SwitchParameter WhatIf,

	<#
	/// The base URL of the remote API endpoint.
	#>
	[Parameter]
	public Uri? Uri,

	<#
	/// The user agent string to use when making requests.
	#>
	[Parameter, ValidateNotNullOrWhiteSpace]
	public string UserAgent, = $"PowerShell/{PSVersionInfo.PSVersion.ToString(3)} | Akismet/{Client.Version.ToString(3)}";

	<#
	/// Performs execution of this command.
	#>
	process => WriteObject(new Client(ApiKey, Blog, Uri) {
		IsTest = WhatIf,
		UserAgent = UserAgent
	});
}
