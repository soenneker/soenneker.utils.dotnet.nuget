using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Utils.Dotnet.NuGet.Abstract;

/// <summary>
/// A utility library for dotnet NuGet operations
/// </summary>
public interface IDotnetNuGetUtil
{
    /// <summary>
    /// Executes the push operation.
    /// </summary>
    /// <param name="packagePath">The package path.</param>
    /// <param name="apiKey">The API key.</param>
    /// <param name="source">The source.</param>
    /// <param name="disableBuffering">The disable buffering.</param>
    /// <param name="noSymbols">The no symbols.</param>
    /// <param name="noServiceEndpoint">The no service endpoint.</param>
    /// <param name="skipDuplicate">The skip duplicate.</param>
    /// <param name="timeout">The timeout.</param>
    /// <param name="symbolSource">The symbol source.</param>
    /// <param name="symbolApiKey">The symbol api key.</param>
    /// <param name="verbosity">The verbosity.</param>
    /// <param name="log">The log.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
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
    /// Executes the delete operation.
    /// </summary>
    /// <param name="packageName">The package name.</param>
    /// <param name="packageVersion">The package version.</param>
    /// <param name="apiKey">The API key.</param>
    /// <param name="source">The source.</param>
    /// <param name="noServiceEndpoint">The no service endpoint.</param>
    /// <param name="forceEnglishOutput">The force english output.</param>
    /// <param name="interactive">The interactive.</param>
    /// <param name="nonInteractive">The non interactive.</param>
    /// <param name="log">The log.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
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