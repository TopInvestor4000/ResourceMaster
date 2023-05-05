using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.ProjectRepository
{
    public interface IProjectRepository
    {
        Task AddAsync(Project customer);
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetSingle(int id);
    }
}
