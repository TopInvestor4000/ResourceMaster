using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.ResourceRepository
{
    public interface IResourceRepository
    {
        Task AddAsync(Resource customer);
        Task<IQueryable<Resource>> GetAllAsync();
        Task<List<Resource>> GetAllWithIncludeAsync();
        Task<Resource> GetSingle(int id);
    }
}
