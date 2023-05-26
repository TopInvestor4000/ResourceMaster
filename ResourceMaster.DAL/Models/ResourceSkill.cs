namespace ResourceMaster.DAL.Models
{
    public class ResourceSkill : BaseSkill
    {
        public int ResourceId { get; set; }
        public Resource Resource { get; set; } = default!;
    }
}
