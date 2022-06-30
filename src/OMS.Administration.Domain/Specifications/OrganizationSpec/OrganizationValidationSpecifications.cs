using OMS.Administration.Domain.Entities;
using OMS.DataAccess.Shared.Specification;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace OMS.Administration.Domain.Specifications.OrganizationSpec
{
    public class OrganizationShouldHaveAtleastOneOwnerSpecification : Specification<Organization>
    {
        public override Expression<Func<Organization, bool>> ToExpression()
        {
            return org => org.Contacts.Where(contact => contact.IsOwner == true).Count() > 0;
        }
    }
}
