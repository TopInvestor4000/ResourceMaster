using Microsoft.EntityFrameworkCore;
using ResourceMaster.DAL.Data;
using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly DatabaseContext _context;

        public CustomerRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);

            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task Update(Customer customer)
        {
             _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task Delete(Customer itemToDelte)
        {
            _context.Customers.Remove(itemToDelte);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task<Customer> GetSingle(int id)
        {
            return await _context.Customers
                .Include(x => x.Project)
                .AsNoTracking()
                .SingleAsync(x => x.Id == id);
        }
    }
}
