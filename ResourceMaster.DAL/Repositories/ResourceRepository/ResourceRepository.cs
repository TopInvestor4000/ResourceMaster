﻿using Microsoft.EntityFrameworkCore;
using ResourceMaster.DAL.Data;
using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.ResourceRepository
{
    public class ResourceRepository : IResourceRepository
    {

        private readonly DatabaseContext _context;

        public ResourceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Resource>> GetAllAsync()
        {
            return await _context
                .Resources
                .ToListAsync();
        }

        public async Task<Resource> GetSingle(int id)
        {

                return await _context
                             .Resources
                          //   .Include(x => x.Projects)
                             .Include(x => x.Skills)
                             .SingleAsync(x => x.Id == id);
           

        }

        public async Task AddAsync(Resource customer)
        {
            await _context.Resources.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
    }
}
