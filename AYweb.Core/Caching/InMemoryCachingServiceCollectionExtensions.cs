using Microsoft.Extensions.DependencyInjection;

namespace AYweb.Core.Caching;

public static class InMemoryCachingServiceCollectionExtensions
{
    public static IServiceCollection AddZaminInMemoryCaching(this IServiceCollection services)
        => services.AddMemoryCache().AddTransient<ICacheAdapter, InMemoryCacheAdapter>();
}