using Soenneker.Extensions.String;
using Soenneker.Utils.PooledStringBuilders;

namespace Soenneker.Utils.Dotnet.NuGet.Utils;

internal static class ArgumentUtil
{
    internal static string Push(
        string packagePath,
        string? apiKey = null,
        string? source = null,
        bool? disableBuffering = null,
        bool? noSymbols = null,
        bool? noServiceEndpoint = null,
        bool? skipDuplicate = null,
        int? timeout = null,
        string? symbolSource = null,
        string? symbolApiKey = null,
        string? verbosity = null)
    {
        using var psb = new PooledStringBuilder();

        psb.Append('"');
        psb.Append(packagePath);
        psb.Append('"');

        if (!apiKey.IsNullOrEmpty())
        {
            psb.Append(" --api-key ");
            psb.Append(apiKey);
        }

        if (!source.IsNullOrEmpty())
        {
            psb.Append(" --source ");
            psb.Append(source);
        }

        if (disableBuffering == true)
            psb.Append(" --disable-buffering");

        if (noSymbols == true)
            psb.Append(" --no-symbols");

        if (noServiceEndpoint == true)
            psb.Append(" --no-service-endpoint");

        if (skipDuplicate == true)
            psb.Append(" --skip-duplicate");

        if (timeout.HasValue)
        {
            psb.Append(" --timeout ");
            psb.Append(timeout.Value);
        }

        if (!symbolSource.IsNullOrEmpty())
        {
            psb.Append(" --symbol-source ");
            psb.Append(symbolSource);
        }

        if (!symbolApiKey.IsNullOrEmpty())
        {
            psb.Append(" --symbol-api-key ");
            psb.Append(symbolApiKey);
        }

        if (!verbosity.IsNullOrEmpty())
        {
            psb.Append(" --verbosity ");
            psb.Append(verbosity);
        }

        return psb.ToString();
    }

    internal static string Delete(
        string packageName,
        string packageVersion,
        string? apiKey = null,
        string? source = null,
        bool? noServiceEndpoint = null,
        bool forceEnglishOutput = true,
        bool interactive = false,
        bool nonInteractive = true)
    {
        using var psb = new PooledStringBuilder();

        psb.Append('"');
        psb.Append(packageName);
        psb.Append("\" \"");
        psb.Append(packageVersion);
        psb.Append('"');

        if (!apiKey.IsNullOrEmpty())
        {
            psb.Append(" --api-key ");
            psb.Append(apiKey);
        }

        if (!source.IsNullOrEmpty())
        {
            psb.Append(" --source ");
            psb.Append(source);
        }

        if (noServiceEndpoint == true)
            psb.Append(" --no-service-endpoint");

        if (forceEnglishOutput)
            psb.Append(" --force-english-output");

        if (interactive)
            psb.Append(" --interactive");

        if (nonInteractive)
            psb.Append(" --non-interactive");

        return psb.ToString();
    }
}
