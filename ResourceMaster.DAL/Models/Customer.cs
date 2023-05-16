namespace ResourceMaster.DAL.Models;

public class Customer
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string ZipCode { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Country { get; set; } = default!;

    public List<Project> Project { get; set; } = default!;
}
