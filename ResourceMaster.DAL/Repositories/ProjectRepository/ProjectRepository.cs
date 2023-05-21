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

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetSingle(int id)
        {

            return await _context
                .Projects
                .Include(x => x.Skills)
              //  .Include(x => x.Resources)
                .SingleOrDefaultAsync(x => x.Id == id);

        }

        public async Task AddAsync(Project project)
        {
            project.Customer = _context.Customers.Find(project.Customer.Id);
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project updatedItem)
        {
            _context.Projects.Update(updatedItem);
            await _context.SaveChangesAsync();
        }
    }
}
