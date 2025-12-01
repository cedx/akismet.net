"Updating the version number in the sources..."
$version = (Import-PowerShellDataFile "Akismet.psd1").ModuleVersion
(Get-Content "src/Akismet/Client.cs") -replace 'Version = "\d+(\.\d+){2}"', "Version = ""$version""" | Out-File "src/Akismet/Client.cs"
foreach ($item in Get-ChildItem "*/*.csproj" -Recurse) {
	(Get-Content $item) -replace "<Version>\d+(\.\d+){2}</Version>", "<Version>$version</Version>" | Out-File $item
}
