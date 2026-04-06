using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Sixtyfour.HttpClients.Abstract;
using Soenneker.Sixtyfour.OpenApiClientUtil.Abstract;
using Soenneker.Sixtyfour.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Sixtyfour.OpenApiClientUtil;

///<inheritdoc cref="ISixtyfourOpenApiClientUtil"/>
public sealed class SixtyfourOpenApiClientUtil : ISixtyfourOpenApiClientUtil
{
    private readonly AsyncSingleton<SixtyfourOpenApiClient> _client;

    public SixtyfourOpenApiClientUtil(ISixtyfourOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<SixtyfourOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Sixtyfour:ApiKey");
            string authHeaderValueTemplate = configuration["Sixtyfour:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
