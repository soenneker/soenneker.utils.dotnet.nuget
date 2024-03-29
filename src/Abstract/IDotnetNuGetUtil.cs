using System.Threading.Tasks;

namespace Soenneker.Utils.Dotnet.NuGet.Abstract;

/// <summary>
/// A utility library for dotnet NuGet operations
/// </summary>
public interface IDotnetNuGetUtil
{
    ValueTask Push(string path, string apiKey, bool log = true, string source = "https://api.nuget.org/v3/index.json");

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arguments"></param>
    /// <param name="path">Full path of the .nupkg file</param>
    /// <param name="apiKey">NuGet server API key</param>
    /// <param name="log"></param>
    /// <param name="source">Defaults to https://api.nuget.org/v3/index.json</param>
    /// <returns></returns>
    ValueTask Execute(string arguments, string path, string apiKey, bool log = true, string source = "https://api.nuget.org/v3/index.json");
}
