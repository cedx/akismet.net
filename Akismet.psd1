@{
	DefaultCommandPrefix = "Akismet"
	ModuleVersion = "4.0.0"
	PowerShellVersion = "7.5"
	RootModule = "bin/Belin.Akismet.Cmdlets.dll"

	Author = "Cédric Belin <cedx@outlook.com>"
	CompanyName = "Cedric-Belin.fr"
	Copyright = "© Cédric Belin"
	Description = "Prevent comment spam using the Akismet service."
	GUID = "f986768a-1709-4142-815e-ce3be0db833e"

	AliasesToExport = @()
	FunctionsToExport = @()
	VariablesToExport = @()

	CmdletsToExport = @(
		"New-Author"
		"New-Blog"
		"New-Client"
		"New-Comment"
		"Submit-Ham"
		"Submit-Spam"
		"Test-ApiKey"
		"Test-Comment"
	)

	RequiredAssemblies = @(
		"bin/Belin.Akismet.dll"
	)

	PrivateData = @{
		PSData = @{
			LicenseUri = "https://github.com/cedx/akismet.net/blob/main/License.md"
			ProjectUri = "https://github.com/cedx/akismet.net"
			ReleaseNotes = "https://github.com/cedx/akismet.net/releases"
			Tags = "akismet", "api", "client", "comment", "spam", "validation"
		}
	}
}
