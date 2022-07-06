using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using OMS.Administration.Api.Caching;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Administration.Api.ActionFilters
{
    public class CachedAttribute : Attribute, IAsyncActionFilter
    {
        private int _timeToLiveSeconds;
        public CachedAttribute(int timeToLiveSeconds)
        {
            _timeToLiveSeconds = timeToLiveSeconds;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheSettings = context.HttpContext.RequestServices.GetRequiredService<RedisCacheSettings>();
            if (!cacheSettings.Enabled)
            {
                await next();
                return;
            }
            string key = GenerateCacheKey(context.HttpContext.Request);
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
            var cacheResponse = await cacheService.GetCacheKeyAsync(key);
            if (!string.IsNullOrEmpty(cacheResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = cacheResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }
            var executedContext = await next();
            if (executedContext.Result is OkObjectResult)
            {
                OkObjectResult result = executedContext.Result as OkObjectResult;
                await cacheService.CacheResponseAsync(key, result.Value, TimeSpan.FromSeconds(_timeToLiveSeconds));
            }
        }

        private string GenerateCacheKey(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{request.Path}");
            foreach(var (key, value) in request.Query.OrderBy(o => o.Key))
            {
                keyBuilder.Append($"|{key}|{value}");
            }
            return keyBuilder.ToString();
        }
    }
}
