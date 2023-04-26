using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.CustomerRepository
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
