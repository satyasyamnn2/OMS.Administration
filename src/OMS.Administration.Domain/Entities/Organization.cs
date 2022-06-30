using OMS.DataAccess.Shared.Models;
using System.Collections.Generic;

namespace OMS.Administration.Domain.Entities
{
    public class Organization : AuditableEntityBase
    {   
        public string Name { get; set; }
        public string Email { get; set; }
        public string TaxIdenfier { get; set; }
        public Address OfficeAddress { get; set; }
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public string ParentOrganizationId { get; set; }
        public Organization ParentOrganization { get; set; }
        public double TurnOver { get; set; }
        public string Currency { get; set; }
        public int YearOfEstablishment { get; set; }
    }
}
