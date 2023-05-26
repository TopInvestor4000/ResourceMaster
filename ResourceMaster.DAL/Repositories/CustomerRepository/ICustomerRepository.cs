using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.CustomerRepository
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task Delete(Customer itemToDelte);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetSingle(int id);
        Task Update(Customer customer);
    }
}
