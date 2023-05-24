using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.SkillRepository
{
    public interface ISkillRepository
    {
        Task AddUpdate(Skill skill);
        Task DeleteAsync(int id);
        Task<IEnumerable<Skill>> GetAllAsync();
    }
}
