namespace ResourceMaster.DAL.Models;

public class Resource
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public List<ResourceSkill> Skills { get; set; } = default!;
    public List<Project> Projects { get; set; } = default!;

}
