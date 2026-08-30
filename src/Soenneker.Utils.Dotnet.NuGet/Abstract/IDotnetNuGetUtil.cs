using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Utils.Dotnet.NuGet.Abstract;

/// <summary>
/// A utility library for dotnet NuGet operations
/// </summary>
public interface IDotnetNuGetUtil
{
    /// <summary>
    /// Runs <c>dotnet nuget push</c> with the supplied source, authentication, symbol, and duplicate-handling options.
    /// </summary>
    /// <param name="packagePath">The NuGet package path.</param>
    /// <param name="apiKey">The package-source API key.</param>
    /// <param name="source">The NuGet package-source URL.</param>
    /// <param name="disableBuffering">True to disable request buffering.</param>
    /// <param name="noSymbols">True to skip a symbols package.</param>
    /// <param name="noServiceEndpoint">True to use the source exactly rather than append a service endpoint.</param>
    /// <param name="skipDuplicate">True to treat an existing package as success.</param>
    /// <param name="timeout">The maximum allowed execution time.</param>
    /// <param name="symbolSource">The symbols-package source URL.</param>
    /// <param name="symbolApiKey">The symbols-source API key.</param>
    /// <param name="verbosity">The <c>dotnet</c> output verbosity.</param>
    /// <param name="log">Retained for API compatibility; the implementation does not emit operational logs.</param>
    /// <param name="cancellationToken">Signals that the operation should stop.</param>
    /// <returns>True when the command exits successfully.</returns>
    ValueTask<bool> Push(string packagePath,
        string? apiKey = null,
        string? source = "https://api.nuget.org/v3/index.json",
        bool? disableBuffering = null,
        bool? noSymbols = null,
        bool? noServiceEndpoint = null,
        bool? skipDuplicate = null,
        int? timeout = null,
        string? symbolSource = null,
        string? symbolApiKey = null,
        string? verbosity = null,
        bool log = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Runs <c>dotnet nuget delete</c> for one package version with the supplied authentication and interaction options.
    /// </summary>
    /// <param name="packageName">The NuGet package identifier.</param>
    /// <param name="packageVersion">The exact package version.</param>
    /// <param name="apiKey">The package-source API key.</param>
    /// <param name="source">The NuGet package-source URL.</param>
    /// <param name="noServiceEndpoint">True to use the source exactly rather than append a service endpoint.</param>
    /// <param name="forceEnglishOutput">True to force English command output.</param>
    /// <param name="interactive">True to permit prompts.</param>
    /// <param name="nonInteractive">True to prevent prompts.</param>
    /// <param name="log">Retained for API compatibility; the implementation does not emit operational logs.</param>
    /// <param name="cancellationToken">Signals that the operation should stop.</param>
    /// <returns>True when the command exits successfully.</returns>
    ValueTask<bool> Delete(string packageName,
        string packageVersion,
        string? apiKey = null,
        string? source = "https://api.nuget.org/v3/index.json",
        bool? noServiceEndpoint = null,
        bool forceEnglishOutput = true,
        bool interactive = false,
        bool nonInteractive = true,
        bool log = true, CancellationToken cancellationToken = default);
}
