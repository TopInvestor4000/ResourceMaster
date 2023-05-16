using ResourceMaster.DAL.Models;

namespace ResourceMaster.ViewModels;

public class ProjectViewModel
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public CustomerViewModel Customer { get; set; }
    public int workForce { get; set; }
    public DateTime? ProjectStart { get; set; }
    public DateTime? ProjectEnd { get; set; }
    public List<SkillInformationViewModel> Skills { get; set; }
}
