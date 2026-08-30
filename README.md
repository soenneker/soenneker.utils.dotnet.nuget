[![](https://img.shields.io/nuget/v/soenneker.utils.dotnet.nuget.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.dotnet.nuget/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.dotnet.nuget/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.dotnet.nuget/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.dotnet.nuget.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.dotnet.nuget/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.dotnet.nuget/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.dotnet.nuget/actions/workflows/codeql.yml)

# Soenneker.Utils.Dotnet.NuGet

DI-friendly wrappers for `dotnet nuget push` and `dotnet nuget delete`.

## Installation

```bash
dotnet add package Soenneker.Utils.Dotnet.NuGet
```

## Registration

```csharp
builder.Services.AddDotnetNuGetUtilAsSingleton();
```

`AddDotnetNuGetUtilAsScoped()` is also available and registers the underlying `IDotnetUtil` with the same lifetime.

## Push a package

```csharp
bool pushed = await nuget.Push(
    packagePath,
    apiKey: apiKey,
    source: "https://api.nuget.org/v3/index.json",
    skipDuplicate: true,
    timeout: 300,
    cancellationToken: cancellationToken);
```

Set `symbolSource` and `symbolApiKey` when symbols use a separate server. `noSymbols: true` suppresses symbol-package upload. With `skipDuplicate: true`, the CLI treats an already published package as a warning instead of a failure when the source supports that behavior.

## Delete a package version

```csharp
bool deleted = await nuget.Delete(
    packageName: "Example.Package",
    packageVersion: "1.2.3",
    apiKey: apiKey,
    source: "https://api.nuget.org/v3/index.json",
    cancellationToken: cancellationToken);
```

The source decides what deletion means. NuGet.org normally unlists a version rather than physically removing it. The default call is non-interactive; set `interactive: true` and `nonInteractive: false` together when the source requires prompts.

Both methods return `false` for validation, startup, and CLI failures. Requested cancellation throws `OperationCanceledException`. The `log` parameter is retained by the API but these wrappers do not emit their own operational logs.

API keys are passed to the `dotnet` child process as command-line arguments, as required by these CLI commands. Command lines can be visible to privileged process-inspection tools; prefer short-lived, least-privilege credentials and avoid recording the constructed command.
