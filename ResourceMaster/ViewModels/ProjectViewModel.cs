using ResourceMaster.DAL.Models;

namespace ResourceMaster.ViewModels;

public class ProjectViewModel
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = default!;
    public CustomerViewModel Customer { get; set; } = default!;
    public int workForce { get; set; } = default!;
    public DateTime? ProjectStart { get; set; } = default!;
    public DateTime? ProjectEnd { get; set; } = default!;
    public List<SkillInformationViewModel> Skills { get; set; } = default!;
}
