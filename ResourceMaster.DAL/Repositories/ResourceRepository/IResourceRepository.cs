using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.ResourceRepository
{
    public interface IResourceRepository
    {
        Task AddAsync(Resource resource);
        Task Delete(int id);
        Task<IQueryable<Resource>> GetAllAsync();
        Task<List<Resource>> GetAllWithIncludeAsync();
        Task<Resource> GetSingle(int id);
        Task UpdateAsync(Resource resource);
    }
}
