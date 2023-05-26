namespace ResourceMaster.DAL.Models
{
    public abstract class BaseSkill
    {
        public int Id { get; set; }
        public Skill Skill { get; set; } = default!;
        public int SkillId { get; set; } 
        public bool IsCertification { get; set; } = default;
        public string SkillLevel { get; set; } = default!;
    }
}
