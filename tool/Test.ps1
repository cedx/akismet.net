"Running the test suite..."
dotnet test --results-directory var
pwsh -Command {
	Import-Module Pester
	Invoke-Pester test
	exit $LASTEXITCODE
}
