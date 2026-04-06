using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Sixtyfour.HttpClients.Registrars;
using Soenneker.Sixtyfour.OpenApiClientUtil.Abstract;

namespace Soenneker.Sixtyfour.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class SixtyfourOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="SixtyfourOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddSixtyfourOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddSixtyfourOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ISixtyfourOpenApiClientUtil, SixtyfourOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="SixtyfourOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddSixtyfourOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddSixtyfourOpenApiHttpClientAsSingleton()
                .TryAddScoped<ISixtyfourOpenApiClientUtil, SixtyfourOpenApiClientUtil>();

        return services;
    }
}
