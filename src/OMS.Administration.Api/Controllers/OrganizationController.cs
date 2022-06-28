using Microsoft.AspNetCore.Mvc;
using OMS.Administration.Domain.Entities;
using OMS.Administration.Domain.Specifications;
using OMS.DataAccess.Shared.Contracts;
using OMS.DataAccess.Shared.Specification;
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

        [HttpPost]
        public async Task SaveOrganization([FromBody] Organization organization)
        {
            await _organizationService.SaveEntityAsync(organization);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Organization> data = await _organizationService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("{parentOrganizationId}/Branches")]
        public async Task<IActionResult> GetBranches(string parentOrganizationId)
        {
            Specification<Organization> spec = new GetBranchesSpecification(parentOrganizationId);            
            IReadOnlyList<object> data = await _organizationService.Search(spec, o => new {
                o.Name,
                o.TaxIdenfier,
                o.Email,
            });
            return Ok(data);
        }
    }
}
