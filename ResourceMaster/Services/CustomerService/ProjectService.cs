using Mapster;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.ProjectRepository;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Services.CustomerService
{
    public class ProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly ILogger<ProjectService> _logger;
        private readonly CustomerService _customerService;

        public ProjectService(IProjectRepository repository, ILogger<ProjectService> logger, CustomerService customerService)
        {
            _repository = repository;
            _logger = logger;
            _customerService = customerService;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAllAsync( )
        {
            _logger.LogInformation("GetAllAsync Method called");
            var customerList =  await _repository.GetAllAsync();
            return customerList.Adapt<List<ProjectViewModel>>();
        }

        public async Task<ProjectViewModel> GetSingle(int id)
        {
            var project = await _repository.GetSingle(id);
            return project.Adapt<ProjectViewModel>();

        }

        public async Task AddAsync(ProjectViewModel project)
        {
            var newEntry = project.Adapt<Project>();
            await _repository.AddAsync(newEntry);
        }
    }
}
