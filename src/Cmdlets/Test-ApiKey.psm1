<#
.SYNOPSIS
	Checks the API key against the service database, and returns a value indicating whether it is valid.
#>
function Test-ApiKey"), [OutputType([bool))]
public class TestApiKeyCommand: Cmdlet {

	<#
	/// The Akismet API key.
	#>
	[Parameter(Mandatory, Position = 0, ValueFromPipeline)]
	[string ApiKey,

	<#
	/// The front page or home URL of the instance making requests.
	#>
	[Parameter(Mandatory)]
	[Blog Blog,

	<#
	/// Performs execution of this command.
	#>
	process => WriteObject(new Client(ApiKey, Blog).VerifyKey());
}
