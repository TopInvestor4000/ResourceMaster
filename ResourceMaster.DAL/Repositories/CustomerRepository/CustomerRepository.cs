﻿using Microsoft.EntityFrameworkCore;
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
        }

        public async Task Update(Customer customer)
        {
             _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Customer itemToDelte)
        {
            _context.Customers.Remove(itemToDelte);
            await _context.SaveChangesAsync();
        }
    }
}
