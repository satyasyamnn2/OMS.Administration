using Microsoft.EntityFrameworkCore;
using OMS.Administration.Domain.Entities;
using OMS.Administration.Infrasturcture.Persistence.Interceptors;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace OMS.Administration.Infrasturcture.Persistence
{
    public class AdministrationDbContext : DbContext, IAdministrationDbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _interceptor;
        public AdministrationDbContext(DbContextOptions<AdministrationDbContext> options, AuditableEntitySaveChangesInterceptor interceptor) : base(options) 
        {
            _interceptor = interceptor;
        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
