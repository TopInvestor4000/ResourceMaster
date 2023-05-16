namespace ResourceMaster.DAL.Models;

public class Skill : IComparable<Skill>
{
    public Skill(string description, bool isCertification, string skillLevel, string necessity)
    {
        this.description = description;
        this.isCertification = isCertification;
        this.skillLevel = skillLevel;
        this.necessity = necessity;
    }

    public Skill()
    {
    }

    public int id { get; set; }
    public string description { get; set; }
    public bool isCertification { get; set; }
    public string skillLevel { get; set; }
    public string necessity { get; set; }
    public int CompareTo(Skill? skill)
    {
        if (skill == null) return 1;

        // Compare by description
        return String.Compare(description, skill.description, StringComparison.Ordinal);
    }
}
