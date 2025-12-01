<#
.SYNOPSIS
	Checks a comment against the Akismet service.
#>
Import-Module Akismet

$author = @{
	Email = "john.doe@domain.com"
	IPAddress = "192.168.0.1"
	Name = "John Doe"
	Role = "guest"
	UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36 Edg/142.0.0.0"
}

$comment = @{
	Author = New-AkismetAuthor @author
	Date = Get-Date
	Content = "A user comment."
	Referrer = "https://github.com/cedx/akismet.ps1"
	Type = "contact-form"
}

$blog = @{
	Charset = "utf-8"
	Languages = , "fr"
	Url = "https://www.yourblog.com"
}

$client = New-AkismetClient -ApiKey "123YourAPIKey" -Blog (New-AkismetBlog @blog)
$result = Test-AkismetComment -Client $client -Comment (New-AkismetComment @comment)
Write-Output ($result -eq "Ham" ? "The comment is ham." : "The comment is spam.")
