using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Utils.Dotnet.NuGet.Abstract;

/// <summary>
/// A utility library for dotnet NuGet operations
/// </summary>
public interface IDotnetNuGetUtil
{
    ValueTask<bool> Push(string packagePath,
        string? source = "https://api.nuget.org/v3/index.json",
        string? apiKey = null,
        bool? disableBuffering = null,
        bool? noSymbols = null,
        bool? noServiceEndpoint = null,
        bool? skipDuplicate = null,
        int? timeout = null,
        string? symbolSource = null,
        string? symbolApiKey = null,
        string? verbosity = null,
        bool log = true, CancellationToken cancellationToken = default);
}
