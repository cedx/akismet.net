<#
.SYNOPSIS
	Submits ham to the Akismet service.
#>
Import-Module Akismet

$author = New-AkismetAuthor -IPAddress "192.168.0.1" -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36 Edg/142.0.0.0"
$comment = New-AkismetComment "I'm testing out the Service API." -Author $author

$client = New-AkismetClient -ApiKey "123YourAPIKey" -Blog "https://www.yourblog.com"
Submit-AkismetHam -Client $client -Comment $comment
Write-Output "The comment was successfully submitted as ham."
