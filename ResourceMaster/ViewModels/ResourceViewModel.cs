using ResourceMaster.DAL.Models;

namespace ResourceMaster.ViewModels;

public class ResourceViewModel
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string ZipCode { get; set; } = default!;
    public string Location { get; set; } = default!;
    public Countries Country { get; set; }
    public List<SkillInformationViewModel> Skills { get; set; } = default!;
    public List<ProjectResourceViewModel> ProjectResources { get; set; } = default!;
}
