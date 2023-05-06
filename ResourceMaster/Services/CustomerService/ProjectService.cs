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
            List<ProjectViewModel> resultList = new List<ProjectViewModel>();
            foreach (var table in customerList)
            {
                ProjectViewModel viewModel = ToViewModel(table);
                resultList.Add(viewModel);
            }
            return resultList;
        }

        private static ProjectViewModel ToViewModel(Project table)
        {
            return new ProjectViewModel()
            {
                id = table.Id,
                projectName = table.ProjectName,
                customer = table.Customer,
                projectStart = table.ProjectStart,
                projectEnd = table.ProjectEnd,
            };
        }

        public async Task<ProjectViewModel> GetSingle(int id)
        {
            var project = await _repository.GetSingle(id);
            return ToViewModel(project);

        }

        public async Task AddAsync(ProjectViewModel project)
        {
            var newEntry = new Project()
            {
                    Id = project.id,
                    ProjectName = project.projectName,
                   Customer = project.customer,
                  
                    ProjectStart = DateTime.SpecifyKind(project.projectStart.Value, DateTimeKind.Utc),
                    ProjectEnd = DateTime.SpecifyKind(project.projectEnd.Value, DateTimeKind.Utc),
            };

            await _repository.AddAsync(newEntry);
        }
    }
}
