using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMS.Administration.Api.Infrastructure.Persistence;
using OMS.Administration.Domain.Entities;

namespace OMS.Administration.Infrasturcture.Persistence.Configurations
{
    public class ContactConfiguration : AuditableModelConfigurationBase<Contact>
    {
        protected override void SetKeyFields(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(contact => contact.Id);
        }
        protected override void SetRequiredFields(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(contact => contact.Name).IsRequired();
            builder.Property(contact => contact.Email).IsRequired();
        }
        protected override void SetLengthFields(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(contact => contact.Id).HasMaxLength(ColumnTypes.Text50.Length);
            builder.Property(contact => contact.Name).HasMaxLength(ColumnTypes.Text100.Length);
            builder.Property(contact => contact.Email).HasMaxLength(ColumnTypes.Text50.Length);
        }

        protected override void SetAdditionalInformation(EntityTypeBuilder<Contact> builder)
        {
            builder.OwnsOne(org => org.ContactAddress).Property(e => e.Street).HasColumnName("StreetName").IsRequired().HasMaxLength(ColumnTypes.Text50.Length);
            builder.OwnsOne(org => org.ContactAddress).Property(e => e.City).HasColumnName("City").IsRequired().HasMaxLength(ColumnTypes.Text20.Length);
            builder.OwnsOne(org => org.ContactAddress).Property(e => e.State).HasColumnName("State").IsRequired().HasMaxLength(ColumnTypes.Text50.Length);
            builder.OwnsOne(org => org.ContactAddress).Property(e => e.Country).HasColumnName("Country").IsRequired().HasMaxLength(ColumnTypes.Text20.Length);
            builder.OwnsOne(org => org.ContactAddress).Property(e => e.ZipCode).HasColumnName("ZipCode").IsRequired();
        }
    }
}
