using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.ResourceRepository
{
    public interface IResourceRepository
    {
        Task AddAsync(Resource customer);
        Task<IEnumerable<Resource>> GetAllAsync();
    }
}
