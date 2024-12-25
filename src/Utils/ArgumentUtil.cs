using Soenneker.Extensions.String;

namespace Soenneker.Utils.Dotnet.NuGet.Utils;

internal class ArgumentUtil
{
    internal static string NuGetPush(
        string packagePath,
        string? source = null,
        string? apiKey = null,
        bool? disableBuffering = null,
        bool? noSymbols = null,
        bool? noServiceEndpoint = null,
        bool? skipDuplicate = null,
        int? timeout = null,
        string? symbolSource = null,
        string? symbolApiKey = null,
        string? verbosity = null)
    {
        var arguments = $"\"{packagePath}\"";

        if (!source.IsNullOrEmpty())
            arguments += $" --source {source}";

        if (!apiKey.IsNullOrEmpty())
            arguments += $" --api-key {apiKey}";

        if (disableBuffering == true)
            arguments += " --disable-buffering";

        if (noSymbols == true)
            arguments += " --no-symbols";

        if (noServiceEndpoint == true)
            arguments += " --no-service-endpoint";

        if (skipDuplicate == true)
            arguments += " --skip-duplicate";

        if (timeout.HasValue)
            arguments += $" --timeout {timeout.Value}";

        if (!symbolSource.IsNullOrEmpty())
            arguments += $" --symbol-source {symbolSource}";

        if (!symbolApiKey.IsNullOrEmpty())
            arguments += $" --symbol-api-key {symbolApiKey}";

        if (!verbosity.IsNullOrEmpty())
            arguments += $" --verbosity {verbosity}";

        return arguments;
    }

}