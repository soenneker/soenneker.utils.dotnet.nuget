using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Utils.Dotnet.NuGet.Abstract;
using Soenneker.Utils.Dotnet.Registrars;

namespace Soenneker.Utils.Dotnet.NuGet.Registrars;

/// <summary>
/// A utility library for dotnet NuGet operations
/// </summary>
public static class DotnetNuGetUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IDotnetNuGetUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddDotnetNuGetUtilAsSingleton(this IServiceCollection services)
    {
        services.AddDotnetUtilAsSingleton();
        services.TryAddSingleton<IDotnetNuGetUtil, DotnetNuGetUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IDotnetNuGetUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddDotnetNuGetUtilAsScoped(this IServiceCollection services)
    {
        services.AddDotnetUtilAsScoped();
        services.TryAddScoped<IDotnetNuGetUtil, DotnetNuGetUtil>();

        return services;
    }
}
