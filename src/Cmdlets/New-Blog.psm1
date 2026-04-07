using namespace Belin.Akismet
using namespace System.Text

<#
.SYNOPSIS
	Creates a new blog.
#>
function New-Blog {
	[CmdletBinding()]
	[OutputType([Belin.Akismet.Blog])]
	param (
		# The blog or site URL.
		[Parameter(Mandatory, Position = 0)]
		[uri] $Url,

		# The character encoding for the values included in comments.
		[ValidateScript({
			$charset = $_
			[string]::IsNullOrEmpty($charset) -or [Encoding].GetEncodings().Where({ $_.Name -eq $charset }, "First").Count
		}, ErrorMessage = "The character encoding is invalid.")]
		[string] $Charset,

		# The languages in use on the blog or site, in ISO 639-1 format.
		[ValidateNotNull()]
		[string[]] $Languages = @()
	)

	$blog = [Blog] $Url
	$blog.Charset = $Charset ? [Encoding]::GetEncoding($Charset) : $null
	$blog.Languages = $Languages
	$blog
}
