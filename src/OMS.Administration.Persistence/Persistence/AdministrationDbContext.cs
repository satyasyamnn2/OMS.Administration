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
        public AdministrationDbContext(DbContextOptions<AdministrationDbContext> options) : base(options) { }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new AuditableEntitySaveChangesInterceptor());
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
