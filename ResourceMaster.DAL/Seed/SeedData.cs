using ResourceMaster.DAL.Data;

namespace ResourceMaster.DAL.TestData;

public class SeedData
{
    private DatabaseContext _context;
    private SeedCustomer _seedCustomer = new();

    public SeedData(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task AddSeedDataAsync()
    {
        var customers = _seedCustomer.SeedCustomers(300);
        await _context.Customers.AddRangeAsync(customers);
        await _context.SaveChangesAsync();
    }
    
}
