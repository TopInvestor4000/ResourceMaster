using Microsoft.EntityFrameworkCore;
using ResourceMaster.DAL.Data;

namespace ResourceMaster.DAL.Repositories.ResourceProject;

public class ResourceProjectRepository : IResourceProjectRepository
{
    private readonly DatabaseContext _context;
    
    public ResourceProjectRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Models.ProjectResource>> GetAvailability(int id, DateTime? from, DateTime? to)
    {
        return await _context.ProjectResources.Where(x => x.ResourceId == id && !(x.BookedFrom <= from && to <= x.BookedTo || x.BookedFrom >= to || x.BookedTo <= from)).ToListAsync();
    }
}
