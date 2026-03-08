# Installation

## Requirements
Before installing **Akismet for .NET**, you need to make sure you have the [.NET SDK](https://learn.microsoft.com/en-us/dotnet/core/sdk)
and/or [PowerShell](https://learn.microsoft.com/en-us/powershell) up and running.
		
You can verify if you're already good to go with the following commands:

```shell
dotnet --version
# 10.0.103

pwsh --version
# PowerShell 7.5.4
```

## Installing the .NET library with NuGet package manager

### 1. Install it
From a command prompt, run:

```shell
dotnet add package Belin.Akismet
```

### 2. Import it
Now in your [C#](https://learn.microsoft.com/en-us/dotnet/csharp) code, you can use:

```cs
using Belin.Akismet;
```

## Installing the PowerShell module with PSResourceGet package manager

### 1. Install it
From a command prompt, run:

```powershell
Install-PSResource -Name Akismet -Repository PSGallery
```

### 2. Import it
Now in your [PowerShell](https://learn.microsoft.com/en-us/powershell) code, you can use:

```powershell
Import-Module -Name Akismet
```
