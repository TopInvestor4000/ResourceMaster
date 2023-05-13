namespace ResourceMaster.DAL.Models;

public class Project
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public DateTime? ProjectStart { get; set; }
    public DateTime? ProjectEnd { get; set; }


    public Customer Customer { get; set; }
    public List<Skill> Skill { get; set; }
}
