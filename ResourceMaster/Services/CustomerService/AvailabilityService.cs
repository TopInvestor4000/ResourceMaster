using Mapster;
using ResourceMaster.DAL.Repositories.ResourceProject;
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

        public virtual async Task<IEnumerable<AvailabilityViewModel>> GetAvailability(int id, DateTime? from, DateTime? to)
        {
            _logger.LogInformation("GetAllAsync Method called");
            var availabilityList =  await _repository.GetAvailability(id, from, to);
            var resultList = availabilityList.Adapt<List<AvailabilityViewModel>>();
            return resultList;
        }

    }
}
