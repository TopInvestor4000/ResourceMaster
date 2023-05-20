using Mapster;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.ResourceProject;
using ResourceMaster.DAL.Repositories.ResourceRepository;
using ResourceMaster.Services.CustomerService;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Services.CustomerService
{
    public class AvailabilityService
    {
        private readonly IResourceProjectRepository _repository;
        private readonly ILogger<AvailabilityService> _logger;

        public AvailabilityService(IResourceProjectRepository repository, ILogger<AvailabilityService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<AvailabilityViewModel>> GetAvailability(int id, DateTime? from, DateTime? to)
        {
            _logger.LogInformation("GetAllAsync Method called");
            var availabilityList =  await _repository.GetAvailability(id, from, to);
            filterTheAvailablePeriod();
            var resultList = availabilityList.Adapt<List<AvailabilityViewModel>>();
            return resultList;
        }

        private void filterTheAvailablePeriod()
        {
            
        }
    }
}
