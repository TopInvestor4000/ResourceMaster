namespace ResourceMaster.ViewModels;

public class ResourceViewModel
{
    public int id { get; set; }
    public int age { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string address { get; set; }

    public string zipCode { get; set; }
    public List<SkillViewModel> skills { get; set; }
}
