using Soenneker.Sixtyfour.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Sixtyfour.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ISixtyfourOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<SixtyfourOpenApiClient> Get(CancellationToken cancellationToken = default);
}
