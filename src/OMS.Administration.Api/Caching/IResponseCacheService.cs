using System;
using System.Threading.Tasks;

namespace OMS.Administration.Api.Caching
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeSpan);
        Task<string> GetCacheKeyAsync(string cacheKey);
    }
}
