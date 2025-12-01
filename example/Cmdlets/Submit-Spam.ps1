<#
.SYNOPSIS
	Submits spam to the Akismet service.
#>
Import-Module Akismet

$author = New-AkismetAuthor -IPAddress "127.0.0.1" -UserAgent "Spam Bot/6.6.6"
$comment = New-AkismetComment "Spam!" -Author $author

$client = New-AkismetClient -ApiKey "123YourAPIKey" -Blog "https://www.yourblog.com"
Submit-AkismetSpam -Client $client -Comment $comment
Write-Output "The comment was successfully submitted as spam."
