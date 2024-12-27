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
        string argument = ArgumentUtil.Push(
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
                if (output.Contains("Your package was pushed."))
                    return true;

                return false;
            },
            null,
            log,
            cancellationToken
        );
    }

    public ValueTask<bool> Delete(string packageName,
        string packageVersion,
        string? apiKey = null,
        string? source = "https://api.nuget.org/v3/index.json",
        bool? noServiceEndpoint = null,
        bool forceEnglishOutput = true,
        bool interactive = false,
        bool nonInteractive = true,
        bool log = true, CancellationToken cancellationToken = default)
    {
        // Construct the arguments for the "dotnet nuget delete" command.
        string argument = ArgumentUtil.Delete(
            packageName,
            packageVersion,
            apiKey,
            source,
            noServiceEndpoint,
            forceEnglishOutput,
            interactive,
            nonInteractive);

        // Execute the command and parse the output to determine success.
        return _dotnetUtil.ExecuteCommand(
            "nuget delete",
            packageName,
            path => argument, output => { return true; },
            null,
            log,
            cancellationToken
        );
    }
}