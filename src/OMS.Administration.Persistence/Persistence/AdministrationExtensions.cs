using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OMS.Administration.Domain.Entities;
using OMS.Administration.Infrasturcture.Persistence;
using OMS.Administration.Infrasturcture.Persistence.DataSeed;
using OMS.Administration.Infrasturcture.Persistence.Interceptors;
using OMS.DataAccess.Shared;
using OMS.DataAccess.Shared.Contracts;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AdministrationExtensions
    {
        private const string MigrationAssemblyName = "OMS.Administration.Migrations";
        public static void AddAdministrationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("DefaultConnection");
            bool enableDetailedErrors = bool.Parse(configuration.GetValue<string>("EnableDetailedErrors"));
            bool enableSensitiveDataLogging = bool.Parse(configuration.GetValue<string>("EnableSensitiveDataLogging"));
            services.AddEntityFrameworkNpgsql().AddDbContext<AdministrationDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseNpgsql(connectionString, x => x.MigrationsAssembly(MigrationAssemblyName));
                options.EnableDetailedErrors(enableDetailedErrors);
                options.EnableSensitiveDataLogging(enableSensitiveDataLogging);
            });
            services.AddTransient<AdministrationDbContextInitializer>();
            services.AddTransient<IAdministrationDbContext, AdministrationDbContext>();

            services.AddTransient<IGenericRepository<Organization>, GenericRepository<AdministrationDbContext, Organization>>();
            services.AddTransient<IGenericService<Organization, IGenericRepository<Organization>>, GenericService<Organization, IGenericRepository<Organization>>>();

            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        }
    }
}
