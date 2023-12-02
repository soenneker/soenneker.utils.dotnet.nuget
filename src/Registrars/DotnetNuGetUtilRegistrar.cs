using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Utils.Dotnet.NuGet.Abstract;
using Soenneker.Utils.Process.Registrars;

namespace Soenneker.Utils.Dotnet.NuGet.Registrars;

/// <summary>
/// A utility library for dotnet NuGet operations
/// </summary>
public static class DotnetNuGetUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IDotnetNuGetUtil"/> as a singleton service. <para/>
    /// </summary>
    public static void AddDotnetNuGetUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IDotnetNuGetUtil, DotnetNuGetUtil>();
        services.AddProcessUtilAsSingleton();
    }

    /// <summary>
    /// Adds <see cref="IDotnetNuGetUtil"/> as a scoped service. <para/>
    /// </summary>
    public static void AddDotnetNuGetUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IDotnetNuGetUtil, DotnetNuGetUtil>();
        services.AddProcessUtilAsScoped();
    }
}
