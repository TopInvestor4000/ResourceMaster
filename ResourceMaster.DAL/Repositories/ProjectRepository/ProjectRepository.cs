using Microsoft.EntityFrameworkCore;
using ResourceMaster.DAL.Data;
using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.ProjectRepository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DatabaseContext _context;

        public ProjectRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Delete(Project itemToDelte)
        {
            _context.Projects.Remove(itemToDelte);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetSingle(int id)
        {
            return await _context
                .Projects
                .Include(x => x.Skills).ThenInclude(x => x.Skill)
                .Include(x => x.ProjectResources).ThenInclude(x => x.Resource)
                .Include(x => x.Customer)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            project.Customer = _context.Customers.Find(project.Customer.Id);
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task UpdateHires(Project updatedItem)
        {
            _context.ProjectResources.RemoveRange(_context.ProjectResources.Where(x => x.ProjectId == updatedItem.Id));
            _context.Projects.Update(updatedItem);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
    }
}
