using Microsoft.Extensions.Logging;
using OMS.Administration.Domain.Entities;
using OMS.Administration.Infrasturcture.Services.Contracts;
using OMS.DataAccess.Shared;
using System.Threading.Tasks;

namespace OMS.Administration.Infrasturcture.Services
{
    public class OrganizationService : IOrganizationService
    {
        private ILogger<OrganizationService> _logger;
        private IRepository<Organization> _organizationRepository;
        public OrganizationService(ILogger<OrganizationService> logger, IRepository<Organization> organizationRepository)
        {
            _logger = logger;
            _organizationRepository = organizationRepository;
        }
        public async Task SaveOrganizationAsync(Organization organization)
        {
            _logger.LogInformation("Saving organization");
            await _organizationRepository.InsertOneAsync(organization);
        }
    }
}
