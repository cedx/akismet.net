# Comment Check
This is the call you will make the most. It takes a number of arguments and characteristics about the submitted content
and then returns a thumbs up or thumbs down. **Performance can drop dramatically if you choose to exclude data points.**
The more data you send Akismet about each comment, the greater the accuracy. We recommend erring on the side of including too much data.

It is important to [test Akismet](Testing.md) with a significant amount of real, live data in order to draw any conclusions on accuracy.
Akismet works by comparing content to genuine spam activity happening **right now** (and this is based on more than just the content itself),
so artificially generating spam comments is not a viable approach.

See the [Akismet API documentation](https://akismet.com/developers/detailed-docs/comment-check) for more information.

## .NET/C#
```cs
Task<CheckResult> Client.CheckComment(Comment comment, CancellationToken cancellationToken = default)
```

### Parameters

#### Comment **comment**
The `Comment` providing the user's message to be checked.

#### CancellationToken **cancellationToken**
The token to cancel the operation.

### Return value
A `Task` that completes with a `CheckResult` value indicating whether the given `Comment` is ham, spam or pervasive spam.

> [!TIP]
> A comment classified as pervasive spam can be safely discarded.

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
using System.Text;

try {
  var author = new Author(ipAddress: "192.168.123.456") {
    Email = "john.doe@domain.com",
    Name = "John Doe",
    Role = "guest",
    UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/133.0.0.0 Safari/537.36 Edg/133.0.0.0"
  };

  var comment = new Comment(author) {
    Content = "A user comment.",
    Date = DateTime.Now,
    Referrer = new Uri("https://github.com/cedx/akismet.net"),
    Type = CommentType.ContactForm
  };

  var blog = new Blog("https://www.yourblog.com") { Charset = Encoding.UTF8, Languages = ["fr"] };
  var result = await new Client("123YourAPIKey", blog).CheckComment(comment);
  Console.WriteLine(result == CheckResult.Ham ? "The comment is ham." : "The comment is spam.");
}
catch (HttpRequestException e) {
  Console.Error.WriteLine($"An error occurred: {e.Message}");
}
```

See the [source code](https://github.com/cedx/akismet.net/tree/main/src/Akismet) for detailed information
about the `Author`, `Blog` and `Comment` classes, and their properties.

## PowerShell
```pwsh
Test-AkismetComment -Client $client -Comment $comment
```

### Parameters

#### **-Client** &lt;Client&gt;
The `[Client]` instance used to submit the comment.

#### **-Comment** &lt;Comment&gt;
The `[Comment]` providing the user's message to be checked.

### Return value
A `[CheckResult]` value indicating whether the given `Comment` is `"Ham"`, `"Spam"` or `"PervasiveSpam"`.

> [!TIP]
> A comment classified as `"PervasiveSpam"` can be safely discarded.

The cmdlet throws a `HttpRequestException` error when an issue occurs.
The exception `Message` usually includes some debug information, provided by the `X-akismet-debug-help` HTTP header,
about what exactly was invalid about the call.

It can also fault with a custom error message (provided by the `X-akismet-alert-msg` header).
See [Response Error Codes](https://akismet.com/developers/detailed-docs/errors) for more information.

### Example
```pwsh
Import-Module Akismet

$author = @{
  Email = "john.doe@domain.com"
  IPAddress = "192.168.0.1"
  Name = "John Doe"
  Role = "guest"
  UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:144.0) Gecko/20100101 Firefox/144.0"
}

$comment = @{
  Author = New-AkismetAuthor @author
  Date = Get-Date
  Content = "A user comment."
  Referrer = "https://github.com/cedx/akismet.ps1"
  Type = "contact-form"
}

$blog = @{
  Charset = "utf-8"
  Languages = , "fr"
  Url = "https://www.yourblog.com"
}

$client = New-AkismetClient -ApiKey "123YourAPIKey" -Blog (New-AkismetBlog @blog)
$result = Test-AkismetComment -Client $client -Comment (New-AkismetComment @comment)
Write-Output ($result -eq "Ham" ? "The comment is ham." : "The comment is spam.")
```

See the [source code](https://github.com/cedx/akismet.net/tree/main/src/Akismet.Cmdlets) for detailed information
about the `New-AkismetAuthor`, `New-AkismetBlog` and `New-AkismetComment` cmdlets, and their parameters.
