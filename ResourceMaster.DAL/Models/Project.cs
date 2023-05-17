namespace ResourceMaster.DAL.Models;

public class Project
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = default!;
    public DateTime? ProjectStart { get; set; } 
    public DateTime? ProjectEnd { get; set; }


    public Customer Customer { get; set; } = default!;
    public List<ProjectSkill> Skill { get; set; } = default!;
}
