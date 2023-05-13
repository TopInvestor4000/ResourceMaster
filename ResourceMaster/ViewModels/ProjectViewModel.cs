using ResourceMaster.DAL.Models;

namespace ResourceMaster.ViewModels;

public class ProjectViewModel
{
    public int Id { get; set; }
    public string projectName { get; set; }
    public Customer Customer { get; set; }
    public int workForce { get; set; }
    public DateTime? ProjectStart { get; set; }
    public DateTime? projectEnd { get; set; }
    public List<Skill> Skills { get; set; }
}
