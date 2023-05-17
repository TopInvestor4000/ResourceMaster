using Bogus;
using ResourceMaster.DAL.Models;
using ResourceMaster.Migrations;

namespace ResourceMaster.DAL.Seed;

public class SeedResource
{
    public List<Resource> SeedResources(int num)
    {
        var resources = GenerateResources(num);
        AddAge(resources);
        return resources;
    }

    private List<Resource> GenerateResources(int num)
    {
        var faker = new Faker<Resource>()
            .RuleFor(t => t.FirstName, f => f.Name.FirstName())
            .RuleFor(t => t.LastName, f => f.Name.LastName());

        return faker.Generate(num);
    }

    private void AddAge(List<Resource> resources)
    {
        var random = new Random();
        
        foreach (var r in resources)
        {
            r.Age = random.Next(21, 65);
        }
    }
}




