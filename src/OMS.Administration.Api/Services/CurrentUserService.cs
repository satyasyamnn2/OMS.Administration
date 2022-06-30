using Microsoft.AspNetCore.Http;
using OMS.Administration.Api.Services;
using OMS.Administration.Infrasturcture;

namespace OMS.Administration.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private const string DefaultUser = "Default";

        private readonly IHttpContextAccessor _contextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public string CurrentUserId 
        {
            get
            {
                if (_contextAccessor.HttpContext != null && _contextAccessor.HttpContext.User != null)
                    return _contextAccessor.HttpContext.User.Identity.Name;
                return DefaultUser;
            }
        }
    }
}

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CurrentUserServiceExtensions
    {
        public static void AddCurrentUserService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
        }
    }
}
