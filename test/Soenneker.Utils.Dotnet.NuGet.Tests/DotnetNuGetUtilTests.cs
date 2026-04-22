using Soenneker.Utils.Dotnet.NuGet.Abstract;
using Soenneker.Tests.HostedUnit;


namespace Soenneker.Utils.Dotnet.NuGet.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class DotnetNuGetUtilTests : HostedUnitTest
{
    private readonly IDotnetNuGetUtil _util;

    public DotnetNuGetUtilTests(Host host) : base(host)
    {
        _util = Resolve<IDotnetNuGetUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
