﻿using OMS.DataAccess.Shared;

namespace OMS.Administration.Domain.Entities
{
    public class Contact: EntityBase
    {   
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsOwner { get; set; }
        public string OrganizationId { get; set; }
        public Address ContactAddress { get; set; }
        public Organization Organization { get; set; }
    }
}
