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
            var customerList =  await _repository.GetAllAsync();
            List<ProjectViewModel> resultList = new List<ProjectViewModel>();
            foreach (var table in customerList)
            {
                var viewModel = new ProjectViewModel()
                {
                    id = table.id,
                    projectName = table.projectName,
                    customer = table.customer,
                    workForce = table.workForce,
                    projectStart = table.projectStart,
                    projectEnd = table.projectEnd,
                    skills = table.skills,
                };
                resultList.Add(viewModel);
            }
            return resultList;
        }

        public async Task AddAsync(ProjectViewModel project)
        {
            var newEntry = new Project()
            {
                    id = project.id,
                    projectName = project.projectName,
                    customer = project.customer,
                    workForce = project.workForce,
                    projectStart = project.projectStart,
                    projectEnd = project.projectEnd,
                    skills = project.skills,
            };

            await _repository.AddAsync(newEntry);
        }
    }
}
