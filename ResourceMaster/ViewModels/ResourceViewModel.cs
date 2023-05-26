using ResourceMaster.DAL.Models;

namespace ResourceMaster.ViewModels;

public class ResourceViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int Age { get; set; } = default!;
    public List<SkillInformationViewModel> Skills { get; set; } = new();
    public List<ProjectResourceViewModel> ProjectResources { get; set; } = new();
}
