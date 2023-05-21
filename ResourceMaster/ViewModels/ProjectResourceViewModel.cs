using ResourceMaster.DAL.Models;

namespace ResourceMaster.ViewModels
{
    public class ProjectResourceViewModel
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public ResourceViewModel Resource { get; set; } = default!;

        public int ProjectId { get; set; }
        public ProjectViewModel Project { get; set; } = default!;

        public DateTime BookedFrom { get; set; }
        public DateTime BookedTo { get; set; }
    }
}
