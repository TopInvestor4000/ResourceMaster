namespace ResourceMaster.DAL.Models;

public class Customer
{
    public int id { get; set; }
    public string companyName { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string street { get; set; }
    public string zipCode { get; set; }
    public string location { get; set; }
    public string country { get; set; }
}
