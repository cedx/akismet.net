if ($Release) {
	& "$PSScriptRoot/Clean.ps1"
	& "$PSScriptRoot/Version.ps1"
}
else {
	"The ""-Release"" switch must be set!"
	exit 1
}

"Publishing the package..."
$module = Import-PowerShellDataFile "Akismet.psd1"
$version = $module.ModuleVersion
git tag "v$version"
git push origin "v$version"

dotnet pack --output var/NuGet
foreach ($item in Get-Item "var/NuGet/*.nupkg") {
	dotnet nuget push $item --api-key $Env:NUGET_API_KEY --source https://api.nuget.org/v3/index.json
}

$name = Split-Path "Akismet.psd1" -LeafBase
$output = "var/$name"
New-Item $output/bin -ItemType Directory | Out-Null
Copy-Item "$name.psd1" $output
Copy-Item *.md $output
Copy-Item $module.RootModule $output/bin
if ("RequiredAssemblies" -in $module.Keys) { Copy-Item $module.RequiredAssemblies $output/bin }

Compress-PSResource $output var/PSGallery
Publish-PSResource -ApiKey $Env:PSGALLERY_API_KEY -NupkgPath "var/PSGallery/$name.$version.nupkg"
