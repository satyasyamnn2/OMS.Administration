using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OMS.Administration.Api.Caching
{
    public static class RedisCacheExtensions
    {
        public static void AddRedisCacheExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheSettings = new RedisCacheSettings();
            configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);
            if (!redisCacheSettings.Enabled) return;

            services.AddStackExchangeRedisCache(options => {
                options.Configuration = redisCacheSettings.ConnectionString;
            });
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}
