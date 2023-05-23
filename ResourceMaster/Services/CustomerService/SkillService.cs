using Mapster;
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

        public async Task<IEnumerable<SkillViewModel>> GetAllAsync()
        {
            _logger.LogInformation("GetAllAsync Method called");
            var customerList =  await _repository.GetAllAsync();
            List<SkillViewModel> resultList = customerList.Adapt<List<SkillViewModel>>();
            return resultList;
        }

        public async Task AddAsync(SkillViewModel skill)
        {
            var newEntry = skill.Adapt<Skill>();
            await _repository.AddAsync(newEntry);
        }
    }
}
