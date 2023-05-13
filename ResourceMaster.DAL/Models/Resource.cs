namespace ResourceMaster.DAL.Models;

public class Resource
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Skill> Skills { get; set; }
    public List<Project> Projects { get; set; }

}
