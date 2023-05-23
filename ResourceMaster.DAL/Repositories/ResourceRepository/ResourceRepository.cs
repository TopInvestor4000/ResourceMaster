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
                .AsSplitQuery()
                .AsNoTracking();
        }

        public async Task<Resource> GetSingle(int id)
        {
                return await _context
                             .Resources
                             .Include(x => x.ProjectResources)
                             .ThenInclude(x => x.Project)
                             .Include(x => x.Skills)
                             .AsNoTracking()
                             .SingleAsync(x => x.Id == id);
        }

        public async Task AddAsync(Resource resource)
        {
            await _context.Resources.AddAsync(resource);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Resource>> GetAllWithIncludeAsync()
        {
            return await _context
              .Resources
              .Include(x => x.ProjectResources)
              .ThenInclude(x => x.Project)
              .Include(x => x.Skills).ThenInclude(x => x.Skill)
              .AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(Resource resource)
        {
            var deletedItems = _context.ResourceSkills
                .Where(x => x.ResourceId == resource.Id
                && !resource.Skills.Select(x => x.Id).Contains(x.Id)).AsNoTracking().ToList();

            _context.RemoveRange(deletedItems);

            _context.Resources.Update(resource);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = _context.Resources.SingleOrDefault(x => x.Id == id);
            if(item != null)
            {
                _context.Resources.Remove(item);
                await _context.SaveChangesAsync();
            }
   
        }
    }
}
