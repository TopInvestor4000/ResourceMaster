namespace ResourceMaster.DAL.Models;

public class Customer
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public string Location { get; set; }
    public string Country { get; set; }

    public List<Project> Project { get; set; }
}
