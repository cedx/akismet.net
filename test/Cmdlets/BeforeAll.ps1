using namespace System.Diagnostics.CodeAnalysis
Import-Module "$PSScriptRoot/../../Akismet.psd1"

$author = @{
	IPAddress = "192.168.0.1"
	Name = "Akismet"
	Role = "administrator"
	Url = "https://cedric-belin.fr"
	UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36 Edg/142.0.0.0"
}

$ham = @{
	Author = New-AkismetAuthor @author
	Content = "I'm testing out the Service API."
	Referrer = "https://www.powershellgallery.com/packages/Akismet"
	Type = "comment"
}

$author = @{
	Email = "akismet-guaranteed-spam@example.com"
	IPAddress = "127.0.0.1"
	Name = "viagra-test-123"
	UserAgent = "Spam Bot/6.6.6"
}

$spam = @{
	Author = New-AkismetAuthor @author
	Content = "Spam!"
	Date = Get-Date
	Type = "blog-post"
}

[SuppressMessage("PSUseDeclaredVarsMoreThanAssignments", "")]
$client = New-AkismetClient -ApiKey $Env:AKISMET_API_KEY -Blog "https://github.com/cedx/akismet.ps1" -WhatIf
$ham = New-AkismetComment @ham
$spam = New-AkismetComment @spam
