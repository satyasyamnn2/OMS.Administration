using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace OMS.Administration.Api.Caching
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache;

        public ResponseCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeSpan)
        {
            if (response == null) return;
            string content = JsonConvert.SerializeObject(response);
            await _distributedCache.SetStringAsync(cacheKey, content, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeSpan
            });
        }

        public async Task<string> GetCacheKeyAsync(string cacheKey)
        {
            return await _distributedCache.GetStringAsync(cacheKey);
        }
    }
}
