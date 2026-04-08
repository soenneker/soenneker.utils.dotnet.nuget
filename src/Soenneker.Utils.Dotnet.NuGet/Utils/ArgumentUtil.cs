using Soenneker.Extensions.String;
using Soenneker.Utils.PooledStringBuilders;
using System;

namespace Soenneker.Utils.Dotnet.NuGet.Utils;

internal static class ArgumentUtil
{
    internal static string Push(string packagePath, string? apiKey = null, string? source = null, bool? disableBuffering = null, bool? noSymbols = null,
        bool? noServiceEndpoint = null, bool? skipDuplicate = null, int? timeout = null, string? symbolSource = null, string? symbolApiKey = null,
        string? verbosity = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(packagePath);

        using var psb = new PooledStringBuilder();

        psb.Append('"');
        psb.Append(packagePath);
        psb.Append('"');

        if (apiKey.HasContent())
        {
            psb.Append(" --api-key \"");
            psb.Append(apiKey);
            psb.Append('"');
        }

        if (source.HasContent())
        {
            psb.Append(" --source \"");
            psb.Append(source);
            psb.Append('"');
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

        if (symbolSource.HasContent())
        {
            psb.Append(" --symbol-source \"");
            psb.Append(symbolSource);
            psb.Append('"');
        }

        if (symbolApiKey.HasContent())
        {
            psb.Append(" --symbol-api-key \"");
            psb.Append(symbolApiKey);
            psb.Append('"');
        }

        if (verbosity.HasContent())
        {
            psb.Append(" --verbosity ");
            psb.Append(verbosity);
        }

        return psb.ToString();
    }

    internal static string Delete(string packageName, string packageVersion, string? apiKey = null, string? source = null, bool? noServiceEndpoint = null,
        bool forceEnglishOutput = true, bool interactive = false, bool nonInteractive = true)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(packageName);
        ArgumentException.ThrowIfNullOrWhiteSpace(packageVersion);

        if (interactive && nonInteractive)
            throw new ArgumentException("interactive and nonInteractive cannot both be true.");

        using var psb = new PooledStringBuilder();

        psb.Append('"');
        psb.Append(packageName);
        psb.Append('"');
        psb.Append(' ');
        psb.Append('"');
        psb.Append(packageVersion);
        psb.Append('"');

        if (apiKey.HasContent())
        {
            psb.Append(" --api-key \"");
            psb.Append(apiKey);
            psb.Append('"');
        }

        if (source.HasContent())
        {
            psb.Append(" --source \"");
            psb.Append(source);
            psb.Append('"');
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