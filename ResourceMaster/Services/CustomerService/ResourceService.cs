using Mapster;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.ResourceRepository;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Services.CustomerService
{
    public class ResourceService
    {
        private readonly IResourceRepository _repository;
        private readonly ILogger<ResourceService> _logger;

        public ResourceService(IResourceRepository repository, ILogger<ResourceService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<ResourceViewModel>> GetAllAsync()
        {
            _logger.LogInformation("GetAllAsync Method called");
            var customerList =  await _repository.GetAllAsync();
            var resultList = customerList.Adapt<List<ResourceViewModel>>();
            return resultList;
        }

        public async Task<ResourceViewModel> GetSingle(int id)
        {
            _logger.LogInformation("GetAllAsync Method called");
            var resource = await _repository.GetSingle(id);
            var result = resource.Adapt<ResourceViewModel>();
            return result;
        }

        public async Task AddAsync(ResourceViewModel resource)
        {
            var newEntry = resource.Adapt<Resource>();
            await _repository.AddAsync(newEntry);
        }
    }
}
