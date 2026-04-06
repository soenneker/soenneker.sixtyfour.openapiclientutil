using Soenneker.Sixtyfour.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Sixtyfour.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class SixtyfourOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly ISixtyfourOpenApiClientUtil _openapiclientutil;

    public SixtyfourOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<ISixtyfourOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
