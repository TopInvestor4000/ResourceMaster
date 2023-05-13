namespace ResourceMaster.ViewModels;

public class CustomerViewModel
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public string Location { get; set; }
    public Countries Country { get; set; }
}
