namespace ResourceMaster.DAL.Models;

public class Project
{
    public int id { get; set; }
    public string projectName { get; set; }
    public Customer customer { get; set; }
    public int workForce { get; set; }
    public DateTime projectStart { get; set; }
    public DateTime projectEnd { get; set; }
    public List<Skill> skills { get; set; }
}
