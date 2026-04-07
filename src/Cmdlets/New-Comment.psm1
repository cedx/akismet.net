using namespace Belin.Akismet
using namespace System.Diagnostics.CodeAnalysis

<#
.SYNOPSIS
	Creates a new comment.
.OUTPUTS
	The newly created comment.
#>
function New-Comment {
	[CmdletBinding()]
	[OutputType([Belin.Akismet.Comment])]
	[SuppressMessage("PSUseShouldProcessForStateChangingFunctions", "")]
	param (
		# The comment's author.
		[Parameter(Mandatory)]
		[Author] $Author,

		# The comment's content.
		[Parameter(Position = 0)]
		[ValidateNotNull()]
		[string] $Content = "",

		# The context in which this comment was posted.
		[ValidateNotNull()]
		[string[]] $Context = @(),

		# The UTC timestamp of the creation of the comment.
		[datetime] $Date,

		# The permanent location of the entry the comment is submitted to.
		[uri] $Permalink,

		# The UTC timestamp of the publication time for the post, page or thread on which the comment was posted.
		[datetime] $PostModified,

		# A string describing why the content is being rechecked.
		[ValidateNotNull()]
		[string] $RecheckReason = "",

		# The URL of the webpage that linked to the entry being requested.
		[uri] $Referrer,

		# The comment's type.
		[ValidateNotNull()]
		[string] $Type = ""
	)

	$comment = [Comment] $Author
	$comment.Content = $Content
	$comment.Context = $Context
	$comment.Date = $Date
	$comment.Permalink = $Permalink
	$comment.PostModified = $PostModified
	$comment.RecheckReason = $RecheckReason
	$comment.Referrer = $Referrer
	$comment.Type = $Type
	$comment
}
