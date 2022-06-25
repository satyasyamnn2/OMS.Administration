using Microsoft.AspNetCore.Mvc;
using OMS.Administration.Domain.Entities;
using OMS.Administration.Infrasturcture.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMS.Administration.Api.Controllers
{
    [Route("api/v1/Organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpPost]
        public async Task SaveOrganization([FromBody] Organization organization)
        {
            await _organizationService.SaveOrganizationAsync(organization);
        }
    }
}
