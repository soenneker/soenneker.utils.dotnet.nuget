using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.ValueTask;
using Soenneker.Utils.Dotnet.NuGet.Abstract;
using Soenneker.Utils.Process.Abstract;

namespace Soenneker.Utils.Dotnet.NuGet;

/// <inheritdoc cref="IDotnetNuGetUtil"/>
public class DotnetNuGetUtil : IDotnetNuGetUtil
{
    private readonly ILogger<DotnetNuGetUtil> _logger;
    private readonly IProcessUtil _processUtil;

    public DotnetNuGetUtil(ILogger<DotnetNuGetUtil> logger, IProcessUtil processUtil)
    {
        _logger = logger;
        _processUtil = processUtil;
    }

    public async ValueTask Push(string path, string apiKey, bool log = true, string source = "https://api.nuget.org/v3/index.json")
    {
        string arguments = CreatePushArgument(path, apiKey, source);

        if (log)
            _logger.LogInformation("Executing: dotnet {arguments} ...", arguments);

        List<string> _ = await _processUtil.StartProcess("dotnet", null, arguments, true, true, log).NoSync();
    }

    private static string CreatePushArgument(string path, string apiKey, string source)
    {
        return $"nuget push \"{path}\" -s {source} -k {apiKey}";
    }
}