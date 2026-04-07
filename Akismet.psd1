@{
	DefaultCommandPrefix = "Akismet"
	ModuleVersion = "4.0.0"
	PowerShellVersion = "7.6"

	Author = "Cédric Belin <cedx@outlook.com>"
	CompanyName = "Cedric-Belin.fr"
	Copyright = "© Cédric Belin"
	Description = "Prevent comment spam using the Akismet service."
	GUID = "f986768a-1709-4142-815e-ce3be0db833e"

	AliasesToExport = @()
	CmdletsToExport = @()
	VariablesToExport = @()

	FunctionsToExport = @(
		"New-Author"
		"New-Blog"
		"New-Client"
		"New-Comment"
		"Submit-Ham"
		"Submit-Spam"
		"Test-ApiKey"
		"Test-Comment"
	)

	NestedModules = @(
		"src/Cmdlets/New-Author.psm1"
		"src/Cmdlets/New-Blog.psm1"
		"src/Cmdlets/New-Client.psm1"
		"src/Cmdlets/New-Comment.psm1"
		"src/Cmdlets/Submit-Ham.psm1"
		"src/Cmdlets/Submit-Spam.psm1"
		"src/Cmdlets/Test-ApiKey.psm1"
		"src/Cmdlets/Test-Comment.psm1"
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
