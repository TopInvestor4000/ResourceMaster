namespace ResourceMaster.ViewModels;

public class SkillInformationViewModel
{
    public int Id { get; set; }
    public SkillViewModel Skill { get; set; }
    public string SkillLevel { get; set; }
    public bool IsCertification { get; set; }
}
