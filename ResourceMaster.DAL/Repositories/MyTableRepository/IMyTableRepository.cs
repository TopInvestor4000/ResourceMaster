using ResourceMaster.Models;

namespace ResourceMaster.DAL.Repositories.MyTableRepository
{
    public interface IMyTableRepository
    {
        Task AddAsync(MyTable myTable);
        Task<IEnumerable<MyTable>> GetAllAsync();
    }
}
