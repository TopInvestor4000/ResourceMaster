using Microsoft.EntityFrameworkCore;
using ResourceMaster.DAL.Data;
using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.SkillRepository
{
    public class SkillRepository : ISkillRepository
    {

        private readonly DatabaseContext _context;

        public SkillRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddUpdate(Skill skill)
        {
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task DeleteAsync(int id)
        {
            _context.Skills.Remove(_context.Skills.Single(x => x.Id == id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return await _context.Skills.AsNoTracking().ToListAsync();
        }

    }
}
