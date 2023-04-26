using ResourceMaster.DAL.Models;

namespace ResourceMaster.ViewModels;

public class ResourceViewModel
{
    public int id { get; set; }
    public int age { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string street { get; set; }
    public string zipCode { get; set; }
    public string location { get; set; }
    public string country { get; set; }
    public List<Skill> skills { get; set; }}
