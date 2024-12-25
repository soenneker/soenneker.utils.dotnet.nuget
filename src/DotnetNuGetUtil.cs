using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Utils.Dotnet.Abstract;
using Soenneker.Utils.Dotnet.NuGet.Abstract;
using Soenneker.Utils.Dotnet.NuGet.Utils;

namespace Soenneker.Utils.Dotnet.NuGet;

/// <inheritdoc cref="IDotnetNuGetUtil"/>
public class DotnetNuGetUtil : IDotnetNuGetUtil
{
    private readonly ILogger<DotnetNuGetUtil> _logger;
    private readonly IDotnetUtil _dotnetUtil;

    public DotnetNuGetUtil(ILogger<DotnetNuGetUtil> logger, IDotnetUtil dotnetUtil)
    {
        _logger = logger;
        _dotnetUtil = dotnetUtil;
    }

    public ValueTask<bool> Push(string packagePath,
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
        bool log = true, CancellationToken cancellationToken = default)
    {
        string argument = ArgumentUtil.NuGetPush(
            packagePath,
            apiKey,
            source,
            disableBuffering,
            noSymbols,
            noServiceEndpoint,
            skipDuplicate,
            timeout,
            symbolSource,
            symbolApiKey,
            verbosity);

        return _dotnetUtil.ExecuteCommand(
            "nuget push",
            packagePath,
            path => argument, output =>
            {
                // Check for success indicators in the output
                return true;
            },
            null,
        log,
            cancellationToken
        );
    }
}