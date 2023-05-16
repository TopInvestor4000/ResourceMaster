namespace ResourceMaster.ViewModels;

public class SkillInformationViewModel
{
    public int Id { get; set; }
    public SkillViewModel Skill { get; set; } = default!;
    public string SkillLevel { get; set; } = default!;
    public bool IsCertification { get; set; }
}
