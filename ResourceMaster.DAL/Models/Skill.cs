namespace ResourceMaster.DAL.Models;

public class Skill
{
    public int Id { get; set; }
    public string SkillName { get; set; } = default!;
    public List<ProjectSkill> ProjectSkills { get; set; } = default!;
    public List<ResourceSkill> ResourceSkills { get; set; } = default!;

}
