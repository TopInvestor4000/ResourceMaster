namespace ResourceMaster.DAL.Models;

public class Resource
{
    public int id { get; set; }
    public int age { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public List<Skill> skills { get; set; }}
