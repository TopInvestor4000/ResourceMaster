using ResourceMaster.DAL.Data;

namespace ResourceMaster.DAL.TestData;

public class SeedData
{
    private DatabaseContext _context;
    private SeedCustomer _seedCustomer = new();
    private SeedProject _seedProject = new();
    private SeedSkill _seedSkill = new();

    public SeedData(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task AddSeedDataAsync()
    {
        await _context.Customers.AddRangeAsync(_seedCustomer.SeedCustomers(300));
        await _context.Projects.AddRangeAsync(_seedProject.SeedProjects(100, _context.Customers.ToList()));
        await _context.Skills.AddRangeAsync(_seedSkill.SeedSkills());
        await _context.SaveChangesAsync();
    }
    
}
