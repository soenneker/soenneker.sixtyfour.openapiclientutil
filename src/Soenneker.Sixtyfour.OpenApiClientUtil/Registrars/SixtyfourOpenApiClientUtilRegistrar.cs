using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Sixtyfour.HttpClients.Registrars;
using Soenneker.Sixtyfour.OpenApiClientUtil.Abstract;

namespace Soenneker.Sixtyfour.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the lazily initialized Sixtyfour API client.
/// </summary>
public static class SixtyfourOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the Sixtyfour API client utility as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddSixtyfourOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddSixtyfourOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ISixtyfourOpenApiClientUtil, SixtyfourOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Sixtyfour API client utility as a scoped service backed by the singleton HTTP client provider. <para/>
    /// </summary>
    public static IServiceCollection AddSixtyfourOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddSixtyfourOpenApiHttpClientAsSingleton()
                .TryAddScoped<ISixtyfourOpenApiClientUtil, SixtyfourOpenApiClientUtil>();

        return services;
    }
}
