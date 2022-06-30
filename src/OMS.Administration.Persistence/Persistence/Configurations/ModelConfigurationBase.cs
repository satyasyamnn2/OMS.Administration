using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMS.DataAccess.Shared.Models;

namespace OMS.Administration.Infrasturcture.Persistence.Configurations
{
    public abstract class ModelConfigurationBase<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            SetAuditableFields(builder);
            SetKeyFields(builder);
            SetRequiredFields(builder);
            SetLengthFields(builder);
            SetAdditionalInformation(builder);
        }
        protected abstract void SetAuditableFields(EntityTypeBuilder<T> builder);
        protected abstract void SetKeyFields(EntityTypeBuilder<T> builder);
        protected abstract void SetRequiredFields(EntityTypeBuilder<T> builder);
        protected abstract void SetLengthFields(EntityTypeBuilder<T> builder);
        protected abstract void SetAdditionalInformation(EntityTypeBuilder<T> builder);
    }

    public abstract class AuditableModelConfigurationBase<T> : ModelConfigurationBase<T> where T : AuditableEntityBase
    {
        protected override void SetAuditableFields(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.CreatedOn).HasComment("Stores Created on data");
            builder.Property(e => e.CreatedBy).HasComment("Stores Created by data");
            builder.Property(e => e.ModifiedOn).HasComment("Stores Modified on data");
            builder.Property(e => e.ModifiedBy).HasComment("Stores Modified by data");
        }
    }
}
