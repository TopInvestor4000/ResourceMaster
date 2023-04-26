namespace ResourceMaster.ViewModels;

public class ProjectViewModel
{
    public int id { get; set; }
    public string projectName { get; set; }
    public CustomerViewModel customer { get; set; }
    public int workForce { get; set; }
    public DateTime projectStart { get; set; }
    public DateTime projectEnd { get; set; }
    public List<SkillViewModel> skills { get; set; }
}
