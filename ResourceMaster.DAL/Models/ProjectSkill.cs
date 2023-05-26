using System.Diagnostics.CodeAnalysis;

namespace ResourceMaster.DAL.Models
{
    public class ProjectSkill : BaseSkill
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; } = default!;

        public int? RequiredWorkHours { get; set; }

        public string? Necessity { get; set; } 
    }
}
