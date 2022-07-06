using Microsoft.AspNetCore.Mvc;
using OMS.Administration.Api.ActionFilters;
using OMS.Administration.Domain.Entities;
using OMS.Administration.Domain.Specifications.OrganizationSpec;
using OMS.DataAccess.Shared.Contracts;
using OMS.DataAccess.Shared.Specification;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMS.Administration.Api.Controllers
{
    [Route("api/v1/Organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private IGenericService<Organization, IGenericRepository<Organization>> _organizationService;
        public OrganizationController(IGenericService<Organization, IGenericRepository<Organization>> organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        [Cached(600)]
        public async Task<IActionResult> GetAll()
        {
            IReadOnlyList<Organization> data = await _organizationService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet]
        [Cached(600)]
        [Route("{organizationId}")]
        public async Task<IActionResult> GetAll(string organizationId)
        {
            Organization data = await _organizationService.GetByIdAsync(organizationId);
            return Ok(data);
        }

        [HttpGet]
        [Route("{parentOrganizationId}/Branches")]
        public async Task<IActionResult> GetBranches(string parentOrganizationId)
        {
            Specification<Organization> spec = new GetBranchesSpecification(parentOrganizationId);
            IReadOnlyList<object> data = await _organizationService.Search(spec, o => o);
            return Ok(data);
        }

        [HttpGet]
        [Route("{organizationId}/Contacts")]
        public async Task<IActionResult> GetContacts(string organizationId)
        {
            Specification<Organization> spec = new GetContactsOfOrganizationSpecification(organizationId);            
            IReadOnlyList<object> data = await _organizationService.Search(spec, o => o.Contacts);
            return Ok(data);
        }

        [HttpPost]
        public async Task SaveOrganization([FromBody] Organization organization)
        {
            OrganizationShouldHaveAtleastOneOwnerSpecification specification = new OrganizationShouldHaveAtleastOneOwnerSpecification();
            if (specification.IsSatisfiedBy(organization))
                await _organizationService.SaveEntityAsync(organization);
            else
                throw new ArgumentException("Organization data passed is invalid.");
        }

    }
}
