"Building the project..."
$configuration = $release ? "Release" : "Debug"
dotnet build Akismet.slnx --configuration=$configuration
