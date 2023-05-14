using ResourceMaster.DAL.Models;

namespace ResourceMaster.ViewModels;

public class ResourceViewModel
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public string Location { get; set; }
    public Countries Country { get; set; }
    public List<SkillViewModel> Skills { get; set; }
    
    public List<Project> Projects { get; set; }
}
