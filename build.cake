using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using static System.IO.File;

var release = HasArgument("r") || HasArgument("release");
var target = HasArgument("t") ? Argument<string>("t") : Argument("target", "default");
var version = Context.Configuration.GetValue("package_version");

Task("build")
	.Description("Builds the project.")
	.Does(() => DotNetBuild("Akismet.slnx", new() { Configuration = release ? "Release" : "Debug" }));

Task("clean")
	.Description("Deletes all generated files.")
	.Does(() => EnsureDirectoryDoesNotExist("lib"))
	.DoesForEach(GetDirectories("*/obj"), EnsureDirectoryDoesNotExist)
	.Does(() => CleanDirectory("var", fileSystemInfo => fileSystemInfo.Path.Segments[^1] != ".gitkeep"));

Task("format")
	.Description("Formats the source code.")
	.DoesForEach(["src", "test"], project => DotNetFormat(project));

Task("outdated")
	.Description("Checks for outdated dependencies.")
	.Does(() => StartProcess("dotnet", new ProcessSettings { Arguments = "list package --outdated" }));

Task("publish")
	.Description("Publishes the package.")
	.WithCriteria(release, @"the ""Release"" configuration must be enabled")
	.IsDependentOn("default")
	.Does(() => DotNetPack("Akismet.slnx", new() { OutputDirectory = "var" }))
	.DoesForEach(["tag", "push origin"], action => StartProcess("git", $"{action} v{version}"))
	.DoesForEach(() => GetFiles("var/*.nupkg"), file => DotNetNuGetPush(file, new() { ApiKey = EnvironmentVariable("NUGET_API_KEY"), Source = "https://api.nuget.org/v3/index.json" }))
	.DoesForEach(() => GetFiles("var/*.nupkg"), file => DotNetNuGetPush(file, new() { ApiKey = EnvironmentVariable("GITHUB_TOKEN"), Source = "https://nuget.pkg.github.com/cedx/index.json" }));

Task("test")
	.Description("Runs the test suite.")
	.Does(() => DotNetTest("Akismet.slnx", new() { Settings = ".runsettings" }));

Task("version")
	.Description("Updates the version number in the sources.")
	.Does(() => ReplaceInFile("src/client.cs", @"Version = ""\d+(\.\d+){2}.*"";", $"Version = \"{version}\";"))
	.DoesForEach(GetFiles("*/*.csproj"), file => ReplaceInFile(file, @"<Version>\d+(\.\d+){2}.*</Version>", $"<Version>{version}</Version>"));

Task("default")
	.Description("The default task.")
	.IsDependentOn("clean")
	.IsDependentOn("version")
	.IsDependentOn("build");

RunTarget(target);

/// <summary>
/// Replaces the specified pattern in a given file.
/// </summary>
/// <param name="file">The path of the file to be processed.</param>
/// <param name="pattern">The regular expression to find.</param>
/// <param name="replacement">The replacement text.</param>
/// <param name="options">The regular expression options to use.</param>
static void ReplaceInFile(FilePath file, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern, string replacement, RegexOptions options = RegexOptions.None) =>
	WriteAllText(file.FullPath, Regex.Replace(ReadAllText(file.FullPath), pattern, replacement, options));
