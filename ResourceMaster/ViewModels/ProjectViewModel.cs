using ResourceMaster.DAL.Models;

namespace ResourceMaster.ViewModels;

public class ProjectViewModel
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = default!;
    public CustomerViewModel Customer { get; set; } = default!;
    public DateTime? ProjectStart { get; set; } 
    public DateTime? ProjectEnd { get; set; }
    public List<SkillInformationViewModel> Skills { get; set; } = default!;
    public List<ProjectResourceViewModel> ProjectResources { get; set; } = default!;
}
