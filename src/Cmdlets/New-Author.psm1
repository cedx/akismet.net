using namespace Belin.Akismet
using namespace System.Net

<#
.SYNOPSIS
	Creates a new author.
.OUTPUTS
	The newly created author.
#>
function New-Author {
	[CmdletBinding()]
	[OutputType([Belin.Akismet.Author])]
	param (
		# The author's IP address.
		[Parameter(Mandatory)]
		[ipaddress] $IPAddress,

		# The author's name. If you set it to `"viagra-test-123"`, Akismet will always return `$true`.
		[Parameter(Position = 0)]
		[string] $Name,

		# The author's mail address. If you set it to `"akismet-guaranteed-spam@example.com"`, Akismet will always return `$true`.
		[string] $Email,

		# The author's role. If you set it to `"administrator"`, Akismet will always return `$false`.
		[string] $Role,

		# The URL of the author's website.
		[uri] $Url,

		# The author's user agent, that is the string identifying the Web browser used to submit comments.
		[string] $UserAgent
	)

	$author = [Author] $IPAddress
	$author.Email = $Email ?? ""
	$author.Name = $Name ?? ""
	$author.Role = $Role ?? ""
	$author.Url = $Url
	$author.UserAgent = $UserAgent ?? ""
	$author
}
