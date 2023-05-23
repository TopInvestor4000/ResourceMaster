using Microsoft.EntityFrameworkCore;
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

        public async Task<IQueryable<Resource>> GetAllAsync()
        {
            return  _context
                .Resources
                .Include(x => x.Skills).ThenInclude(x => x.Skill)
                .AsSplitQuery();
        }

        public async Task<Resource> GetSingle(int id)
        {
                return await _context
                             .Resources
                             .Include(x => x.ProjectResources)
                             .ThenInclude(x => x.Project)
                             .Include(x => x.Skills)
                             .SingleAsync(x => x.Id == id);
        }

        public async Task AddAsync(Resource customer)
        {
            await _context.Resources.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Resource>> GetAllWithIncludeAsync()
        {
            return await _context
              .Resources
              .Include(x => x.ProjectResources)
              .ThenInclude(x => x.Project)
              .Include(x => x.Skills).ThenInclude(x => x.Skill).ToListAsync();
        }
    }
}
