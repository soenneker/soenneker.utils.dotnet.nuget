using System.Threading;
using System.Threading.Tasks;
using Soenneker.Extensions.ValueTask;
using Soenneker.Utils.Dotnet.Abstract;
using Soenneker.Utils.Dotnet.NuGet.Abstract;
using Soenneker.Utils.Dotnet.NuGet.Utils;

namespace Soenneker.Utils.Dotnet.NuGet;

/// <inheritdoc cref="IDotnetNuGetUtil"/>
public sealed class DotnetNuGetUtil : IDotnetNuGetUtil
{
    private readonly IDotnetUtil _dotnetUtil;

    public DotnetNuGetUtil(IDotnetUtil dotnetUtil)
    {
        _dotnetUtil = dotnetUtil;
    }

    public async ValueTask<bool> Push(string packagePath, string? apiKey = null, string? source = "https://api.nuget.org/v3/index.json",
        bool? disableBuffering = null, bool? noSymbols = null, bool? noServiceEndpoint = null, bool? skipDuplicate = null, int? timeout = null,
        string? symbolSource = null, string? symbolApiKey = null, string? verbosity = null, bool log = true, CancellationToken cancellationToken = default)
    {
        try
        {
            string arguments = "nuget push " + ArgumentUtil.Push(packagePath, apiKey, source, disableBuffering, noSymbols, noServiceEndpoint,
                skipDuplicate, timeout, symbolSource, symbolApiKey, verbosity);

            await _dotnetUtil.Execute(arguments, cancellationToken)
                             .NoSync();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async ValueTask<bool> Delete(string packageName, string packageVersion, string? apiKey = null, string? source = "https://api.nuget.org/v3/index.json",
        bool? noServiceEndpoint = null, bool forceEnglishOutput = true, bool interactive = false, bool nonInteractive = true, bool log = true,
        CancellationToken cancellationToken = default)
    {
        try
        {
            string arguments = "nuget delete " + ArgumentUtil.Delete(packageName, packageVersion, apiKey, source, noServiceEndpoint,
                forceEnglishOutput, interactive, nonInteractive);

            await _dotnetUtil.Execute(arguments, cancellationToken)
                             .NoSync();

            return true;
        }
        catch
        {
            return false;
        }
    }
}