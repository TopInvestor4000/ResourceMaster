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

        public ProjectService(IProjectRepository repository, ILogger<ProjectService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAllAsync( )
        {
            _logger.LogInformation("GetAllAsync Method called");
            var projectList =  await _repository.GetAllAsync();
            return projectList.Adapt<List<ProjectViewModel>>();
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
        public async Task Update(ProjectViewModel project)
        {
            var existingEntry = await GetSingle(project.Id);
            var updatedViewModel = project.Adapt(existingEntry);
            var updatedItem = updatedViewModel.Adapt<Project>();
            await _repository.UpdateAsync(updatedItem);
        }
    }
}
