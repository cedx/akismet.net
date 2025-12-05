namespace Belin.Akismet.Cmdlets;

using System.Text;

/// <summary>
/// Creates a new blog.
/// </summary>
[Cmdlet(VerbsCommon.New, "Blog")]
[OutputType(typeof(Blog))]
public class NewBlogCommand: Cmdlet {

	/// <summary>
	/// The character encoding for the values included in comments.
	/// </summary>
	[Parameter, ValidateCharset]
	public string? Charset { get; set; }

	/// <summary>
	/// The languages in use on the blog or site, in ISO 639-1 format.
	/// </summary>
	[Parameter]
	public string[] Languages { get; set; } = [];

	/// <summary>
	/// The blog or site URL.
	/// </summary>
	[Parameter(Mandatory = true, Position = 0)]
	public required Uri Url { get; set; }

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => WriteObject(new Blog(Url) {
		Charset = string.IsNullOrWhiteSpace(Charset) ? null : Encoding.GetEncoding(Charset),
		Languages = Languages
	});
}

/// <summary>
/// Validates the <see cref="NewBlogCommand.Charset"/> parameter.
/// </summary>
internal class ValidateCharsetAttribute: ValidateArgumentsAttribute {

	/// <summary>
	/// Verifies that the value of <c>arguments</c> is valid.
	/// </summary>
	/// <param name="arguments">The argument value to validate.</param>
	/// <param name="engineIntrinsics">The engine APIs for the context under which the prerequisite is being evaluated.</param>
	/// <exception cref="ValidationMetadataException">The validation failed.</exception>
  protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics) {
		var charset = arguments as string;
		if (string.IsNullOrWhiteSpace(charset)) return;
		if (Encoding.GetEncodings().Any(value => charset.Equals(value.GetEncoding().WebName, StringComparison.OrdinalIgnoreCase))) return;
		throw new ValidationMetadataException("The character encoding is invalid.");
  }
}
