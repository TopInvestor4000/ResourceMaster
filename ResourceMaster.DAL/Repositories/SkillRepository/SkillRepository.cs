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

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return await _context.Skills.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(Skill customer)
        {
            await _context.Skills.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
    }
}
