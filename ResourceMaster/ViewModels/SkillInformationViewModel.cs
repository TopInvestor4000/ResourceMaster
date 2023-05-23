namespace ResourceMaster.ViewModels;

public class SkillInformationViewModel
{
    public int Id { get; set; }
    public SkillViewModel Skill { get; set; } = default!;
    public SkillLevel SkillLevel { get; set; }
    public int SkillId { get; set; }
    public bool IsCertification { get; set; }
    public int? RequiredWorkHours { get; set; }
    public string? Necessity { get; set; }
}

class SkillInformationViewModelEqualityComparer : IEqualityComparer<SkillInformationViewModel>
{
    public bool Equals(SkillInformationViewModel x, SkillInformationViewModel y)
    {
        if (ReferenceEquals(x, y))
            return true;
        if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            return false;
        return x.Skill.SkillName == y.Skill.SkillName;
    }

    public int GetHashCode(SkillInformationViewModel obj)
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + obj.Skill.SkillName.GetHashCode();
            return hash;
        }
    }
}
