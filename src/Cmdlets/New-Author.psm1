using namespace Belin.Akismet

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
		[ValidateNotNull()]
		[string] $Name = "",

		# The author's mail address. If you set it to `"akismet-guaranteed-spam@example.com"`, Akismet will always return `$true`.
		[ValidateNotNull()]
		[string] $Email = "",

		# The author's role. If you set it to `"administrator"`, Akismet will always return `$false`.
		[ValidateNotNull()]
		[string] $Role = "",

		# The URL of the author's website.
		[uri] $Url,

		# The author's user agent, that is the string identifying the Web browser used to submit comments.
		[ValidateNotNull()]
		[string] $UserAgent = ""
	)

	$author = [Author] $IPAddress
	$author.Email = $Email
	$author.Name = $Name
	$author.Role = $Role
	$author.Url = $Url
	$author.UserAgent = $UserAgent
	$author
}
