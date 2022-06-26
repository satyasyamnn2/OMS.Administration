using Microsoft.AspNetCore.Mvc;
using OMS.Administration.Domain.Entities;
using OMS.DataAccess.Shared.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMS.Administration.Api.Controllers
{
    [Route("api/v1/Organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private IGenericService<Organization, IRepository<Organization>> _organizationService;
        public OrganizationController(IGenericService<Organization, IRepository<Organization>> organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpPost]
        public async Task SaveOrganization([FromBody] Organization organization)
        {
            await _organizationService.SaveEntityAsync(organization);
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<object> data = _organizationService.Repository.Get(null, null, string.Empty, x => new
            {
                OrganizationName = x.Name,
                Tax = x.TaxIdenfier
            });
            return Ok(data);
        }
    }
}
