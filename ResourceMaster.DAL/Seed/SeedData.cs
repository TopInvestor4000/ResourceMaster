using ResourceMaster.DAL.Data;
using ResourceMaster.DAL.Seed;

namespace ResourceMaster.DAL.TestData;

public class SeedData
{
    private DatabaseContext _context;
    private SeedCustomer _seedCustomer = new();
    private SeedProject _seedProject = new();
    private SeedSkill _seedSkill = new();
    private SeedResource _seedResource = new();

    public SeedData(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task AddSeedDataAsync()
    {
        await _context.Customers.AddRangeAsync(_seedCustomer.SeedCustomers(300));
        await _context.Projects.AddRangeAsync(_seedProject.SeedProjects(100, _context.Customers.ToList()));
        await _context.Skills.AddRangeAsync(_seedSkill.SeedSkills());
        await _context.Resources.AddRangeAsync(_seedResource.SeedResources(200));
        await _context.SaveChangesAsync();
    }
    
}
