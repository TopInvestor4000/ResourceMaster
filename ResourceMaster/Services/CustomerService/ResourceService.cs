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
                    id = table.Id,

                };
                resultList.Add(viewModel);
            }
            return resultList;
        }

        public async Task AddAsync(ResourceViewModel resource)
        {
            var newEntry = new Resource()
            {
                    Id = resource.id,
                   
            };

            await _repository.AddAsync(newEntry);
        }
    }
}
