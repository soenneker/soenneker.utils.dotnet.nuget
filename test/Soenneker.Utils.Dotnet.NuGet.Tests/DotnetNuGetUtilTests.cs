using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Utils.Dotnet.NuGet.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Utils.Dotnet.NuGet.Tests;

[Collection("Collection")]
public class DotnetNuGetUtilTests : FixturedUnitTest
{
    private readonly IDotnetNuGetUtil _util;

    public DotnetNuGetUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IDotnetNuGetUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
