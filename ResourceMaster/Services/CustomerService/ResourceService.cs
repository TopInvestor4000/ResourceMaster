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

        public async Task<IEnumerable<ResourceViewModel>> GetAllAsync( )
        {

            _logger.LogInformation("GetAllAsync Method called");
            var customerList =  await _repository.GetAllAsync();
            List<ResourceViewModel> resultList = new List<ResourceViewModel>();
            foreach (var table in customerList)
            {
                var viewModel = new ResourceViewModel()
                {
                    id = table.id,
                    age = table.age,
                    firstName = table.firstName,
                    lastName = table.lastName,
                    // TODO skills = table.skills,
                };
                resultList.Add(viewModel);
            }
            return resultList;
        }

        public async Task AddAsync(ResourceViewModel resource)
        {
            var newEntry = new Resource()
            {
                    id = resource.id,
                    age = resource.age,
                    firstName = resource.firstName,
                    lastName = resource.lastName,
                    // TODO skills = resource.skills,
            };

            await _repository.AddAsync(newEntry);
        }
    }
}
