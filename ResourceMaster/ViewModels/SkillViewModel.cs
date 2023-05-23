namespace ResourceMaster.ViewModels;

public class SkillViewModel
{
    public int Id { get; set; }
    public string SkillName { get; set; } = default!;

    override
    public string ToString() => SkillName ?? string.Empty;
}
