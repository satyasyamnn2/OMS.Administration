using Microsoft.EntityFrameworkCore;
using OMS.Administration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OMS.Administration.Infrasturcture.Persistence.DataSeed
{
    public class AdministrationDbContextInitializer
    {
        public void SeedData(AdministrationDbContext dbContext)
        {
            using (dbContext)
            {
                SeedDataAsync(dbContext);
            }
        }

        private void SeedDataAsync(AdministrationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            int totalCount = dbContext.Organizations.Count();
            if (totalCount == 0)
            {
                IList<Organization> lists = new List<Organization>();
                for (int j = 0; j < 10; j++)
                {
                    string guid = Guid.NewGuid().ToString();
                    Random generator = new Random();
                    Organization org = new Organization
                    {
                        Id = guid,
                        Name = "Organization " + guid,
                        Email = guid + "@s.com",
                        Currency = "INR",
                        TaxIdenfier = "TaxId" + guid,
                        TurnOver = generator.Next(0, 1000000),
                        YearOfEstablishment = 1994,
                        OfficeAddress = new Address
                        {
                            City = "Bangalore",
                            Country = "India",
                            State = "Karnataka",
                            Street = "Street 1",
                            ZipCode = 99999
                        }
                    };
                    bool isOwner = true;
                    for (int i = 0; i < 10; i++)
                    {
                        string contactGuid = Guid.NewGuid().ToString();
                        org.Contacts.Add(new Contact
                        {
                            Id = contactGuid,
                            Name = "Contact " + contactGuid,
                            Email = guid + "@c.com",
                            OrganizationId = guid,
                            ContactAddress = new Address
                            {
                                City = "Bangalore",
                                Country = "India",
                                State = "Karnataka",
                                Street = "Street 1",
                                ZipCode = 99999
                            },
                            PhoneNumber = "99999999",
                            IsOwner = isOwner
                        });
                        isOwner = false;
                    }
                    lists.Add(org);                    
                }
                dbContext.Organizations.AddRange(lists);
                dbContext.SaveChanges();
            }
        }
    }
}
