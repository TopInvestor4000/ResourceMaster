using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.SkillRepository
{
    public interface ISkillRepository
    {
        Task AddAsync(Skill customer);
        Task<IEnumerable<Skill>> GetAllAsync();
    }
}
