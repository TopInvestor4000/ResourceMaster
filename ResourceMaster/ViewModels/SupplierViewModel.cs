namespace ResourceMaster.ViewModels;

public class SupplierViewModel
{
    public int id { get; set; }
    public string corporation { get; set; }
    public int neededWorkforce { get; set; }
    public Professions searchingFor { get; set; }
}
