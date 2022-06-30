using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OMS.DataAccess.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OMS.Administration.Infrasturcture.Persistence.Interceptors
{
    public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
    {   
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateAuditableFields(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateAuditableFields(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateAuditableFields(DbContext context)
        {
            if (context == null) return;
            IEnumerable<EntityEntry<AuditableEntityBase>> entriesToUpdate = context.ChangeTracker.Entries<AuditableEntityBase>();
            foreach(EntityEntry<AuditableEntityBase> entry in entriesToUpdate)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = "Dummy";
                    entry.Entity.CreatedOn = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedBy = "Dummy";
                    entry.Entity.ModifiedOn = DateTime.Now;
                }
            }                
        }
    }
}
