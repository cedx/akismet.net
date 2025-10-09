Write-Output "Updating the version number in the sources..."
$version = (Select-Xml "//Version" Package.xml).Node.InnerText
(Get-Content "src/Client.cs") -replace 'Version = "\d+(\.\d+){2}"', "Version = ""$version""" | Out-File "src/Client.cs"
Get-ChildItem "*/*.csproj" | ForEach-Object {
	(Get-Content $_) -replace "<Version>\d+(\.\d+){2}</Version>", "<Version>$version</Version>" | Out-File $_
}
