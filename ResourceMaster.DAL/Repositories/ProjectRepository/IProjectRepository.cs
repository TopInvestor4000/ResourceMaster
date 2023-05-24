using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.ProjectRepository
{
    public interface IProjectRepository
    {
        Task AddAsync(Project project);
        Task Delete(Project itemToDelte);
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetSingle(int id);
        Task UpdateHires(Project updatedItem);
    }
}
