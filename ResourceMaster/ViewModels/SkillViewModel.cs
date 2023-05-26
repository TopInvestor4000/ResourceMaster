namespace ResourceMaster.ViewModels;

public class SkillViewModel : IComparable<SkillViewModel>
{
    public int Id { get; set; }
    public string SkillName { get; set; } = default!;

    override
    public string ToString() => SkillName ?? string.Empty;

    public int CompareTo(SkillViewModel? other)
    {
        return string.Compare(SkillName, other?.SkillName, StringComparison.Ordinal);
    }
}
