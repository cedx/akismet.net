using System.Text;

<#
.SYNOPSIS
	Creates a new blog.
#>
function New-Blog"), [OutputType([Blog))]
public class NewBlogCommand: Cmdlet {

	<#
	/// The character encoding for the values included in comments.
	#>
	[Parameter, ValidateCharset]
	[string] $Charset,

	<#
	/// The languages in use on the blog or site, in ISO 639-1 format.
	#>
	[Parameter]
	public string[] Languages, = [];

	<#
	/// The blog or site URL.
	#>
	[Parameter(Mandatory, Position = 0)]
	[Uri Url,

	<#
	/// Performs execution of this command.
	#>
	process => WriteObject(new Blog(Url) {
		Charset = string.IsNullOrWhiteSpace(Charset) ? null : Encoding.GetEncoding(Charset),
		Languages = Languages
	});
}

<#
.SYNOPSIS
	Validates the <see cref="NewBlogCommand.Charset"/> parameter.
#>
internal class ValidateCharsetAttribute: ValidateArgumentsAttribute {

	<#
	/// Verifies that the value of <c>arguments</c> is valid.
	#>
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
