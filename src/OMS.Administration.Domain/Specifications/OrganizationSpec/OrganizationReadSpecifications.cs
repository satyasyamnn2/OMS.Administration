using OMS.Administration.Domain.Entities;
using OMS.DataAccess.Shared.Specification;
using System;
using System.Linq.Expressions;

namespace OMS.Administration.Domain.Specifications.OrganizationSpec
{
    public class GetBranchesSpecification : Specification<Organization>
    {
        private readonly string _parentOrganizationId;
        public GetBranchesSpecification(string parentOrganizationId)
        {
            _parentOrganizationId = parentOrganizationId;
        }

        public override Expression<Func<Organization, bool>> ToExpression()
        {
            return o => o.ParentOrganizationId == _parentOrganizationId && !string.IsNullOrEmpty(o.ParentOrganizationId);
        }
    }

    public class GetContactsOfOrganizationSpecification : Specification<Organization>
    {
        private string _organizationId;
        public GetContactsOfOrganizationSpecification(string organizationId)
        {
            _organizationId = organizationId;
        }

        public override Expression<Func<Organization, bool>> ToExpression()
        {
            return org => org.Id == _organizationId;
        }
    }
}
