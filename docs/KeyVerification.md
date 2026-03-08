# Key Verification
Key verification authenticates your API key before calling the [comment check](CommentCheck.md),
[submit spam](SubmitSpam.md) or [submit ham](SubmitHam.md) methods.

This is the first call that you should make to Akismet and is especially useful
if you will have multiple users with their own Akismet subscriptions using your application.

See the [Akismet API documentation](https://akismet.com/developers/detailed-docs/key-verification) for more information.

## .NET/C#
```cs
Task<bool> Client.VerifyKey(CancellationToken cancellationToken = default)
```

### Parameters

#### CancellationToken **cancellationToken**
The token to cancel the operation.

### Return value
A `Task` that completes with a boolean value indicating whether the client's API key is valid.

The task faults with a `HttpRequestException` when an issue occurs.
The exception `Message` usually includes some debug information, provided by the `X-akismet-debug-help` HTTP header,
about what exactly was invalid about the call.

It can also fault with a custom error message (provided by the `X-akismet-alert-msg` header).
See [Response Error Codes](https://akismet.com/developers/detailed-docs/errors) for more information.

### Example

```cs
using Belin.Akismet;
using System;
using System.Net.Http;

try {
  var client = new Client("123YourAPIKey", "https://www.yourblog.com");
  var isValid = await client.VerifyKey();
  Console.WriteLine(isValid ? "The API key is valid." : "The API key is invalid.");
}
catch (HttpRequestException e) {
  Console.Error.WriteLine($"An error occurred: {e.Message}");
}
```

See the [source code](https://github.com/cedx/akismet.net/tree/main/src/Akismet) for detailed information
about the `Client` and `Blog` classes, and their properties and methods.

## PowerShell
```pwsh
Test-AkismetApiKey -ApiKey "123YourAPIKey" -Blog "https://www.yourblog.com"
```

### Parameters

#### **-ApiKey** &lt;string&gt;
The Akismet API key.

#### **-Blog** &lt;Blog&gt;
The front page or home URL of the instance making requests.

### Return value
A boolean value indicating whether the specified API key is valid.

The cmdlet throws a `HttpRequestException` error when an issue occurs.
The exception `Message` usually includes some debug information, provided by the `X-akismet-debug-help` HTTP header,
about what exactly was invalid about the call.

It can also fault with a custom error message (provided by the `X-akismet-alert-msg` header).
See [Response Error Codes](https://akismet.com/developers/detailed-docs/errors) for more information.

### Example

```powershell
Import-Module Akismet

$isValid = Test-AkismetApiKey "123YourAPIKey" -Blog "https://www.yourblog.com"
Write-Output ($isValid ? "The API key is valid." : "The API key is invalid.")
```

See the [source code](https://github.com/cedx/akismet.net/tree/main/src/Akismet.Cmdlets) for detailed information
about the `New-AkismetClient` and `New-AkismetBlog` classes, and their parameters.
