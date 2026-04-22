using Soenneker.Sixtyfour.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Sixtyfour.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SixtyfourOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ISixtyfourOpenApiClientUtil _openapiclientutil;

    public SixtyfourOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ISixtyfourOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
