Write-Host "Updating the version number in the sources..."
$version = (Select-Xml "//Version" Package.xml).Node.InnerText
(Get-Content "src/Client.cs") -replace 'Version = "\d+(\.\d+){2}"', "Version = ""$version""" | Out-File "src/Client.cs"
foreach ($item in Get-ChildItem "*/*.csproj") {
	(Get-Content $item) -replace "<Version>\d+(\.\d+){2}</Version>", "<Version>$version</Version>" | Out-File $item
}
