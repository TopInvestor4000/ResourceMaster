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
            var test = await _context.ProjectSkills.Where(x => x.ProjectId == id).ToListAsync();
            foreach (var projectSkill in test)
            {
                await _context.Skills.Where(x => x.ProjectSkills.Where(x => x.Id == projectSkill.Id).Count() > 0).ToListAsync();
            }

            return await _context.Projects.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            project.Customer = _context.Customers.Find(project.Customer.Id);
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }
    }
}
