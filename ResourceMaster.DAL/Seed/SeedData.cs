using ResourceMaster.DAL.Data;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Seed;

namespace ResourceMaster.DAL.TestData;

public class SeedData
{
    private readonly DatabaseContext _context;
    private readonly SeedCustomer _seedCustomer = new();
    private readonly SeedProject _seedProject = new();
    private readonly SeedSkill _seedSkill = new();
    private readonly SeedResource _seedResource = new();
    private readonly SeedResourceSkill _seedResourceSkill = new();
    private readonly SeedProjectSkill _seedProjectSkill = new();

    public SeedData(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task AddSeedDataAsync()
    {
        await _context.Customers.AddRangeAsync(_seedCustomer.SeedCustomers(300));
        await _context.SaveChangesAsync();
        await _context.Projects.AddRangeAsync(_seedProject.SeedProjects(100, _context.Customers.ToList()));
        await _context.Skills.AddRangeAsync(_seedSkill.SeedSkills());
        await _context.Resources.AddRangeAsync(_seedResource.SeedResources(200));
        await _context.SaveChangesAsync();
      

        List<Resource> resources = _context.Resources.ToList();
        List<Skill> skills = _context.Skills.ToList();
        List<Project> projects = _context.Projects.ToList();
        await _context.ResourceSkills.AddRangeAsync(_seedResourceSkill.SeedResourceSkills(resources, skills));
        await _context.ProjectSkills.AddRangeAsync(_seedProjectSkill.SeedProjectSkills(projects, skills));
        await _context.SaveChangesAsync();
    }
    
}
