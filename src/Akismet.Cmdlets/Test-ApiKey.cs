namespace Belin.Akismet.Cmdlets;

/// <summary>
/// Checks the API key against the service database, and returns a value indicating whether it is valid.
/// </summary>
[Cmdlet(VerbsDiagnostic.Test, "ApiKey")]
[OutputType(typeof(bool))]
public class TestApiKeyCommand: Cmdlet {

	/// <summary>
	/// The Akismet API key.
	/// </summary>
	[Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
	public required string ApiKey { get; set; }

	/// <summary>
	/// The front page or home URL of the instance making requests.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required Blog Blog { get; set; }

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() =>
		WriteObject(new Client(ApiKey, Blog).VerifyKey().GetAwaiter().GetResult());
}
