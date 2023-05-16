namespace ResourceMaster.DAL.Models;

public class Skill
{
    public int Id { get; set; }
    public string SkillName { get; set; }

    public List<ProjectSkill> ProjectSkills { get; set; }
    public List<ResourceSkill> ResourceSkills { get; set; }

}
