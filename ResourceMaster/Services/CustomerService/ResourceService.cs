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
                    street = table.street,
                    zipCode = table.zipCode,
                    location = table.location,
                    country = (Countries)Enum.Parse(typeof(Countries), table.country),
                    skills = table.skills,
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
                    street = resource.street,
                    zipCode = resource.zipCode,
                    location = resource.location,
                    country = resource.country.ToString(),
                    skills = resource.skills,
            };

            await _repository.AddAsync(newEntry);
        }
    }
}
