using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.SkillRepository;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Services.CustomerService
{
    public class SkillService
    {
        private readonly ISkillRepository _repository;
        private readonly ILogger<SkillService> _logger;

        public SkillService(ISkillRepository repository, ILogger<SkillService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<SkillViewModel>> GetAllAsync( )
        {

            _logger.LogInformation("GetAllAsync Method called");
            var customerList =  await _repository.GetAllAsync();
            List<SkillViewModel> resultList = new List<SkillViewModel>();
            foreach (var table in customerList)
            {
                var viewModel = new SkillViewModel()
                {
                    id = table.id,
                    description = table.description,
                    isCertification = table.isCertification,
                    skillLevel = table.skillLevel,
                    necessity = table.necessity
                };
                resultList.Add(viewModel);
            }
            return resultList;
        }

        public async Task AddAsync(SkillViewModel skill)
        {
            var newEntry = new Skill()
            {
                    id = skill.id,
                    description = skill.description,
                    isCertification = skill.isCertification,
                    skillLevel = skill.skillLevel,
                    necessity = skill.necessity
            };

            await _repository.AddAsync(newEntry);
        }
    }
}
