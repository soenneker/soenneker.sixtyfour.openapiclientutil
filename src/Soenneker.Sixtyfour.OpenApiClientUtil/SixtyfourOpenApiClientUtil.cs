using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Sixtyfour.HttpClients.Abstract;
using Soenneker.Sixtyfour.OpenApiClientUtil.Abstract;
using Soenneker.Sixtyfour.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Sixtyfour.OpenApiClientUtil;

public sealed class SixtyfourOpenApiClientUtil : ISixtyfourOpenApiClientUtil
{
    private readonly AsyncSingleton<SixtyfourOpenApiClient> _client;

    public SixtyfourOpenApiClientUtil(ISixtyfourOpenApiHttpClient httpClientUtil, IConfiguration _)
    {
        _client = new AsyncSingleton<SixtyfourOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
            {
                BaseUrl = httpClient.BaseAddress!.ToString().TrimEnd('/')
            };

            return new SixtyfourOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<SixtyfourOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
