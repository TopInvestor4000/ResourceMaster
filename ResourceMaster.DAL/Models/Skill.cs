namespace ResourceMaster.DAL.Models;

public class Skill
{
    public int Id { get; set; }
    public string SkillName { get; set; }

    public List<Project> Projects { get; set; }
    public List<Resource> Resources { get; set; }

}
