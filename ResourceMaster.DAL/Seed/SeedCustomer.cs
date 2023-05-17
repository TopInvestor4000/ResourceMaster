namespace ResourceMaster.DAL.TestData;
using Models;
using Bogus;


public class SeedCustomer
{
    public List<Customer> SeedCustomers(int num)
    {
        return GenerateCustomers(num);
    }
    
    private List<Customer> GenerateCustomers(int num)
    {
        var faker = new Faker<Customer>()
            .RuleFor(t => t.CompanyName, f => f.Company.CompanyName())
            .RuleFor(t => t.FirstName, f => f.Name.FirstName())
            .RuleFor(t => t.LastName, f => f.Name.LastName())
            .RuleFor(t => t.Street, f => f.Address.StreetName() + " " + f.Address.StreetAddress())
            .RuleFor(t => t.ZipCode, f => f.Address.ZipCode())
            .RuleFor(t => t.Location, f => f.Address.City())
            .RuleFor(t => t.Country, f => f.Address.Country());
        
        return faker.Generate(num);
    }
}
