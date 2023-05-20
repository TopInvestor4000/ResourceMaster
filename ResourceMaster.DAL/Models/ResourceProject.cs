namespace ResourceMaster.DAL.Models
{
    public class ResourceProject
    {
        public int ResourceProjectId { get; set; }
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public DateTime BookedFrom { get; set; }
        public DateTime BookedTo { get; set; }
    }
}
